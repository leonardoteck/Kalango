namespace Kalango
{
    partial class frmContainer
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
            this.flpJanelas = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblNome = new System.Windows.Forms.Label();
            this.btnMinimiza = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.rightPanel = new System.Windows.Forms.Panel();
            this.btnSobre = new System.Windows.Forms.Button();
            this.btnAjuda = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnJanelas = new System.Windows.Forms.Button();
            this.lblInitials = new System.Windows.Forms.Label();
            this.btnLogoff = new System.Windows.Forms.Button();
            this.btnConfigs = new System.Windows.Forms.Button();
            this.btnAbrePainel = new System.Windows.Forms.Button();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpJanelas
            // 
            this.flpJanelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpJanelas.BackColor = System.Drawing.Color.DarkGreen;
            this.flpJanelas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpJanelas.Location = new System.Drawing.Point(0, 595);
            this.flpJanelas.Name = "flpJanelas";
            this.flpJanelas.Size = new System.Drawing.Size(1362, 176);
            this.flpJanelas.TabIndex = 2;
            // 
            // lblNome
            // 
            this.lblNome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(28)))));
            this.lblNome.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblNome.ForeColor = System.Drawing.Color.White;
            this.lblNome.Location = new System.Drawing.Point(552, 107);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(259, 25);
            this.lblNome.TabIndex = 32;
            this.lblNome.Text = "Usuário Qualquer";
            this.lblNome.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnMinimiza
            // 
            this.btnMinimiza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimiza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(28)))));
            this.btnMinimiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimiza.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimiza.ForeColor = System.Drawing.Color.White;
            this.btnMinimiza.Location = new System.Drawing.Point(1272, 23);
            this.btnMinimiza.Name = "btnMinimiza";
            this.btnMinimiza.Size = new System.Drawing.Size(30, 30);
            this.btnMinimiza.TabIndex = 37;
            this.btnMinimiza.Text = "_";
            this.btnMinimiza.UseVisualStyleBackColor = false;
            this.btnMinimiza.Click += new System.EventHandler(this.btnMinimiza_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(28)))));
            this.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(1308, 23);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(30, 30);
            this.btnFechar.TabIndex = 36;
            this.btnFechar.Text = "x";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // rightPanel
            // 
            this.rightPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rightPanel.AutoSize = true;
            this.rightPanel.BackColor = System.Drawing.Color.Green;
            this.rightPanel.Controls.Add(this.btnSobre);
            this.rightPanel.Controls.Add(this.btnAjuda);
            this.rightPanel.Location = new System.Drawing.Point(1144, 315);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Padding = new System.Windows.Forms.Padding(5);
            this.rightPanel.Size = new System.Drawing.Size(113, 238);
            this.rightPanel.TabIndex = 44;
            // 
            // btnSobre
            // 
            this.btnSobre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSobre.BackColor = System.Drawing.Color.Teal;
            this.btnSobre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSobre.FlatAppearance.BorderSize = 0;
            this.btnSobre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSobre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSobre.ForeColor = System.Drawing.Color.White;
            this.btnSobre.Image = global::Kalango.Properties.Resources.Information_Icon;
            this.btnSobre.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSobre.Location = new System.Drawing.Point(9, 124);
            this.btnSobre.Margin = new System.Windows.Forms.Padding(5);
            this.btnSobre.Name = "btnSobre";
            this.btnSobre.Padding = new System.Windows.Forms.Padding(5);
            this.btnSobre.Size = new System.Drawing.Size(94, 104);
            this.btnSobre.TabIndex = 44;
            this.btnSobre.Text = "Sobre";
            this.btnSobre.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSobre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSobre.UseVisualStyleBackColor = false;
            this.btnSobre.Click += new System.EventHandler(this.btnSobre_Click);
            // 
            // btnAjuda
            // 
            this.btnAjuda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAjuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAjuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAjuda.FlatAppearance.BorderSize = 0;
            this.btnAjuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjuda.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAjuda.ForeColor = System.Drawing.Color.White;
            this.btnAjuda.Image = global::Kalango.Properties.Resources.Help_Icon;
            this.btnAjuda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAjuda.Location = new System.Drawing.Point(9, 10);
            this.btnAjuda.Margin = new System.Windows.Forms.Padding(5);
            this.btnAjuda.Name = "btnAjuda";
            this.btnAjuda.Padding = new System.Windows.Forms.Padding(5);
            this.btnAjuda.Size = new System.Drawing.Size(94, 104);
            this.btnAjuda.TabIndex = 43;
            this.btnAjuda.Text = "Ajuda";
            this.btnAjuda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAjuda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAjuda.UseVisualStyleBackColor = false;
            this.btnAjuda.Click += new System.EventHandler(this.btnAjuda_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(28)))));
            this.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Image = global::Kalango.Properties.Resources.Return_Icon;
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVoltar.Location = new System.Drawing.Point(97, 73);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(82, 81);
            this.btnVoltar.TabIndex = 42;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnJanelas
            // 
            this.btnJanelas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnJanelas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(28)))));
            this.btnJanelas.BackgroundImage = global::Kalango.Properties.Resources.Open_Window_Icon_2;
            this.btnJanelas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnJanelas.FlatAppearance.BorderSize = 0;
            this.btnJanelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJanelas.Location = new System.Drawing.Point(873, 108);
            this.btnJanelas.Margin = new System.Windows.Forms.Padding(6);
            this.btnJanelas.Name = "btnJanelas";
            this.btnJanelas.Size = new System.Drawing.Size(25, 25);
            this.btnJanelas.TabIndex = 33;
            this.btnJanelas.UseVisualStyleBackColor = false;
            this.btnJanelas.Click += new System.EventHandler(this.btnJanelas_Click);
            // 
            // lblInitials
            // 
            this.lblInitials.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInitials.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(28)))));
            this.lblInitials.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitials.ForeColor = System.Drawing.Color.White;
            this.lblInitials.Image = global::Kalango.Properties.Resources.usuario;
            this.lblInitials.Location = new System.Drawing.Point(822, 99);
            this.lblInitials.Name = "lblInitials";
            this.lblInitials.Size = new System.Drawing.Size(40, 40);
            this.lblInitials.TabIndex = 38;
            this.lblInitials.Text = "UQ";
            this.lblInitials.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogoff
            // 
            this.btnLogoff.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogoff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(28)))));
            this.btnLogoff.BackgroundImage = global::Kalango.Properties.Resources.Log_Off_Icon_2;
            this.btnLogoff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogoff.FlatAppearance.BorderSize = 0;
            this.btnLogoff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogoff.Location = new System.Drawing.Point(910, 107);
            this.btnLogoff.Margin = new System.Windows.Forms.Padding(6);
            this.btnLogoff.Name = "btnLogoff";
            this.btnLogoff.Size = new System.Drawing.Size(25, 25);
            this.btnLogoff.TabIndex = 35;
            this.btnLogoff.UseVisualStyleBackColor = false;
            this.btnLogoff.Click += new System.EventHandler(this.btnLogoff_Click);
            // 
            // btnConfigs
            // 
            this.btnConfigs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfigs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(28)))));
            this.btnConfigs.BackgroundImage = global::Kalango.Properties.Resources.Config_Icon_2;
            this.btnConfigs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfigs.FlatAppearance.BorderSize = 0;
            this.btnConfigs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigs.Location = new System.Drawing.Point(947, 107);
            this.btnConfigs.Margin = new System.Windows.Forms.Padding(6);
            this.btnConfigs.Name = "btnConfigs";
            this.btnConfigs.Size = new System.Drawing.Size(25, 25);
            this.btnConfigs.TabIndex = 34;
            this.btnConfigs.UseVisualStyleBackColor = false;
            this.btnConfigs.Click += new System.EventHandler(this.btnConfigs_Click);
            // 
            // btnAbrePainel
            // 
            this.btnAbrePainel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAbrePainel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(28)))));
            this.btnAbrePainel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAbrePainel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnAbrePainel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrePainel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAbrePainel.ForeColor = System.Drawing.Color.White;
            this.btnAbrePainel.Image = global::Kalango.Properties.Resources.Show_Open_Window_Icon;
            this.btnAbrePainel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbrePainel.Location = new System.Drawing.Point(601, 550);
            this.btnAbrePainel.Name = "btnAbrePainel";
            this.btnAbrePainel.Size = new System.Drawing.Size(158, 33);
            this.btnAbrePainel.TabIndex = 1;
            this.btnAbrePainel.Text = "Janelas abertas";
            this.btnAbrePainel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAbrePainel.UseVisualStyleBackColor = false;
            this.btnAbrePainel.Click += new System.EventHandler(this.btnAbrePainel_Click);
            this.btnAbrePainel.Leave += new System.EventHandler(this.btnAbrePainel_Leave);
            // 
            // frmContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1360, 768);
            this.ControlBox = false;
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnJanelas);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblInitials);
            this.Controls.Add(this.btnMinimiza);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnLogoff);
            this.Controls.Add(this.btnConfigs);
            this.Controls.Add(this.flpJanelas);
            this.Controls.Add(this.btnAbrePainel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmContainer";
            this.Text = "Container";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmContainer_FormClosing);
            this.Load += new System.EventHandler(this.frmContainer_Load);
            this.rightPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrePainel;
        private System.Windows.Forms.FlowLayoutPanel flpJanelas;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnJanelas;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblInitials;
        private System.Windows.Forms.Button btnMinimiza;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnLogoff;
        private System.Windows.Forms.Button btnConfigs;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Button btnSobre;
        private System.Windows.Forms.Button btnAjuda;
    }
}