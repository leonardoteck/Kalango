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
    public partial class MenuConfigs : Form
    {
        public MenuConfigs()
        {
            InitializeComponent();
        }

        frmContainer cont = frmContainer.TheContainer;

        private void MenuConfigs_Load(object sender, EventArgs e)
        {
            frmContainer cont = frmContainer.TheContainer;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new CadastroUsuarios());
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new ListaUsuarios());
        }
    }
}
