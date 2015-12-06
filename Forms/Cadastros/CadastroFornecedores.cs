using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Geocoding.Google;
using System.Data.SqlClient;
using ExceptionHandler;

namespace Kalango
{
    public partial class CadastroFornecedores : Form
    {
        public CadastroFornecedores()
        {
            InitializeComponent();
        }

        private void CadastroFornecedores_Load(object sender, EventArgs e)
        {
            frmContainer cont = frmContainer.TheContainer;
            btnCancelar.Click += cont.btnCancelar_Click;
            cbxPesquisa.Show();
            cbxPesquisa.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            foreach (Control grb in pnlForm.Controls)
                foreach (Control ctrl in grb.Controls)
                    if (ctrl.GetType() ==  typeof(TextBox))
                        ctrl.Text = "";
        }

        GoogleAddress[] addresses;
        bool pesquisaFeita;
        string endPesquisa;
        IEnumerable<string> ends;

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            endPesquisa = cbxPesquisa.Text + ", Brasil";
            bwPesquisaEnd.RunWorkerAsync();
            imgLoading.Visible = true;
            txtRazao.Focus();
        }

        void preencherEnds(int idx)
        {
            if (!pesquisaFeita) return;
            try
            {
                var endereco = addresses.Where(a => !a.IsPartialMatch).Select(a => a[GoogleAddressType.Route]).ToList();
                var cep = addresses.Where(a => !a.IsPartialMatch).Select(a => a[GoogleAddressType.PostalCode]).ToList();
                var bairro = addresses.Where(a => !a.IsPartialMatch).Select(a => a[GoogleAddressType.Unknown]).ToList();
                var cidade = addresses.Where(a => !a.IsPartialMatch).Select(a => a[GoogleAddressType.AdministrativeAreaLevel2]).ToList();
                var uf = addresses.Where(a => !a.IsPartialMatch).Select(a => a[GoogleAddressType.AdministrativeAreaLevel1]).ToList();
                var pais = addresses.Where(a => !a.IsPartialMatch).Select(a => a[GoogleAddressType.Country]).ToList();
                if (endereco[0] != null)
                    txtEndereco.Text = endereco.ElementAt(idx).LongName;
                if (cep[0] != null)
                    txtCEP.Text = cep.ElementAt(idx).LongName;
                if (bairro[0] != null)
                    txtBairro.Text = bairro.ElementAt(idx).LongName;
                if (cidade[0] != null)
                    txtCidade.Text = cidade.ElementAt(idx).LongName;
                if (uf[0] != null)
                    txtUF.Text = uf.ElementAt(idx).ShortName;
                if (pais[0] != null)
                    txtPais.Text = pais.ElementAt(idx).LongName;
            }
            catch { }
        }

        void preencherCbxPesquisa()
        {
            if (ends != null)
            {
                cbxPesquisa.Items.Clear();
                cbxPesquisa.Items.AddRange(ends.ToArray());
                cbxPesquisa.SelectedIndex = 0;
            }
        }

