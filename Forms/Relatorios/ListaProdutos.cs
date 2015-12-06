using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalango
{
    public partial class ListaProdutos : Form
    {
        public ListaProdutos()
        {
            InitializeComponent();
        }

        private void tbProdutoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbProdutoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDKalango2DataSet);

        }

        private void ListaProdutos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bDKalango2DataSet.tbProduto' table. You can move, or remove it, as needed.
            this.tbProdutoTableAdapter.Fill(this.bDKalango2DataSet.tbProduto);
            if (User.NivelAcesso > 2)
                tabControl1.TabPages[1].Hide();

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            tbProdutoBindingSource.RemoveFilter();
            if (!string.IsNullOrWhiteSpace(txtPesquisa.Text))
            {
                string filtro = "";
                switch (cbxPesquisa.SelectedIndex)
                {
                    case 0:
                        filtro += "codBarras = " + txtPesquisa.Text;
                        break;
                    case 1:
                        filtro += "descricao LIKE '%" + txtPesquisa.Text + "%'";
                        break;
                    case 2:
                        filtro += "localDeGuarda LIKE '%" + txtPesquisa.Text + "%'";
                        break;
                }
                tbProdutoBindingSource.Filter = filtro;
            }
        }

        private void ListaProdutos_FormClosing(object sender, FormClosingEventArgs e)
        {
            /// <TODO>
            /// Dá um jeito de verificar se há alterações que não foram salvas, e pergunta
            /// se o usuário quer ou não salvar, ou cancelar o fechamento do form.
            /// </TODO>
        }
    }
}
