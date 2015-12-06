namespace Kalango
{
    partial class ListaUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaUsuarios));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.bDKalango2DataSet = new Kalango.BDKalango2DataSet();
            this.tbUsuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbUsuariosTableAdapter = new Kalango.BDKalango2DataSetTableAdapters.tbUsuariosTableAdapter();
            this.tableAdapterManager = new Kalango.BDKalango2DataSetTableAdapters.TableAdapterManager();
            this.tbUsuariosBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tbUsuariosBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.tbUsuariosDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bDKalango2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUsuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUsuariosBindingNavigator)).BeginInit();
            this.tbUsuariosBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbUsuariosDataGridView)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(209, 65);
            this.label1.TabIndex = 23;
            this.label1.Text = "Usuários";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(124, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 30);
            this.label2.TabIndex = 24;
            this.label2.Text = "Lista de Usuários";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(122, 236);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 456);
            this.panel1.TabIndex = 33;
            // 
            // pnlForm
            // 
            this.pnlForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Controls.Add(this.tbUsuariosBindingNavigator);
            this.pnlForm.Controls.Add(this.tbUsuariosDataGridView);
            this.pnlForm.Location = new System.Drawing.Point(129, 242);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(1100, 444);
            this.pnlForm.TabIndex = 35;
            // 
            // bDKalango2DataSet
            // 
            this.bDKalango2DataSet.DataSetName = "BDKalango2DataSet";
            this.bDKalango2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbUsuariosBindingSource
            // 
            this.tbUsuariosBindingSource.DataMember = "tbUsuarios";
            this.tbUsuariosBindingSource.DataSource = this.bDKalango2DataSet;
            // 
            // tbUsuariosTableAdapter
            // 
            this.tbUsuariosTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tbFornecedorProdutoTableAdapter = null;
            this.tableAdapterManager.tbFornecedorTableAdapter = null;
            this.tableAdapterManager.tbLoteTableAdapter = null;
            this.tableAdapterManager.tbMovimentacaoEstTableAdapter = null;
            this.tableAdapterManager.tbProdutoTableAdapter = null;
            this.tableAdapterManager.tbSaidaTableAdapter = null;
            this.tableAdapterManager.tbTipoMovimentacaoEstTableAdapter = null;
            this.tableAdapterManager.tbUsuariosTableAdapter = this.tbUsuariosTableAdapter;
            this.tableAdapterManager.tbVendaTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Kalango.BDKalango2DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tbUsuariosBindingNavigator
            // 
            this.tbUsuariosBindingNavigator.AddNewItem = null;
            this.tbUsuariosBindingNavigator.BindingSource = this.tbUsuariosBindingSource;
            this.tbUsuariosBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tbUsuariosBindingNavigator.CountItemFormat = "de {0}";
            this.tbUsuariosBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.tbUsuariosBindingNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUsuariosBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorDeleteItem,
            this.tbUsuariosBindingNavigatorSaveItem});
            this.tbUsuariosBindingNavigator.Location = new System.Drawing.Point(0, 408);
            this.tbUsuariosBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tbUsuariosBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tbUsuariosBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tbUsuariosBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tbUsuariosBindingNavigator.Name = "tbUsuariosBindingNavigator";
            this.tbUsuariosBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tbUsuariosBindingNavigator.Size = new System.Drawing.Size(1100, 36);
            this.tbUsuariosBindingNavigator.TabIndex = 36;
            this.tbUsuariosBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(72, 33);
            this.bindingNavigatorMoveFirstItem.Text = "Primeiro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(70, 33);
            this.bindingNavigatorMovePreviousItem.Text = "Anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 36);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 33);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(71, 33);
            this.bindingNavigatorMoveNextItem.Text = "Próximo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(63, 33);
            this.bindingNavigatorMoveLastItem.Text = "Último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 36);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(61, 33);
            this.bindingNavigatorDeleteItem.Text = "Excluir";
            // 
            // tbUsuariosBindingNavigatorSaveItem
            // 
            this.tbUsuariosBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tbUsuariosBindingNavigatorSaveItem.Image")));
            this.tbUsuariosBindingNavigatorSaveItem.Name = "tbUsuariosBindingNavigatorSaveItem";
            this.tbUsuariosBindingNavigatorSaveItem.Size = new System.Drawing.Size(114, 33);
            this.tbUsuariosBindingNavigatorSaveItem.Text = "Salvar alterações";
            this.tbUsuariosBindingNavigatorSaveItem.Click += new System.EventHandler(this.tbUsuariosBindingNavigatorSaveItem_Click);
            // 
            // tbUsuariosDataGridView
            // 
            this.tbUsuariosDataGridView.AllowUserToAddRows = false;
            this.tbUsuariosDataGridView.AllowUserToOrderColumns = true;
            this.tbUsuariosDataGridView.AutoGenerateColumns = false;
            this.tbUsuariosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbUsuariosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.tbUsuariosDataGridView.DataSource = this.tbUsuariosBindingSource;
            this.tbUsuariosDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbUsuariosDataGridView.Location = new System.Drawing.Point(0, 0);
            this.tbUsuariosDataGridView.Name = "tbUsuariosDataGridView";
            this.tbUsuariosDataGridView.ReadOnly = true;
            this.tbUsuariosDataGridView.Size = new System.Drawing.Size(1100, 408);
            this.tbUsuariosDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "login";
            this.dataGridViewTextBoxColumn1.HeaderText = "Login";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "nivelAcesso";
            this.dataGridViewTextBoxColumn3.HeaderText = "Nível de Acesso";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 130;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "nome";
            this.dataGridViewTextBoxColumn4.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "sobrenome";
            this.dataGridViewTextBoxColumn5.HeaderText = "Sobrenome";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // ListaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1356, 764);
            this.ControlBox = false;
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1182, 630);
            this.Name = "ListaUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Fornecedores";
            this.Load += new System.EventHandler(this.ListaUsuarios_Load);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bDKalango2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUsuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUsuariosBindingNavigator)).EndInit();
            this.tbUsuariosBindingNavigator.ResumeLayout(false);
            this.tbUsuariosBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbUsuariosDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlForm;
        private BDKalango2DataSet bDKalango2DataSet;
        private System.Windows.Forms.BindingSource tbUsuariosBindingSource;
        private BDKalango2DataSetTableAdapters.tbUsuariosTableAdapter tbUsuariosTableAdapter;
        private BDKalango2DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tbUsuariosBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tbUsuariosBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView tbUsuariosDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}