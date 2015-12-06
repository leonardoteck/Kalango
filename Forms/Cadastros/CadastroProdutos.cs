using ExceptionHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalango
{
    public partial class CadastroProdutos : Form
    {
        public CadastroProdutos()
        {
            InitializeComponent();
        }

        frmContainer cont = frmContainer.TheContainer;

        private void CadastroProdutos_Load(object sender, EventArgs e)
        {
            btnCancelar.Click += cont.btnCancelar_Click;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            foreach (Control grb in pnlForm.Controls)
                foreach (Control ctrl in grb.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ctrl.Text = "";
                    }
                    else if (ctrl is NumericUpDown)
                    {
                        ((NumericUpDown)ctrl).Value = 0;
                    }
                }
            lstFornecedores.Items.Clear();
        }

        Dictionary<long, int> forns = new Dictionary<long, int>();
        bool cadastrouProduto = false;
        bool cadastrouRelacao = false;
        int produtoId;

        private void btnOK_Click(object sender, EventArgs e)
        {
            // validação antes
            bool valido = true;
            List<int> nullCtrls = new List<int>() {
                txtTipoEmb.GetHashCode(),
                txtLocal.GetHashCode(),
                nudMin.GetHashCode(),
                nudMed.GetHashCode()
            };
            bool alertado = false;
            foreach (Control grb in pnlForm.Controls)
                foreach (Control ctrl in grb.Controls)
                {
                    if (ctrl.GetType() == typeof(TextBox))
                    {
                        if (string.IsNullOrWhiteSpace(((TextBox)ctrl).Text)
                            && !nullCtrls.Contains(ctrl.GetHashCode()))
                        {
                            valido = false;
                        }
                    }
                    else if (ctrl.GetType() == typeof(NumericUpDown))
                    {
                        if (((NumericUpDown)ctrl).Value == 0
                            && !nullCtrls.Contains(ctrl.GetHashCode()))
                        {
                            valido = false;
                        }
                    }
                    if (!alertado && !valido)
                    {
                        MsgAvancado.ExibirErroValidacao("Preencha todos os controles que têm um asterisco ( * ) em cima!");
                        ctrl.Focus();
                        alertado = true;
                    }
                }
            if (!Validar.CodBarras(txtCodBarras.Text))
            {
                MsgAvancado.ExibirErroValidacao("O código de barras informado não existe!");
                valido = false;
            }
            ControladorBD dbctrl = new ControladorBD();
            try
            {
                int qt = dbctrl.Contar<int>("SELECT COUNT(*) FROM tbProduto WHERE codBarras = " + txtCodBarras.Text);
                if (qt > 0)
                {
                    MsgAvancado.ExibirErroValidacao("Já há um produto com o dado cód. de barras cadastrado!");
                    valido = false;
                }
            }
            catch (Exception ex)
            {
                MsgAvancado.ExibirErro(ex, "Não foi possível conectar-se ao banco de dados");
            }
            if (!valido)
                return;

            object[] valores = new object[11];
            try
            {
                valores[0] = Converter<long>(txtCodBarras.Text);
                valores[1] = txtDesc.Text;
                valores[2] = txtUnid.Text;
                valores[3] = txtLocal.Text;
                valores[4] = txtTipoEmb.Text;
                valores[5] = cbxInv.SelectedIndex;
                valores[6] = Converter<float>(nudMed.Value);
                valores[7] = Converter<int>(nudPonto.Value);
                valores[8] = Converter<float>(nudMin.Value);
                valores[10] = Converter<float>(nudMax.Value);
                valores[9] = (((float)valores[10]) + ((float)valores[8])) / 2;
            }
            catch (Exception ex)
            {
                MsgAvancado.ExibirErro(ex, "Não foi possível fazer a leitura dos dados");
                return;
            }
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@codBarras", valores[0]),
                new SqlParameter("@desc", valores[1]),
                new SqlParameter("@unid", valores[2]),
                new SqlParameter("@local", valores[3]),
                new SqlParameter("@tipo", valores[4]),
                new SqlParameter("@inv", valores[5]),
                new SqlParameter("@mediac", valores[6]),
                new SqlParameter("@ponto", valores[7]),
                new SqlParameter("@estmin", valores[8]),
                new SqlParameter("@estmed", valores[9]),
                new SqlParameter("@estmax", valores[10])
            };

            string query = @"INSERT INTO tbProduto VALUES (
            @codBarras, @desc, @unid, @local, @tipo, @inv, @mediac, @ponto, @estmin, @estmed, @estmax)";

            try
            {
                dbctrl.LerEAlterar(query, paras);
                produtoId = dbctrl.Contar<int>("SELECT MAX(ProdutoID) FROM tbProduto");
                cadastrouProduto = true;

                foreach (int id in forns.Values)
                {
                    dbctrl.LerEAlterar("INSERT INTO tbFornecedorProduto VALUES(" 
                        + id.ToString() + ", " + produtoId.ToString() + ")");
                    cadastrouRelacao = true;
                }

                MsgAvancado.ExibirInformacao("Cadastro efetuado com sucesso!");
                DialogResult dr = MsgAvancado.ExibirPergunta("Deseja registrar o estoque inicial deste produto?");
                if (dr == DialogResult.Yes)
                {
                    MovProdutos mov = new MovProdutos();
                    mov.txtCNPJ.Text = lstFornecedores.Items[0].ToString();
                    mov.txtCodBarras.Text = txtCodBarras.Text;
                    cont.AdicionarForm(mov);
                }
            }
            catch (Exception ex)
            {
                MsgAvancado.ExibirErro(ex, "Não foi possível fazer o cadastro");
                if (cadastrouProduto || cadastrouRelacao)
                {
                    try
                    {
                        if (cadastrouRelacao)
                            dbctrl.Ler("DELETE FROM tbProduto WHERE ProdutoID = " + produtoId.ToString() + Environment.NewLine
                                + "DELETE FROM tbFornecedorProduto WHERE ProdutoID = " + produtoId.ToString());
                        else
                            dbctrl.Ler("DELETE FROM tbFornecedorProduto WHERE ProdutoID = " + produtoId.ToString());
                    }
                    catch
                    {
                        MsgAvancado.ExibirErro(ex, "Não foi possível desfazer as alterações no banco de dados.");
                    }
                }
            }
        }

        private T Converter<T>(object txt)
        {
            return (T)Convert.ChangeType(txt, typeof(T));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!txtCNPJ.MaskFull)
                MsgAvancado.ExibirErroValidacao("CNPJ incompleto!");
            else
            {
                if (!Validar.CNPJ(txtCNPJ.MaskedTextProvider.ToString(false, false)))
                {
                    MsgAvancado.ExibirErroValidacao("Este CNPJ não existe!");
                    return;
                }
                ControladorBD dbctrl = new ControladorBD();
                long cnpj = Converter<long>(txtCNPJ.MaskedTextProvider.ToString(false, false));
                SqlParameter[] p = { new SqlParameter("@forn", cnpj) };
                try
                {
                    int id = dbctrl.Contar<int>("SELECT FornecedorID FROM tbFornecedor WHERE CNPJ = @forn", p);
                    lstFornecedores.Items.Add(txtCNPJ.Text);
                    forns.Add(cnpj, id);
                }
                catch
                {
                    MsgAvancado.ExibirErroValidacao("O fornecedor " + txtCNPJ.Text + " não está cadastrado!");
                }
            }
        }

        private void lnkConsulta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cont.AdicionarForm(new ListaFornecedores());
        }

        private void lnkCadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cont.AdicionarForm(new CadastroFornecedores());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmContainer cont = frmContainer.TheContainer;
            cont.btnCancelar_Click(sender, e);
        }
    }
}
