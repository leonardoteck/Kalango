namespace Kalango
{
    partial class MenuCtrlEst
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCtrlEst = new System.Windows.Forms.Button();
            this.btnPeps = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(185, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ctrl. Estoque";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(124, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Geral";
            // 
            // btnCtrlEst
            // 
            this.btnCtrlEst.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCtrlEst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.btnCtrlEst.BackgroundImage = global::Kalango.Properties.Resources.estoque_2;
            this.btnCtrlEst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCtrlEst.FlatAppearance.BorderSize = 0;
            this.btnCtrlEst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCtrlEst.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCtrlEst.ForeColor = System.Drawing.Color.White;
            this.btnCtrlEst.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCtrlEst.Location = new System.Drawing.Point(129, 287);
            this.btnCtrlEst.Margin = new System.Windows.Forms.Padding(20);
            this.btnCtrlEst.Name = "btnCtrlEst";
            this.btnCtrlEst.Padding = new System.Windows.Forms.Padding(5);
            this.btnCtrlEst.Size = new System.Drawing.Size(252, 139);
            this.btnCtrlEst.TabIndex = 10;
            this.btnCtrlEst.Text = "Controle de Estoque";
            this.btnCtrlEst.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnCtrlEst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCtrlEst.UseVisualStyleBackColor = false;
            this.btnCtrlEst.Click += new System.EventHandler(this.btnCtrlEst_Click);
            // 
            // btnPeps
            // 
            this.btnPeps.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPeps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(106)))));
            this.btnPeps.BackgroundImage = global::Kalango.Properties.Resources.relatorio_2;
            this.btnPeps.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPeps.FlatAppearance.BorderSize = 0;
            this.btnPeps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPeps.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeps.ForeColor = System.Drawing.Color.White;
            this.btnPeps.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPeps.Location = new System.Drawing.Point(421, 287);
            this.btnPeps.Margin = new System.Windows.Forms.Padding(20);
            this.btnPeps.Name = "btnPeps";
            this.btnPeps.Padding = new System.Windows.Forms.Padding(5);
            this.btnPeps.Size = new System.Drawing.Size(252, 139);
            this.btnPeps.TabIndex = 35;
            this.btnPeps.Text = "Ficha de Estoque";
            this.btnPeps.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPeps.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPeps.UseVisualStyleBackColor = false;
            this.btnPeps.Click += new System.EventHandler(this.btnPeps_Click);
            // 
            // MenuCtrlEst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1356, 764);
            this.ControlBox = false;
            this.Controls.Add(this.btnPeps);
            this.Controls.Add(this.btnCtrlEst);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1182, 630);
            this.Name = "MenuCtrlEst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Ctrl. Estoque";
            this.Load += new System.EventHandler(this.MenuCtrlEst_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCtrlEst;
        private System.Windows.Forms.Button btnPeps;
    }
}