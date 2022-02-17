using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Logica_Negocio;

namespace Capa_Acceso_Datos
{
    public class Cls_Usuario_ADO
    {
        #region "Variables"

        private string strConexion;
        private SqlConnection sqlConexion;
        private SqlCommand sqlComando;
        #endregion

        public Cls_Usuario_ADO(string pStringConexion)
        {
            this.stringConexion = pStringConexion;
        }//fin const

#region "Propiedades"
        public string stringConexion
        {
            get
            {
                return this.strConexion;

            }//fin get

            set
            {
                this.strConexion = value.Trim();

            }//fin set
        }
#endregion
        public void ComprobarUsuario(Cls_Usuario usuario) {
            try
            {
                this.sqlConexion = new SqlConnection(this.stringConexion);
                this.sqlConexion.Open();
                int autorizado = 0;

                this.sqlComando = new SqlCommand();
                this.sqlComando.Connection = this.sqlConexion;
                this.sqlComando.CommandText = "select dbo.Fn_ValidarAcceso(@Login, @Password)";
                this.sqlComando.Parameters.AddWithValue("@Login", usuario.Usuario);
                this.sqlComando.Parameters.AddWithValue("@Password", usuario.Contraseña);

                autorizado = (int)this.sqlComando.ExecuteScalar();
                if (autorizado == 0)
                    throw new Exception("El usuario o el password ingresado es incorrecto.");

            }//try
            catch (Exception ex) {
                throw ex;
            }//catch

        }//fin validaIngreso
        
    }
}
