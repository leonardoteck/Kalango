namespace Kalango
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiaHora = new System.Windows.Forms.Label();
            this.btnSai = new System.Windows.Forms.Button();
            this.btnMinimiza = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblIncorreto = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.imgLoading = new System.Windows.Forms.PictureBox();
            this.btnOlho = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblAguarde = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 385);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Kalango.Properties.Resources.logo_Kalango;
            this.pictureBox1.Location = new System.Drawing.Point(12, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 320);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(257, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "BEM-VINDO!";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(261, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Usuário:";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(265, 166);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(297, 27);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.White;
            this.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(264, 239);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(297, 27);
            this.txtSenha.TabIndex = 2;
            this.txtSenha.UseSystemPasswordChar = true;
            this.txtSenha.TextChanged += new System.EventHandler(this.txtSenha_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(261, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Senha:";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            // 
            // txtDiaHora
            // 
            this.txtDiaHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDiaHora.BackColor = System.Drawing.Color.Transparent;
            this.txtDiaHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaHora.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtDiaHora.Location = new System.Drawing.Point(265, 354);
            this.txtDiaHora.Name = "txtDiaHora";
            this.txtDiaHora.Size = new System.Drawing.Size(297, 22);
            this.txtDiaHora.TabIndex = 41;
            this.txtDiaHora.Text = "12/07/2015 - 13:27";
            this.txtDiaHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtDiaHora.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.txtDiaHora.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            // 
            // btnSai
            // 
            this.btnSai.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSai.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSai.ForeColor = System.Drawing.Color.White;
            this.btnSai.Location = new System.Drawing.Point(567, 9);
            this.btnSai.Name = "btnSai";
            this.btnSai.Size = new System.Drawing.Size(25, 25);
            this.btnSai.TabIndex = 4;
            this.btnSai.Text = "X";
            this.btnSai.UseVisualStyleBackColor = false;
            this.btnSai.Click += new System.EventHandler(this.btnSai_Click);
            // 
            // btnMinimiza
            // 
            this.btnMinimiza.BackColor = System.Drawing.Color.DarkGreen;
            this.btnMinimiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimiza.Font = new System.Drawing.Font("Lucida Console", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimiza.ForeColor = System.Drawing.Color.White;
            this.btnMinimiza.Location = new System.Drawing.Point(536, 9);
            this.btnMinimiza.Name = "btnMinimiza";
            this.btnMinimiza.Size = new System.Drawing.Size(25, 25);
            this.btnMinimiza.TabIndex = 5;
            this.btnMinimiza.Text = "-";
            this.btnMinimiza.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimiza.UseVisualStyleBackColor = false;
            this.btnMinimiza.Click += new System.EventHandler(this.btnMinimiza_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 900;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblIncorreto
            // 
            this.lblIncorreto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncorreto.ForeColor = System.Drawing.Color.DarkRed;
            this.lblIncorreto.Location = new System.Drawing.Point(299, 291);
            this.lblIncorreto.Name = "lblIncorreto";
            this.lblIncorreto.Size = new System.Drawing.Size(136, 34);
            this.lblIncorreto.TabIndex = 46;
            this.lblIncorreto.Text = "Usuário ou senha\r\nincorreto(s)!";
            this.lblIncorreto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIncorreto.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Image = global::Kalango.Properties.Resources._checked;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(472, 291);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Padding = new System.Windows.Forms.Padding(3);
            this.btnLogin.Size = new System.Drawing.Size(89, 36);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Entrar";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.Enter += new System.EventHandler(this.btnLogin_Enter);
            // 
            // imgLoading
            // 
            this.imgLoading.Image = global::Kalango.Properties.Resources.loading1;
            this.imgLoading.Location = new System.Drawing.Point(441, 296);
            this.imgLoading.Name = "imgLoading";
            this.imgLoading.Size = new System.Drawing.Size(26, 26);
            this.imgLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgLoading.TabIndex = 47;
            this.imgLoading.TabStop = false;
            this.imgLoading.Visible = false;
            // 
            // btnOlho
            // 
            this.btnOlho.BackColor = System.Drawing.Color.White;
            this.btnOlho.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOlho.BackgroundImage")));
            this.btnOlho.FlatAppearance.BorderSize = 0;
            this.btnOlho.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOlho.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOlho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOlho.Location = new System.Drawing.Point(533, 240);
            this.btnOlho.Name = "btnOlho";
            this.btnOlho.Size = new System.Drawing.Size(25, 25);
            this.btnOlho.TabIndex = 6;
            this.btnOlho.UseVisualStyleBackColor = false;
            this.btnOlho.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOlho_MouseDown);
            this.btnOlho.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOlho_MouseUp);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblAguarde
            // 
            this.lblAguarde.AutoSize = true;
            this.lblAguarde.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAguarde.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAguarde.Location = new System.Drawing.Point(325, 300);
            this.lblAguarde.Name = "lblAguarde";
            this.lblAguarde.Size = new System.Drawing.Size(84, 17);
            this.lblAguarde.TabIndex = 48;
            this.lblAguarde.Text = "Aguarde...";
            this.lblAguarde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAguarde.Visible = false;
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 385);
            this.Controls.Add(this.lblAguarde);
            this.Controls.Add(this.imgLoading);
            this.Controls.Add(this.lblIncorreto);
            this.Controls.Add(this.btnOlho);
            this.Controls.Add(this.btnMinimiza);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnSai);
            this.Controls.Add(this.txtDiaHora);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Login_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtDiaHora;
        private System.Windows.Forms.Button btnSai;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnMinimiza;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnOlho;
        private System.Windows.Forms.Label lblIncorreto;
        private System.Windows.Forms.PictureBox imgLoading;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblAguarde;
    }
}

