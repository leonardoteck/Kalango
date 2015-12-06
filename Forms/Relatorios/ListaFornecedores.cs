using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExceptionHandler;

namespace Kalango
{
    public partial class ListaFornecedores : Form
    {
        public ListaFornecedores()
        {
            InitializeComponent();
        }
        
        private void ListaFornecedores_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bDKalango2DataSet.tbFornecedor' table. You can move, or remove it, as needed.
            this.tbFornecedorTableAdapter.Fill(this.bDKalango2DataSet.tbFornecedor);
            cbxPesquisa.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            if (User.NivelAcesso > 2)
                tabControl1.TabPages[1].Hide();
        }

        private void tbFornecedorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbFornecedorBindingSource.EndEdit();
            
            this.tableAdapterManager.UpdateAll(this.bDKalango2DataSet);

        }
        
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            tbFornecedorBindingSource.RemoveFilter();
            if (!string.IsNullOrWhiteSpace(txtPesquisa.Text))
            {
                string filtro = "";
                switch (cbxPesquisa.SelectedIndex)
                {
                    case 0:
                        filtro += "razaoSocial LIKE '%" + txtPesquisa.Text + "%'";
                        break;
                    case 1:
                        filtro += "inscEstadual = " + txtPesquisa.Text;
                        break;
                    case 2:
                        filtro += "inscMunicipal = " + txtPesquisa.Text;
                        break;
                    case 3:
                        filtro += "CNPJ = " + txtPesquisa.Text;
                        break;
                    case 4:
                        filtro += "endereco LIKE '%" + txtPesquisa.Text + "%'";
                        break;
                    case 5:
                        filtro += "cidade LIKE '%" + txtPesquisa.Text + "%'";
                        break;
                    case 6:
                        filtro += "UF LIKE '%" + txtPesquisa.Text + "%'";
                        break;
                    case 7:
                        filtro += "pais LIKE '%" + txtPesquisa.Text + "%'";
                        break;
                }
                tbFornecedorBindingSource.Filter = filtro;
            }
        }

        private void ListaFornecedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            /// <TODO>
            /// Dá um jeito de verificar se há alterações que não foram salvas, e pergunta
            /// se o usuário quer ou não salvar, ou cancelar o fechamento do form.
            /// </TODO>
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //  Produtos disponíveis
            //  Produtos fornecidos
            //  Compras
            ControladorBD dbctrl = new ControladorBD();
            
            string query = "";
            if (comboBox1.SelectedIndex == 0)
                query = "SELECT descricao AS [Descrição], QuantidadeAtual AS [Quantidade Atual], (TotalAtual / QuantidadeAtual) AS [Preço], TotalAtual AS [Total] FROM tbLote INNER JOIN tbProduto ON tbLote.ProdutoID = tbProduto.ProdutoID WHERE QuantidadeAtual > 0 AND FornecedorID = 10";
            else if (comboBox1.SelectedIndex == 1)
                query = "SELECT * FROM tbProduto INNER JOIN tbFornecedorProduto ON tbProduto.ProdutoID = tbFornecedorProduto.ProdutoID WHERE FornecedorID = 10";
            else
                query = "SELECT * FROM tbMovimentacaoEst INNER JOIN tbLote ON tbMovimentacaoEst.MovimentacaoEstID = tbLote.MovimentacaoEstID WHERE FornecedorID = 10";
            dataGridView1.DataSource = dbctrl.Ler(query);
        }
    }
}
