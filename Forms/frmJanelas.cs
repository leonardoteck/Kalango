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
    public partial class frmJanelas : Form
    {
        public frmJanelas()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Cadastrar Fornecedores
            //Cadastrar Produtos
            //Cadastrar Usuários
            //Lista de Fornecedores
            //Lista de Produtos
            //Lista de Usuários
            //Movimentação de Estoque
            //PEPS, UEPS e MPM
            frmContainer cont = frmContainer.TheContainer;
            switch ((string)listBox1.SelectedItem)
            {
                case "Cadastrar Fornecedores":
                    cont.AdicionarForm(new CadastroFornecedores());
                    break;
                case "Cadastrar Produtos":
                    cont.AdicionarForm(new CadastroProdutos());
                    break;
                case "Cadastrar Usuários":
                    cont.AdicionarForm(new CadastroUsuarios());
                    break;
                case "Lista de Fornecedores":
                    cont.AdicionarForm(new ListaFornecedores());
                    break;
                case "Lista de Produtos":
                    cont.AdicionarForm(new ListaProdutos());
                    break;
                case "Lista de Usuários":
                    cont.AdicionarForm(new ListaUsuarios());
                    break;
                case "Movimentação de Estoque":
                    cont.AdicionarForm(new MovProdutos());
                    break;
                case "PEPS, UEPS e MPM":
                    cont.AdicionarForm(new Ficha());
                    break;
            }
            this.Close();
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmJanelas_Load(object sender, EventArgs e)
        {

            if (User.NivelAcesso > 1)
            {
                listBox1.Items.RemoveAt(7);
                listBox1.Items.RemoveAt(5);
                listBox1.Items.RemoveAt(2);
            }
            if (User.NivelAcesso > 2)
            {
                listBox1.Items.RemoveAt(1);
                listBox1.Items.RemoveAt(0);
            }
        }
    }
}
