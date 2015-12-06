using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Kalango
{
    public partial class frmContainer : Form
    {
        public frmContainer()
        {
            InitializeComponent();
        }

        private List<Form> forms = new List<Form>();
        private List<IconeJanela> icones = new List<IconeJanela>();
        public static frmContainer TheContainer;
        private bool login = false;

        public void AdicionarForm(Form frm)
        {
            IEnumerable<Form> frmAbertos = from form in forms where form.Text == frm.Text select form;
            if (frmAbertos.Count() > 0)
                Exibir(icones[forms.IndexOf(frmAbertos.First())]);
            else
            {
                frm.MdiParent = this;
                frm.Size = Screen.PrimaryScreen.Bounds.Size;
                forms.Add(frm);
                frm.Show();
                IconeJanela icone = new IconeJanela();
                Rectangle rect = new Rectangle(frm.Location, frm.Size);
                Bitmap bitmap = new Bitmap(frm.Width, frm.Height);
                frm.DrawToBitmap(bitmap, rect);
                icone.imgIcone.BackgroundImage = bitmap;
                icone.Margin = new Padding(15);
                icone.lblTitulo.Text = frm.Text;
                icones.Add(icone);
                flpJanelas.Controls.Add(icone);
                TrocarCores(forms.Count - 1);
            }
        }

        private void VisibleComponents(string frmText)
        {
            btnVoltar.Visible = frmText != "Menu Principal";
            rightPanel.Visible = frmText.StartsWith("Menu");
        }

        public void Fechar(IconeJanela icon)
        {
            int index = icones.FindIndex(icn => icn == icon);
            if (index > -1) Remover(index);
        }

        public void Fechar(Form form)
        {
            int index = forms.FindIndex(frm => frm == form);
            if (index > -1) Remover(index);
        }

        public void Exibir(IconeJanela icon)
        {
            int index = icones.FindIndex(icn => icn == icon);
            if (index > -1)
            {
                forms[index].BringToFront();
                TrocarCores(index);
            }
        }

        private void TrocarCores(int index)
        {
            VisibleComponents(forms[index].Text);
            for (int i = 0; i < forms.Count; i++)
                icones[i].BackColor = Color.DarkSlateGray;
            icones[index].BackColor = Color.Teal;
        }

        private void Remover(int index)
        {
            if (forms.Count == 1)
            {
                DialogResult dlg = MessageBox.Show("Deseja sair do sistema?",
                    "Saindo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                    Application.Exit();
            }
            else
            {
                forms[index].Close();
                flpJanelas.Controls.Remove(icones[index]);
                forms.RemoveAt(index);
                icones.RemoveAt(index);
                Exibir(icones.Last());
            }
        }

        private void frmContainer_Load(object sender, EventArgs e)
        {
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Size.Width + 4, 
                Screen.PrimaryScreen.Bounds.Size.Height + 4);
            this.Location = new Point(-2, -2);
            AdicionarForm(new MenuPrincipal());

            lblInitials.Text = User.Initials;
            lblNome.Text = User.Nome + " " + User.Sobrenome;

            flpJanelas.Location = new Point(0, Height);
            btnAbrePainel.Location = new Point(btnAbrePainel.Location.X, Height - 38);

            if (User.NivelAcesso > 1)
                btnConfigs.Visible = false;
        }

        int time = 500;
        int total = 300;
        bool aberto = false;

        private void btnAbrePainel_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!aberto)
            {
                if (Size.Height - flpJanelas.Location.Y < 176)
                {
                    flpJanelas.Location = new Point(0, ((time * 176) / total) + (Height - 176));
                    btnAbrePainel.Location = new Point(btnAbrePainel.Location.X, flpJanelas.Location.Y - 38);
                }
                else
                {
                    flpJanelas.Location = new Point(0, Size.Height - 176);
                    timer.Stop();
                    aberto = !aberto;
                }
                time -= 10;
            }
            else
            {
                time += 10;
                if (Size.Height > flpJanelas.Location.Y)
                {
                    flpJanelas.Location = new Point(0, ((time * 176) / total) + (Height - 176));
                    btnAbrePainel.Location = new Point(btnAbrePainel.Location.X, flpJanelas.Location.Y - 38);
                }
                else
                {
                    flpJanelas.Location = new Point(0, Size.Height);
                    timer.Stop();
                    aberto = !aberto;
                }
            }
        }

        private void btnAbrePainel_Leave(object sender, EventArgs e)
        {
            if (Cursor.Position.Y < flpJanelas.Location.Y && aberto)
                btnAbrePainel_Click(sender, e);
        }

        public void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            int index = forms.FindIndex(frm => frm == ActiveMdiChild);
            if (index > 0)
            {
                if (forms[index].Text.StartsWith("Menu"))
                    Remover(index);
                else
                {
                    DialogResult dlg = MessageBox.Show("Fechar formulário?", "Voltando...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                        Remover(index);
                    else
                    {
                        forms[index - 1].BringToFront();
                        TrocarCores(index - 1);
                    }
                }
            }
        }

        public void btnCancelar_Click(object sender, EventArgs e)
        {
            var pnl = ActiveMdiChild.Controls.Find("pnlForm", true);
            if (pnl.Length <= 0) return;
            foreach (Control grb in pnl[0].Controls)
                foreach (Control ctrl in grb.Controls)
                {
                    if (ctrl.GetType() == typeof(TextBox))
                    {
                        if (!string.IsNullOrWhiteSpace(ctrl.Text))
                            if (MessageBox.Show("Deseja cancelar?", "Cancelando...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Remover(forms.FindIndex(frm => frm == ActiveMdiChild));
                                return;
                            }
                    }
                    else if (ctrl.GetType() == typeof(NumericUpDown))
                        if (((NumericUpDown)ctrl).Value == 0)
                            if (MessageBox.Show("Deseja cancelar?", "Cancelando...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Remover(forms.FindIndex(frm => frm == ActiveMdiChild));
                                return;
                            }
                }
        }

        private void btnMinimiza_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void frmContainer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (login) return;
            DialogResult dlg = MessageBox.Show("Deseja sair do sistema?", "Saindo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.No)
                e.Cancel = true;
            else
                Application.Exit();
        }

        private void btnJanelas_Click(object sender, EventArgs e)
        {
            frmJanelas frm = new frmJanelas();
            frm.ShowDialog();
        }

        private void btnConfigs_Click(object sender, EventArgs e)
        {
            AdicionarForm(new MenuConfigs());
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fazer logoff?", "Saindo...", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                login = true;
                Login log = new Login();
                log.Show();
                Close();
            }

        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            frmAjuda frm = new frmAjuda();
            frm.nomejanela = ActiveMdiChild.Text;
            frm.ShowDialog();
        }

        private void btnSobre_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kalango ERP - Controle de Estoque. Produzido por The Internships Ltd. © 2015 - TODOS OS DIREITOS RESERVADOS.", "Sobre Kalango", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}