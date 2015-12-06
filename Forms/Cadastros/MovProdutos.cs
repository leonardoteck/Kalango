using System;
using System.Windows.Forms;
using ExceptionHandler;
using System.Data;
using System.Data.SqlClient;

namespace Kalango
{
    public partial class MovProdutos : Form
    {
        public MovProdutos()
        {
            InitializeComponent();
        }

        frmContainer cont = frmContainer.TheContainer;

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
        }
        
        private void MovProdutos_Load(object sender, EventArgs e)
        {
            btnCancelar.Click += cont.btnCancelar_Click;
            if (User.NivelAcesso > 2)
                lnkCadProd.Visible = false;
        }

        private void rdbEntrada_CheckedChanged(object sender, EventArgs e)
        {
            rdbChange();
        }

        private void rdbSaida_CheckedChanged(object sender, EventArgs e)
        {
            rdbChange();
        }

        private void rdbBaixa_CheckedChanged(object sender, EventArgs e)
        {
            rdbChange();
        }

        private void rdbChange()
        {
            if (rdbEntrada.Checked)
            {
                txtCNPJ.Enabled = true;
                nudFrete.Enabled = true;
                nudValor.Enabled = true;
            }
            else if (rdbSaida.Checked)
            {
                txtCNPJ.Enabled = false;
                txtCNPJ.Text = "";
                nudFrete.Enabled = false;
                nudFrete.Value = 0;
                nudValor.Enabled = true;
            }
            else
            {
                txtCNPJ.Enabled = false;
                txtCNPJ.Text = "";
                nudFrete.Enabled = false;
                nudFrete.Value = 0;
                nudValor.Enabled = false;
                nudValor.Value = 0;
            }
        }

