using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Acceso_Datos;
using Capa_Logica_Negocio;
using System.Configuration;

namespace Capa_Aplicacion
{
    public partial class frmLogin : Form
    {
        private frm_principal frmMenu;
        private Boolean autenticado = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Usuario usuario = new Cls_Usuario(this.ctr_Usuario1.Usuario, this.ctr_Usuario1.Contraseña);
                Cls_Usuario_ADO usuarioADO = new Cls_Usuario_ADO(ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString);
                usuarioADO.ComprobarUsuario(usuario);

                this.autenticado = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (this.autenticado == false)
                {
                    this.frmMenu.Close();
                }
            }

            //metodo para llamar al formulario
            public void miPadre(frm_principal frm)
            {
                this.frmMenu = frm;
            }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
 }