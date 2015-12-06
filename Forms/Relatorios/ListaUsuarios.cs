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
    public partial class ListaUsuarios : Form
    {
        public ListaUsuarios()
        {
            InitializeComponent();
        }

        private void tbUsuariosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbUsuariosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDKalango2DataSet);

        }

        private void ListaUsuarios_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bDKalango2DataSet.tbUsuarios' table. You can move, or remove it, as needed.
            this.tbUsuariosTableAdapter.Fill(this.bDKalango2DataSet.tbUsuarios);

        }
    }
}
