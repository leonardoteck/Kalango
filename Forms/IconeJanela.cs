using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalango
{
    public partial class IconeJanela : UserControl
    {
        public IconeJanela()
        {
            InitializeComponent();
        }
        
        private void IconeJanela_MouseEnter(object sender, EventArgs e)
        {
            btnFecha.Visible = true;
        }
        
        private void btnFecha_Click(object sender, EventArgs e)
        {
            frmContainer cont = frmContainer.TheContainer;
            cont.Fechar(this);
        }

        private void imgIcone_Click(object sender, EventArgs e)
        {
            frmContainer cont = frmContainer.TheContainer;
            cont.Exibir(this);
        }
    }
}
