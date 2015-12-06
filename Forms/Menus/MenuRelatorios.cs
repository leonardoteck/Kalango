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
    public partial class MenuRelatorios : Form
    {
        public MenuRelatorios()
        {
            InitializeComponent();
        }

        frmContainer cont = frmContainer.TheContainer;

        private void MenuRelatorios_Load(object sender, EventArgs e)
        {
            if (User.NivelAcesso > 1)
                button1.Visible = false;
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new ListaFornecedores());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new Ficha());
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new ListaProdutos());
        }
    }
}
