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
    public partial class Frm_MantenimientoClientes : Form
    {
        public Frm_MantenimientoClientes()
        {
            InitializeComponent();
        }

        private void Frm_MantenimientoClientes_Load(object sender, EventArgs e)
        {
            cargarLista();
            limpiarInterfaz();
        }

        //Se obtiene la cadena de conexion
        private string getCadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;
        }

        //Se carga toda la lista 
        public void cargarLista()
        {
            Cls_Clientes_ADO clientesADO = new Cls_Clientes_ADO(getCadenaConexion());
            dtgClientes.DataSource = clientesADO.ListadoClientes().Tables[0];
            dtgClientes.ReadOnly = true;
            dtgClientes.Refresh();
        }

        //Cuando ya se consulto se deshabilita todos los botones menos la opción de registrar
        public void habilitarRegistar()
        {
            this.btnBuscar.Enabled = false;
            this.btnRegistrar.Enabled = true;
            this.btnModificar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnLimpiar.Enabled = true;
        }

        //Cuando esta registrado las opciones que puede tener acceso serán las opciones: modificar, 
        //eliminar datos y opcion de limpiar interfaz(btns habilitados)
        public void habilitarModificar()
        {
            this.btnBuscar.Enabled = false;
            this.btnRegistrar.Enabled = false;
            this.btnModificar.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.btnLimpiar.Enabled = true;
        }

        //Limpiar interfaz: se llama al metodo para limpiar el control y se habilita la opcion de consultar
        public void limpiarInterfaz()
        {
            this.ctr_Clientes1.LimpiarControl();
            this.btnBuscar.Enabled = true;
            this.btnRegistrar.Enabled = false;
            this.btnModificar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnLimpiar.Enabled = false;
        }

        //Métodos para mjs rapido de error y de confirmación
        public void msjError(string pMsjError)
        {
            MessageBox.Show(pMsjError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void msjConfirmar(string pMsj, string pTitulo)
        {
            MessageBox.Show(pMsj, pTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Clientes_ADO clientesADO = new Cls_Clientes_ADO(getCadenaConexion());
                Cls_Clientes clientes = clientesADO.ConsultarCliente(ctr_Clientes1.CedulaCliente);
                if (clientes != null)
                {
                    this.ctr_Clientes1.NombreCliente = clientes.Nombre;
                    this.ctr_Clientes1.TelefonoCliente = clientes.Telefono;
                    this.ctr_Clientes1.DireccionCliente = clientes.Direccion;

                    habilitarModificar();
                    this.ctr_Clientes1.enabledTextBox();
                }
                else
                {
                    habilitarRegistar();
                    this.ctr_Clientes1.enabledTextBox();
                }
            }
            catch (Exception ex)
            {
                msjError(ex.Message);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Clientes registrarNuevo = new Cls_Clientes
                (
                    this.ctr_Clientes1.CedulaCliente,
                    this.ctr_Clientes1.NombreCliente,
                    this.ctr_Clientes1.TelefonoCliente,
                    this.ctr_Clientes1.DireccionCliente
                );
                Cls_Clientes_ADO clientesADO = new Cls_Clientes_ADO(getCadenaConexion());
                clientesADO.RegistrarCliente(registrarNuevo);
                msjConfirmar("Registrado el nuevo cliente", "Registrado correctamente");
                limpiarInterfaz();
                cargarLista();
            }
            catch (Exception ex)
            {
                msjError(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Clientes_ADO clientesADO = new Cls_Clientes_ADO(getCadenaConexion());
                Cls_Clientes seguros = new Cls_Clientes
                (
                    this.ctr_Clientes1.CedulaCliente,
                    this.ctr_Clientes1.NombreCliente,
                    this.ctr_Clientes1.TelefonoCliente,
                    this.ctr_Clientes1.DireccionCliente
                );

                clientesADO.ModificarCliente(seguros);
                msjConfirmar("Se han modificado los datos correctamente", "Datos modificados y guardados");
                limpiarInterfaz();
                cargarLista();
            }
            catch (Exception ex)
            {
                msjError(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Clientes_ADO clientesADO = new Cls_Clientes_ADO(getCadenaConexion());
                clientesADO.EliminarCliente(this.ctr_Clientes1.CedulaCliente);
                msjConfirmar("Se han eliminados los datos", "Datos del cliente eliminados");
                limpiarInterfaz();
                cargarLista();
            }
            catch (Exception ex)
            {
                msjError(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarInterfaz();
        }
    }
}