        private ControladorBD dbctrl = new ControladorBD();
        DataTable res = new DataTable();

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.GetHashCode() == tabControl1.TabPages[0].GetHashCode())
            {
                #region validações
                long cod;
                if (!long.TryParse(txtCodBarras.Text, out cod) || !Validar.CodBarras(txtCodBarras.Text)) 
                {
                    MsgAvancado.ExibirErroValidacao("Código de barras inválido!");
                    return;
                }
                if (txtCNPJ.Enabled && (!long.TryParse(txtCNPJ.Text, out cod) || !Validar.CNPJ(txtCNPJ.Text)))
                {
                    MsgAvancado.ExibirErroValidacao("CNPJ inválido!");
                    return;
                }
                #endregion
                try
                {
                    DataTable res = dbctrl.Ler("SELECT ProdutoID from tbProduto WHERE codBarras = " + txtCodBarras.Text);
                    if (res.Rows.Count == 0)
                    {
                        MsgAvancado.ExibirErroValidacao("Código de barras inválido!");
                        return;
                    }
                    int produtoId = (int)res.Rows[0][0];
                    int fornecedorId = 0;

                    #region checar relação fornecedor-produto
                    if (txtCNPJ.Enabled)
                    {
                        res = dbctrl.Ler("SELECT FornecedorID from tbFornecedor WHERE CNPJ = " + txtCNPJ.Text);
                        if (res.Rows.Count == 0)
                        {
                            MsgAvancado.ExibirErroValidacao("CNPJ inválido!");
                            return;
                        }
                        fornecedorId = (int)res.Rows[0][0];

                        res = dbctrl.Ler("SELECT * FROM tbFornecedorProduto WHERE FornecedorID = " +
                            fornecedorId.ToString() + " AND ProdutoID = " + produtoId.ToString());
                        if (res.Rows.Count == 0)
                        {
                            MsgAvancado.ExibirErroValidacao("Este produto não é fornecido por este fornecedor");
                            return;
                        }
                    }
                    #endregion

                    SqlParameter[] p = new SqlParameter[]
                    {
                        new SqlParameter("@ProdutoID", produtoId),
                        new SqlParameter("@FornecedorID", fornecedorId),
                        new SqlParameter("@Valor", nudValor.Value),
                        new SqlParameter("@Qt", (double)nudQt.Value),
                        new SqlParameter("@Frete", nudFrete.Value)
                    };

                    if (rdbEntrada.Checked)
                    {
                        string query = "EntradaEstoque @ProdutoID, @FornecedorID, @Valor, @Qt, @Frete";
                        dbctrl.LerEAlterar(query, p);
                    }
                    if (rdbBaixa.Checked)
                        dbctrl.LerEAlterar("BaixaEstoque @ProdutoID, @Qt", p);
                    if (rdbSaida.Checked)
                        dbctrl.LerEAlterar("Venda @ProdutoID, @Qt, @Valor", p);
                    MsgAvancado.ExibirInformacao("Movimentação realizada com sucesso!");
                }
                catch (Exception ex)
                {
                    MsgAvancado.ExibirErro(ex, "Não foi possível conectar-se ao banco de dados.");
                }
            }
            else
            {
                if (groupBox4.Enabled && nudQtd.Value > 0)
                {
                    int id = (int)res.Rows[dataGridView.SelectedCells[0].RowIndex][0];
                    string query = "";
                    if (rdbCompra.Checked)
                        query = "DevolucaoCompra @id, @qt";
                    else
                        query = "DevolucaoVenda @id, @qt";
                    SqlParameter[] p = new SqlParameter[]
                    {
                        new SqlParameter("@id", id),
                        new SqlParameter("@qt", nudQtd.Value)
                    };
                    dbctrl.Alterar(query, p);
                    MsgAvancado.ExibirInformacao("Devolução efetuada com sucesso!");
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!txtData.MaskCompleted) return;

            string query;

            if (rdbCompra.Checked)
                query = @"SELECT LoteID, Preco AS [Preço], Quantidade, Total, 
                          CONVERT(VARCHAR(10), Data, 103) AS Data, descricao AS [Descrição]
                          FROM  tbMovimentacaoEst m
                          INNER JOIN tbLote l ON m.MovimentacaoEstID = l.MovimentacaoEstID
                          INNER JOIN tbProduto p ON p.ProdutoID = m.ProdutoID
                          WHERE CONVERT(VARCHAR(10), m.Data, 103) = '" + txtData.Text + @"'
                          AND (m.TipoMovimentacaoEstID = 1 OR m.TipoMovimentacaoEstID = 6)
                          AND m.ProdutoID = p.ProdutoID AND l.QuantidadeAtual > 0";
            else
                query = @"SELECT VendaID, Preco AS [Preço], Quantidade, Total, Data, descricao AS [Descrição]
                          FROM tbVenda v
                          INNER JOIN tbProduto p ON p.ProdutoID = v.ProdutoID
                          WHERE CONVERT(VARCHAR(10), v.Data, 103) = '" + txtData.Text + @"' AND v.ProdutoID = p.ProdutoID";

            try
            {
                res = dbctrl.Ler(query);
                dataGridView.DataSource = res;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[5].Width = 200;

                groupBox4.Enabled = true;
            }
            catch (Exception ex)
            {
                MsgAvancado.ExibirErro(ex, "Não foi possível consultar o banco de dados");
            }
        }

        #region atalhos
        private void lnkCadProd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cont.AdicionarForm(new CadastroProdutos());
        }

        private void lnkConsForn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cont.AdicionarForm(new ListaFornecedores());
        }

        private void lnkLstProd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cont.AdicionarForm(new ListaProdutos());
        }
        #endregion
        
        private void nudValor_ValueChanged(object sender, EventArgs e)
        {
            calculaTotal();
        }

        private void nudQt_ValueChanged(object sender, EventArgs e)
        {
            calculaTotal();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            calculaTotal();
        }

        private void calculaTotal()
        {
            txtTotal.Text = String.Format("{0:C}", nudQt.Value * nudValor.Value + nudFrete.Value);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
