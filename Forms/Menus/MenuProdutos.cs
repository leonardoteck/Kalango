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
    public partial class MenuProdutos : Form
    {
        public MenuProdutos()
        {
            InitializeComponent();
        }

        frmContainer cont = frmContainer.TheContainer;

        private void MenuProdutos_Load(object sender, EventArgs e)
        {
            if (User.NivelAcesso > 2)
                btnCadastrar.Visible = false;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new CadastroProdutos());
        }

        private void btnContrEstoque_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new MovProdutos());
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new ListaProdutos());
        }
    }
}
