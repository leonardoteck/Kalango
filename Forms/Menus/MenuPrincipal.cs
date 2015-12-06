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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            if (User.NivelAcesso > 1)
                btnConfig.Visible = false;
            if (User.NivelAcesso > 2)
                btnCadastrar.Visible = false;
        }

        frmContainer cont = frmContainer.TheContainer;

        private void btnFechar_Click(object sender, EventArgs e)
        {
            cont.Fechar(this);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new MenuCadastros());
        }

        private void btnContrEstoque_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new MenuCtrlEst());
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new MenuProdutos());
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new MenuFornecedores());
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new MenuRelatorios());
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            cont.AdicionarForm(new MenuConfigs());
        }
    }
}