        private void cbxPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            preencherEnds(cbxPesquisa.SelectedIndex);
        }

        private void bwPesquisaEnd_DoWork(object sender, DoWorkEventArgs e)
        {
            if (string.IsNullOrEmpty(endPesquisa)) return;
            GoogleGeocoder geo = new GoogleGeocoder();
            var adds = geo.Geocode(endPesquisa);
            addresses = adds.ToArray();
            pesquisaFeita = true;
            if (addresses.Length > 0)
            {
                ends = from end in addresses select end.FormattedAddress;
            }
        }

        private void bwPesquisaEnd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            imgLoading.Visible = false;
            preencherEnds(0);
            preencherCbxPesquisa();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // validação
            bool valido = true;
            List<int> nullCtrls = new List<int>() {
                txtCEP.GetHashCode(),
                txtCel.GetHashCode(),
                txtEmail.GetHashCode()
            };
            bool alertado = false;
            foreach (Control grb in pnlForm.Controls)
                foreach (Control ctrl in grb.Controls)
                    if (ctrl.GetType() == typeof(TextBox))
                        if (string.IsNullOrWhiteSpace(((TextBox)ctrl).Text)
                            && !nullCtrls.Contains(ctrl.GetHashCode()))
                        {
                            if (!alertado)
                            {
                                MsgAvancado.ExibirErroValidacao("Preencha todos os controles que têm um asterisco ( * ) em cima!");
                                ctrl.Focus();
                                alertado = true;
                            }
                            valido = false;
                        }
            if (!Validar.CNPJ(txtCNPJ.Text) && !string.IsNullOrWhiteSpace(txtCNPJ.Text))
            {
                MsgAvancado.ExibirErroValidacao("O CNPJ informado não existe!");
                valido = false;
            }
            if (!Validar.InscricaoEstadual(txtInscEst.Text) && !string.IsNullOrWhiteSpace(txtInscEst.Text))
            {
                MsgAvancado.ExibirErroValidacao("A inscrição estadual informada não existe!");
                valido = false;
            }
            if (!Validar.Email(txtEmail.Text) && !string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MsgAvancado.ExibirErroValidacao("Digite um email válido!");
                valido = false;
            }
            ControladorBD dbctrl = new ControladorBD();
            try
            {
                int qt = dbctrl.Contar<int>("SELECT COUNT(*) FROM tbFornecedor WHERE CNPJ = " + txtCNPJ.Text);
                if (qt > 0)
                {
                    MsgAvancado.ExibirErroValidacao("Já há um fornecedor com o dado CNPJ cadastrado!");
                    valido = false;
                }
            }
            catch (Exception ex)
            {
                MsgAvancado.ExibirErro(ex, "Não foi possível conectar-se ao banco de dados");
            }
            if (!valido)
                return;

            // pegando os valores
            object[] valores = new object[13];
            try
            {
                valores[0] = txtRazao.Text;
                valores[1] = Converter<long>(txtInscEst.Text);
                valores[2] = Converter<int>(txtInscMun.Text);
                valores[3] = Converter<long>(txtCNPJ.Text);
                valores[4] = txtEndereco.Text;
                valores[5] = Converter<int>(txtNum.Text);
                valores[6] = txtCidade.Text;
                valores[7] = txtUF.Text;
                valores[8] = txtPais.Text;
                valores[9] = Converter<long>(txtTel.Text);
                valores[10] = Converter<long>(txtCel.Text);
                valores[11] = txtNome.Text;
                valores[12] = txtEmail.Text;
            }
            catch (Exception ex) {
                MsgAvancado.ExibirErro(ex, "Não foi possível fazer a leitura dos dados");
                return;
            }
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@razaoSocial", valores[0]),
                new SqlParameter("@inscEstadual", valores[1]),
                new SqlParameter("@inscMunicipal", valores[2]),
                new SqlParameter("@CNPJ", valores[3]),
                new SqlParameter("@endereco", valores[4]),
                new SqlParameter("@numEndereco", valores[5]),
                new SqlParameter("@cidade", valores[6]),
                new SqlParameter("@UF", valores[7]),
                new SqlParameter("@pais", valores[8]),
                new SqlParameter("@telefone", valores[9]),
                new SqlParameter("@celular", valores[10]),
                new SqlParameter("@nomeContato", valores[11]),
                new SqlParameter("@email", valores[12])
            };

            // contrução da query
            string query = @"INSERT INTO tbFornecedor (
            razaoSocial, inscEstadual, inscMunicipal, CNPJ, endereco, numEndereco, cidade, UF, pais, telefone, celular, nomeContato, email
            ) VALUES (
            @razaoSocial, @inscEstadual, @inscMunicipal, @CNPJ, @endereco, @numEndereco, @cidade, @UF, @pais, @telefone, @celular, @nomeContato, @email)";

            try
            { // tentativa de inserção
                dbctrl.LerEAlterar(query, paras);
                MsgAvancado.ExibirInformacao("Cadastro efetuado com SUCESSO!");
            }
            catch (Exception ex)
            {
                MsgAvancado.ExibirErro(ex, "Não foi possível fazer o cadastro");
            }
        }

        private T Converter<T>(string txt)
        { // converte os textos em outros tipos de dados
            return (T)Convert.ChangeType(txt, typeof(T));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmContainer cont = frmContainer.TheContainer;
            cont.btnCancelar_Click(sender, e);
        }
    }
}
