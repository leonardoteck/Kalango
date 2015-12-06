using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExceptionHandler;

namespace Kalango
{
    public partial class CadastroUsuarios : Form
    {
        public CadastroUsuarios()
        {
            InitializeComponent();
        }

        string userName = "";
        ControladorBD dbctrl = new ControladorBD();

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

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (TaErrado(txtNome.Text))
            {
                txtNome.Text = Corrigir(txtNome.Text);
                txtNome.SelectionStart = txtNome.Text.Length;
            }

            GerarUsername();
        }
        
        private void txtSobrenome_TextChanged(object sender, EventArgs e)
        {
            if (TaErrado(txtSobrenome.Text))
            {
                txtSobrenome.Text = Corrigir(txtSobrenome.Text);
                txtSobrenome.SelectionStart = txtSobrenome.Text.Length;
            }

            GerarUsername();
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            txtNome.Text = Case(txtNome.Text);
        }

        private void txtSobrenome_Leave(object sender, EventArgs e)
        {
            txtSobrenome.Text = Case(txtSobrenome.Text);
        }

        private bool TaErrado(string texto)
        {
            foreach (char c in texto)
                if (!char.IsLetter(c))
                    return true;
            return false;
        }

        private string Corrigir(string texto)
        {
            if (!string.IsNullOrEmpty(texto))
            {
                List<char> textoCorrigido = texto.ToCharArray().ToList();
                int i = 0;
                while (i < textoCorrigido.Count)
                {
                    if (!char.IsLetter(textoCorrigido[i]))
                        textoCorrigido.Remove(textoCorrigido[i]);
                    i++;
                }
                return new string(textoCorrigido.ToArray());
            }
            else
                return "";
        }

        private string Case(string texto)
        {
            if (!string.IsNullOrEmpty(texto))
            {
                texto = char.ToUpper(texto[0]).ToString() + texto.Substring(1).ToLower();
            }
            return texto;
        }

        private void GerarUsername()
        {
            if (!string.IsNullOrEmpty(txtNome.Text))
                userName = txtNome.Text.ToLower();
            else
                userName = "";

            if (!string.IsNullOrEmpty(txtSobrenome.Text))
                userName += txtSobrenome.Text.Substring(0, 1).ToUpper() 
                     + txtSobrenome.Text.Substring(1, txtSobrenome.Text.Length - 1).ToLower();
            else
            {
                userName = "";
                if (!string.IsNullOrEmpty(txtNome.Text))
                    userName = txtNome.Text.ToLower();
            }

            if (!string.IsNullOrEmpty(txtSobrenome.Text) && !string.IsNullOrEmpty(txtNome.Text))
            {
                SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@nome", txtNome.Text.ToLower()),
                    new SqlParameter("@sobre", txtSobrenome.Text.ToLower())
                };

                DataTable usuarios = new DataTable();                
                try
                {
                    usuarios = dbctrl.Ler(@"SELECT TOP(1) login
                                                  FROM tbUsuarios
                                                  WHERE LOWER(nome) = @nome
                                                  AND LOWER(sobrenome) = @sobre
                                                  ORDER BY UsuarioID DESC", p);
                }
                catch (Exception ex)
                {
                    MsgAvancado.ExibirErro(ex, "Não foi possível conectar-se ao banco de dados");
                    return;
                }

                if (usuarios.Rows.Count > 0)
                {
                    Regex regex = new Regex(@"(\d+)$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
                    Match match = regex.Match((string)usuarios.Rows[usuarios.Rows.Count - 1][0]);
                    if (match.Success)
                    {
                        int num = int.Parse(match.Groups[0].Value);
                        userName += (num + 1).ToString();
                    }
                    else
                    {
                        userName += 2.ToString();
                    }
                }
            }

            txtNomeUsuario.Text = userName;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmContainer cont = frmContainer.TheContainer;
            cont.btnCancelar_Click(sender, e);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtSobrenome.Text = "";
            txtSenha.Text = "";
            rdbOp.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length < 2)
            {
                MsgAvancado.ExibirErroValidacao("Nome muito curto!");
                return;
            }
            else if (txtSobrenome.Text.Length < 2)
            {
                MsgAvancado.ExibirErroValidacao("Sobrenome muito curto!");
                return;
            }
            else if (txtSenha.Text.Length < 6)
            {
                MsgAvancado.ExibirErroValidacao("Senha muito curta!");
                return;
            }

            CryptoServiceProvider crypt = new CryptoServiceProvider(CryptoProcess.GenerateHash);
            string hash = crypt.DoWork(txtSenha.Text);

            byte nivel = 3;
            if (rdbTa.Checked)
                nivel = 2;
            else if (rdbGe.Checked)
                nivel = 1;

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@Login", userName),
                new SqlParameter("@Senha", hash),
                new SqlParameter("@nivel", nivel),
                new SqlParameter("@Nome", txtNome.Text),
                new SqlParameter("@Sobrenome", txtSobrenome.Text)
            };

            try
            {
                dbctrl.Alterar("INSERT INTO tbUsuarios VALUES(@Login, @Senha, @nivel, @Nome, @Sobrenome)", p);
            }
            catch (Exception ex)
            {
                MsgAvancado.ExibirErro(ex, "Não foi possível conectar-se ao banco de dados");
                return;
            }

            MsgAvancado.ExibirInformacao("Usuário cadastrado com sucesso!");
        }
    }
}
