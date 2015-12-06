using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExceptionHandler;

namespace Kalango
{
    public partial class FichaConfig : Form
    {
        public FichaConfig()
        {
            InitializeComponent();
        }

        ControladorBD dbctrl = new ControladorBD();
        DataTable produtos;

        public int ProdutoID { get; private set; }
        public TipoFicha Tipo { get; private set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            if (rdbPEPS.Checked)
                Tipo = TipoFicha.PEPS;
            else if (rdbUEPS.Checked)
                Tipo = TipoFicha.UEPS;
            else
               Tipo = TipoFicha.MPM;
            ProdutoID = (int)produtos.Rows[lstResult.SelectedIndex][0];
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPesquisa.Text)) return;
            string query = "SELECT ProdutoID, descricao FROM tbProduto WHERE ";
            if (rdbCodBarras.Checked) {
                long cod;                  
                if (!long.TryParse(txtPesquisa.Text, out cod))
                {
                    MsgAvancado.ExibirErroValidacao("Digite apenas números!");
                    return;
                } 
                query += "codBarras = " + txtPesquisa.Text;
            }
            else
                query += "descricao LIKE '%" + txtPesquisa.Text + "%'";
            try
            {
                produtos = dbctrl.Ler(query);
                foreach (DataRow linha in produtos.Rows)
                {
                    lstResult.Items.Add(linha[1].ToString());
                }
                lstResult.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MsgAvancado.ExibirErro(ex, "Não foi possível fazer a pesquisa.");
            }

        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void lstResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            grbTipo.Enabled = true;
        }

    #region Design do ProdDatePicker

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbDesc = new System.Windows.Forms.RadioButton();
            this.rdbCodBarras = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.grbTipo = new System.Windows.Forms.GroupBox();
            this.rdbMPM = new System.Windows.Forms.RadioButton();
            this.rdbUEPS = new System.Windows.Forms.RadioButton();
            this.rdbPEPS = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancela = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grbTipo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lstResult);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPesquisa);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rdbDesc);
            this.groupBox1.Controls.Add(this.rdbCodBarras);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 178);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisar Produto";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(41, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Pesquisar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // lstResult
            // 
            this.lstResult.FormattingEnabled = true;
            this.lstResult.Location = new System.Drawing.Point(163, 32);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(113, 134);
            this.lstResult.TabIndex = 6;
            this.lstResult.SelectedIndexChanged += new System.EventHandler(this.lstResult_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Resultados";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(9, 111);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(138, 20);
            this.txtPesquisa.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Termo a pesquisar:";
            // 
            // rdbDesc
            // 
            this.rdbDesc.AutoSize = true;
            this.rdbDesc.Checked = true;
            this.rdbDesc.Location = new System.Drawing.Point(9, 38);
            this.rdbDesc.Name = "rdbDesc";
            this.rdbDesc.Size = new System.Drawing.Size(73, 17);
            this.rdbDesc.TabIndex = 2;
            this.rdbDesc.TabStop = true;
            this.rdbDesc.Text = "Descrição";
            this.rdbDesc.UseVisualStyleBackColor = true;
            // 
            // rdbCodBarras
            // 
            this.rdbCodBarras.AutoSize = true;
            this.rdbCodBarras.Location = new System.Drawing.Point(9, 61);
            this.rdbCodBarras.Name = "rdbCodBarras";
            this.rdbCodBarras.Size = new System.Drawing.Size(105, 17);
            this.rdbCodBarras.TabIndex = 1;
            this.rdbCodBarras.TabStop = true;
            this.rdbCodBarras.Text = "Código de barras";
            this.rdbCodBarras.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pesquisar por:";
            // 
            // grbTipo
            // 
            this.grbTipo.Controls.Add(this.rdbMPM);
            this.grbTipo.Controls.Add(this.rdbUEPS);
            this.grbTipo.Controls.Add(this.rdbPEPS);
            this.grbTipo.Enabled = false;
            this.grbTipo.Location = new System.Drawing.Point(7, 194);
            this.grbTipo.Name = "grbTipo";
            this.grbTipo.Size = new System.Drawing.Size(287, 54);
            this.grbTipo.TabIndex = 1;
            this.grbTipo.TabStop = false;
            this.grbTipo.Text = "Escolha o tipo de relatório";
            // 
            // rdbMPM
            // 
            this.rdbMPM.AutoSize = true;
            this.rdbMPM.Location = new System.Drawing.Point(133, 25);
            this.rdbMPM.Name = "rdbMPM";
            this.rdbMPM.Size = new System.Drawing.Size(50, 17);
            this.rdbMPM.TabIndex = 2;
            this.rdbMPM.TabStop = true;
            this.rdbMPM.Text = "MPM";
            this.rdbMPM.UseVisualStyleBackColor = true;
            // 
            // rdbUEPS
            // 
            this.rdbUEPS.AutoSize = true;
            this.rdbUEPS.Location = new System.Drawing.Point(73, 25);
            this.rdbUEPS.Name = "rdbUEPS";
            this.rdbUEPS.Size = new System.Drawing.Size(54, 17);
            this.rdbUEPS.TabIndex = 1;
            this.rdbUEPS.TabStop = true;
            this.rdbUEPS.Text = "UEPS";
            this.rdbUEPS.UseVisualStyleBackColor = true;
            // 
            // rdbPEPS
            // 
            this.rdbPEPS.AutoSize = true;
            this.rdbPEPS.Checked = true;
            this.rdbPEPS.Location = new System.Drawing.Point(14, 25);
            this.rdbPEPS.Name = "rdbPEPS";
            this.rdbPEPS.Size = new System.Drawing.Size(53, 17);
            this.rdbPEPS.TabIndex = 0;
            this.rdbPEPS.TabStop = true;
            this.rdbPEPS.Text = "PEPS";
            this.rdbPEPS.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.BackColor = System.Drawing.Color.White;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(83, 298);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancela
            // 
            this.btnCancela.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancela.BackColor = System.Drawing.Color.White;
            this.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancela.Location = new System.Drawing.Point(164, 298);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(75, 23);
            this.btnCancela.TabIndex = 3;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.UseVisualStyleBackColor = false;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.grbTipo);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(11, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 257);
            this.panel1.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(82, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Configurar Relatório";
            // 
            // FichaConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(325, 331);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancela);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FichaConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preparar Relatório";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbTipo.ResumeLayout(false);
            this.grbTipo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbDesc;
        private System.Windows.Forms.RadioButton rdbCodBarras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbTipo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancela;
        private Panel panel1;
        private Label label5;
        private RadioButton rdbMPM;
        private RadioButton rdbUEPS;
        private RadioButton rdbPEPS;
    }
    #endregion
}
