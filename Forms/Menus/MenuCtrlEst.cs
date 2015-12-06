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
    public partial class MenuCtrlEst : Form
    {
        public MenuCtrlEst()
        {
            InitializeComponent();
        }

        frmContainer cont = frmContainer.TheContainer;

        private void btnCtrlEst_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new MovProdutos());
        }

        private void btnPeps_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new Ficha());
        }

        private void MenuCtrlEst_Load(object sender, EventArgs e)
        {
            if (User.NivelAcesso > 1)
                btnPeps.Visible = false;
        }
    }
}
