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
    public partial class MenuCadastros : Form
    {
        public MenuCadastros()
        {
            InitializeComponent();
        }

        private void MenuCadastros_Load(object sender, EventArgs e)
        {
            frmContainer cont = frmContainer.TheContainer;
        }

        frmContainer cont = frmContainer.TheContainer;

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new CadastroFornecedores());
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new CadastroProdutos());
        }
    }
}
