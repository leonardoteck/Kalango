namespace Kalango
{
    partial class IconeJanela
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IconeJanela));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnFecha = new System.Windows.Forms.Button();
            this.imgIcone = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(13, 118);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(180, 25);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Menu Principal";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Click += new System.EventHandler(this.imgIcone_Click);
            // 
            // btnFecha
            // 
            this.btnFecha.BackColor = System.Drawing.Color.Black;
            this.btnFecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFecha.FlatAppearance.BorderSize = 0;
            this.btnFecha.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnFecha.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecha.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecha.ForeColor = System.Drawing.Color.White;
            this.btnFecha.Location = new System.Drawing.Point(181, 5);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(20, 20);
            this.btnFecha.TabIndex = 2;
            this.btnFecha.Text = "X";
            this.btnFecha.UseVisualStyleBackColor = false;
            this.btnFecha.Click += new System.EventHandler(this.btnFecha_Click);
            // 
            // imgIcone
            // 
            this.imgIcone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imgIcone.BackgroundImage")));
            this.imgIcone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgIcone.Location = new System.Drawing.Point(13, 12);
            this.imgIcone.Name = "imgIcone";
            this.imgIcone.Size = new System.Drawing.Size(180, 103);
            this.imgIcone.TabIndex = 0;
            this.imgIcone.TabStop = false;
            this.imgIcone.Click += new System.EventHandler(this.imgIcone_Click);
            // 
            // IconeJanela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Controls.Add(this.btnFecha);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.imgIcone);
            this.Name = "IconeJanela";
            this.Size = new System.Drawing.Size(207, 143);
            this.Click += new System.EventHandler(this.imgIcone_Click);
            ((System.ComponentModel.ISupportInitialize)(this.imgIcone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.PictureBox imgIcone;
        private System.Windows.Forms.Button btnFecha;
        public System.Windows.Forms.Label lblTitulo;
    }
}
