using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Aplicacion
{
    public partial class frm_principal : Form
    {
        private frmLogin autentificacion;

        public frm_principal()
        {
            InitializeComponent();
        }

        private void frm_principal_Load(object sender, EventArgs e)
        {
            try
            {
                autentificacion = new frmLogin();
                autentificacion.miPadre(this);
                autentificacion.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//fin del metodo load


        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_MantenimientoClientes clientes = new Frm_MantenimientoClientes();
            clientes.ShowDialog();
            clientes.Dispose();
        }       
        
    }
}
