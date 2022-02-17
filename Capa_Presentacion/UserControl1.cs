using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class Ctr_Clientes: UserControl
    {
        public Ctr_Clientes()
        {
            InitializeComponent();
        }

        #region Propiedades

        public string CedulaCliente
        {
            set { this.txtCedula.Text = value.Trim(); }
            get { return this.txtCedula.Text.Trim(); }
        }

        public string NombreCliente
        {
            set { this.txtNombre.Text = value.Trim(); }
            get { return this.txtNombre.Text.Trim(); }
        }

        public string TelefonoCliente
        {
            set { this.txtTelefono.Text = value.Trim(); }
            get { return this.txtTelefono.Text.Trim(); }
        }

        public string DireccionCliente
        {
            set { this.txtDireccion.Text = value.Trim(); }
            get { return this.txtDireccion.Text.Trim(); }
        }
        #endregion

        #region Limpiar Interfaz
        public void LimpiarControl()
        {
            this.txtCedula.Clear();
            this.txtNombre.Clear();
            this.txtTelefono.Clear();
            this.txtDireccion.Clear();

            this.txtCedula.Enabled = true;
            this.txtNombre.Enabled = false;
            this.txtTelefono.Enabled = false;
            this.txtDireccion.Enabled = false;
        }

        public void enabledTextBox()
        {
            this.txtCedula.Enabled = false;
            this.txtNombre.Enabled = true;
            this.txtTelefono.Enabled = true;
            this.txtDireccion.Enabled = true;
        }
        #endregion  
    }
}
