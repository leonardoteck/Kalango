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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        Point mv = new Point(); // variável de auxilio

        private void SplashScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return; // só vai fazer algo se clicar com o botão esquerdo
            mv.X = Left - MousePosition.X; // pega a diferença da posição do form para o cursor
            mv.Y = Top - MousePosition.Y;  // leia acima ^
        }

        private void SplashScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return; // vide linha 24
            Left = mv.X + MousePosition.X; // soma a nova posição do cursor posição da variavel de auxilio
            Top = mv.Y + MousePosition.Y;  // e consequentemente altera a posição do form conforme a do cursor
        }

        bool cancelar = false;
        ExceptionHandler.MsgSingleControl msg;

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            msg = new ExceptionHandler.MsgSingleControl(lblCarregando);
            
            ControladorBD.StringConexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="
                + Environment.CurrentDirectory +
                @"\BDKalango2.mdf;Integrated Security=True";
            
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += TestarConexaoAsync;
            bw.RunWorkerCompleted += PosTesteConexao;
            bw.RunWorkerAsync();
            msg.DefinirMensagem("Conectando-se ao banco de dados", ExceptionHandler.MsgSingleControl.TipoMensagem.Normal);
            msg.RodandoCarregamento = true;
        }


        private void TestarConexaoAsync(object sender, DoWorkEventArgs e)
        {
            ControladorBD ctrlbd = new ControladorBD();
            for (int i = 0; i < 3; i++)
            {
                if (cancelar)
                    break;
                try
                {
                    e.Result = ctrlbd.TestarConexao();
                    if (e.Result != null)
                        break;
                }
                catch
                {

                }
            }
        }

        void PosTesteConexao(object sender, RunWorkerCompletedEventArgs e)
        {
            msg.RodandoCarregamento = false;
            progressBar1.Enabled = false;
            if (cancelar)
                Application.Exit();
            if (e.Result == null)
            {
                Login log = new Login();
                log.Show();
                Hide();
            }
            else
            {
                ExceptionHandler.MsgAvancado.ExibirErro((Exception)e.Result, "Não foi possível conectar ao banco de dados");
                Application.Exit();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            cancelar = true;
            msg.DefinirMensagem("Cancelando", ExceptionHandler.MsgSingleControl.TipoMensagem.Normal);
            lblCarregando.Location = new Point(416, 217);
        }
    }
}
