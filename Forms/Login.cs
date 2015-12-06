using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kalango
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        #region código para tirar a borda do form

        Point mv = new Point(); // variável de auxilio

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return; // só vai fazer algo se clicar com o botão esquerdo
            mv.X = Left - MousePosition.X; // pega a diferença da posição do form para o cursor
            mv.Y = Top - MousePosition.Y;  // leia acima ^
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return; // vide linha 27
            Left = mv.X + MousePosition.X; // soma a nova posição do cursor posição da variavel de auxilio
            Top = mv.Y + MousePosition.Y;  // e consequentemente altera a posição do form conforme a do cursor
        }

        // <!-- Adicional que coloca a borda verde em volta do form ;D --> //
        private void Login_Load(object sender, EventArgs e)
        {
            Graphics desenhista = CreateGraphics(); // criação do desenhista
            Pen caneta = new Pen(Color.DarkGreen, 2); // o desenhista precisa de caneta ou pincel
            Rectangle area = new Rectangle(1, 1, this.Size.Width - 2,
                this.Size.Height - 2); // o que será desenhado
            desenhista.DrawRectangle(caneta, area); // ordem de desenhar
            Update(); // atualiza para aparecer o desenho

            timer_Tick(sender, e); // chama o evento pra atualizar a label do horário
        }
        private void Login_Paint(object sender, PaintEventArgs e)
        {
            Pen caneta = new Pen(Color.DarkGreen, 2); // vide linhas 42 a 46
            Rectangle area = new Rectangle(1, 1, this.Size.Width - 2, this.Size.Height - 2);
            Graphics desenhista = CreateGraphics();
            desenhista.DrawRectangle(caneta, area);
        }
        // <!-- Fim código adicional --> //
        #endregion

        DataTable reader;
        DataRow linha;
        ControladorBD db = new ControladorBD();
        string senha; // senha registrada no banco de dados
        CryptoServiceProvider crypt = new CryptoServiceProvider(CryptoProcess.GenerateHash); // pra gerar o hash e comparar com a senha
        bool logarAposCarregamento;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (imgLoading.Visible)
            {
                logarAposCarregamento = true;
                lblAguarde.Visible = true;
                return; // não pode logar enquanto está carregando
            }
            if (textBoxesVazios()) return; // se tem textBox vazio, nem precisa prosseguir

            imgLoading.Visible = true; // vai gerar um hash, pode demorar
            string hash = crypt.DoWork(txtSenha.Text.Trim()); // geração do hash da senha digitada

            if (hash == senha) // se a senha está certa...
            {
                User.Nome = (string)linha[4]; //      pega a string da coluna de índice 3 pra configurar o objeto Usuário
                User.Sobrenome = (string)linha[5]; // pega a string da coluna de índice 4 ^
                User.Username = (string)linha[1]; //  pega a string da coluna de índice 0 ^
                User.NivelAcesso = (byte)linha[3]; // pega o byte da coluna de índice 2.. ^
                frmContainer cont = new frmContainer(); // novo form container pra exibir
                frmContainer.TheContainer = cont;
                cont.Show(); // exibe o form
                Close(); // esconde essa janela
            }
            else // se não...
            {
                lblIncorreto.Visible = true; // mostra a label dizendo que o login ou senha está incorreto
            }
            imgLoading.Visible = false;
        }

        private bool textBoxesVazios() // método para alertar o usuário e saber se tem textBox vazio
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Focus(); // foca no textBox
                txtUsuario.BackColor = Color.Khaki; // deixa o fundo cor cáqui pra chamar atenção
                return true;
            }
            if (txtSenha.Text == "")
            {
                txtSenha.Focus(); // leia acima ^
                txtSenha.BackColor = Color.Khaki;
                btnOlho.BackColor = Color.Khaki;
                return true;
            }
            return false;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try // MIL TRETAS PODEM ACONTECER AQUI
            {
                SqlParameter[] pars = { new SqlParameter("@Login", txtUsuario.Text.Trim()) };
                reader = db.Ler(
                    stringSQL: "SELECT * FROM tbUsuarios WHERE login = @Login",
                    parametros: pars
                    ); // retorna uma tabela com os resultados da query
                if (reader.Rows.Count > 0) // se o login e a senha estão corretos, os resultados terão uma linha
                {
                    linha = reader.Rows[0]; // pega a primeira linha da tabela resultante
                    senha = linha[2].ToString(); // pega a string na segunda coluna da linha
                }
            }
            catch (Exception ex)
            { // caso ocorra um erro....
                ExceptionHandler.MsgAvancado.ExibirErro(ex, "Ops, ocorreu um erro. Por favor, contate um desenvolvedor.");
            }
        }

        bool btnLoginFocado = false;

        private void btnLogin_Enter(object sender, EventArgs e)
        {
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (btnLogin.Focused && !btnLoginFocado)
            { //  se clicou no login sem digitar a senha
                btnLoginFocado = true;
                textBoxesVazios(); // deve-se ver se a senha não foi digitada antes
            }
            else if (!btnLogin.Focused && btnLoginFocado)
                return;
            if (txtUsuario.Text.Length < 3) return; // se é menor que 3, ta errado, nem precisa prosseguir
            imgLoading.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            imgLoading.Visible = false;
            lblAguarde.Visible = false;
            if (logarAposCarregamento)
                btnLogin_Click(sender, new EventArgs());
        }

        private void btnSai_Click(object sender, EventArgs e)
        {
            Application.Exit(); // finaliza o sistema
        }

        bool pisca = false; // determina quando os 2 pontos aparecem na label de hora hora
        
        private void timer_Tick(object sender, EventArgs e) // 
        {
            string separador; // separa a hora dos minutos na label
            if (pisca)
                separador = ":";
            else
                separador = " ";

            string minuto = DateTime.Now.Minute < 10 ? // estrutura if condensada, pra ver se os minutos
                            "0" + DateTime.Now.Minute.ToString() : // são menores que 10, pra colocar um
                            DateTime.Now.Minute.ToString(); // 0 antes caso sejam.

            txtDiaHora.Text = DateTime.Now.ToShortDateString() + " - " // formatação da label com 
                            + DateTime.Now.Hour.ToString() + separador // a data e hora atual
                            + minuto;
            pisca = !pisca;
        }

        private void btnMinimiza_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // minimiza a janela
        }

        private void btnOlho_MouseDown(object sender, MouseEventArgs e)
        {
            btnOlho.BackgroundImage = Properties.Resources.olhoAberto; // muda o icone do botão
            txtSenha.UseSystemPasswordChar = false; // exibe a senha
        }

        private void btnOlho_MouseUp(object sender, MouseEventArgs e)
        {
            btnOlho.BackgroundImage = Properties.Resources.olhoFechado; // muda o icone do botão
            txtSenha.UseSystemPasswordChar = true; // esconde a senha
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            lblIncorreto.Visible = false; // o usuário vai alterar, ele já sabe que está errado 
            txtUsuario.BackColor = Color.White; // vide acima
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            lblIncorreto.Visible = false; // vide evento acima
            txtSenha.BackColor = Color.White;
            btnOlho.BackColor = Color.White;
        }
    }
}
