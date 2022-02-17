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
    public partial class Ctr_Usuario : UserControl
    {
        public Ctr_Usuario()
        {
            InitializeComponent();
        }

        public string Usuario
        {
            set { this.txtUsuario.Text = value.Trim(); }
            get { return this.txtUsuario.Text.Trim(); }
        }

        public string Contraseña
        {
            set { this.txtContraseña.Text = value.Trim(); }
            get { return this.txtContraseña.Text.Trim(); }
        }

        private void Ctr_Usuario_Load(object sender, EventArgs e)
        {

        }
    }
}
