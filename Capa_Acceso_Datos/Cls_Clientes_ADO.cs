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
    public class Cls_Clientes_ADO
    {
        #region Atributos
        private string varConexion;
        private SqlConnection conexion;
        private SqlCommand comando;
        #endregion

        public Cls_Clientes_ADO(string pVarConexion)
        {
            this.varConexion = pVarConexion;
            conexion = null;
            comando = null;
        }

        //Nota: Se habilita la conexion en la BD
        private void habilitarConexion()
        {
            try
            {
                conexion = new SqlConnection(this.varConexion);
                conexion.Open();
                comando = new SqlCommand();
                comando.Connection = conexion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void deshabilitarConexion()
        {
            try
            {
                comando.Dispose();
                conexion.Close();
                conexion.Dispose();
                conexion = null;
                comando = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Nota:Se completa el uso con la BD
        public void RegistrarCliente(Cls_Clientes cliente)
        {
            try
            {
                //Habilitar la conexion
                habilitarConexion();

                //Se utiliza el procedimiento almacenado de la base de datos para registrar datos
                comando.CommandText = "Sp_Ins_Clientes" ; //Nota:llamando del procedieminto almacenado aqui a cliente
                comando.CommandType = CommandType.StoredProcedure;

                //Se le pasan por parametros al procedimiento con los valores correspondientes
                comando.Parameters.AddWithValue("@cli_cedula", cliente.Cedula); //Nota: Metodo para llamar al cliente
                comando.Parameters.AddWithValue("@cli_nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@cli_telefono", cliente.Telefono);
                comando.Parameters.AddWithValue("@cli_direccion", cliente.Direccion);

                comando.ExecuteNonQuery();

                //Se cierra la conexion
                deshabilitarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarCliente(string idCliente)
        {
            try
            {
                //Se habilita la conexion a la BD para utilizar el procedimiento eliminar y se pasa el parametro para borrar
                habilitarConexion();
                comando.CommandText = "Sp_Del_Clientes";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@cedula", idCliente);
                comando.ExecuteNonQuery();
                deshabilitarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarCliente(Cls_Clientes cliente)
        {
            try
            {
                //Habilita la conexion 
                habilitarConexion();
                //Utiliza procedimiento almacenado para actualizar en la BD
                comando.CommandText = "SpUpdClientes";
                comando.CommandType = CommandType.StoredProcedure;
                //Pasa por parametros los valores
                comando.Parameters.AddWithValue("@cli_cedula", cliente.Cedula);
                comando.Parameters.AddWithValue("@cli_nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@cli_telefono", cliente.Telefono);
                comando.Parameters.AddWithValue("@cli_direccion", cliente.Direccion);

                comando.ExecuteNonQuery();

                //Deshabilita la conexion
                deshabilitarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cls_Clientes ConsultarCliente(string idCliente)
        {
            try
            {
                Cls_Clientes cliente = null;
                habilitarConexion();
                comando.CommandText = "Sp_Del_Clientes";//procedimiento
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@cli_cedula", idCliente);
                SqlDataReader lectura = comando.ExecuteReader();
                //Para la lectura de los datos
                if (lectura.HasRows)
                {
                    cliente = new Cls_Clientes();
                    while (lectura.Read())
                    {
                        cliente.Cedula = lectura.GetString(0).ToString();
                        cliente.Nombre = lectura.GetString(1).ToString();
                        cliente.Telefono = lectura.GetString(2).ToString();
                        cliente.Direccion = lectura.GetString(3).ToString();
                    }
                }

                lectura.Close();
                deshabilitarConexion();
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //vistas
        public DataSet ListadoClientes()
        {
            try
            {
                habilitarConexion();
                DataSet datos = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                comando.CommandText = "SELECT * FROM Vp_Clientes";
                comando.CommandType = CommandType.Text;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                deshabilitarConexion();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*TERMINA CODIGO DE LA APLICACION*/
        public DataSet ListaCliente(string nombre)
        {
            try
            {
                SqlCommand commando = new SqlCommand();
                DataSet clientes = new DataSet();

                SqlDataAdapter adaptador = new SqlDataAdapter();
                commando.CommandText = "[Sp_Cns_ClienteNombre]";
                commando.CommandType = CommandType.StoredProcedure;
                commando.Connection = conexion;
                commando.Parameters.AddWithValue("@cli_nombre", nombre);
                adaptador.SelectCommand = commando;
                adaptador.Fill(clientes);
                conexion.Close();
                conexion.Dispose();
                commando.Dispose();
                adaptador.Dispose();
                return clientes;

            }
             catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet TipoPago()
        {
            try
            {
                habilitarConexion();
                DataSet datos = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                comando.CommandText = "SELECT * FROM [Tbl_Tipo_Pago]";
                comando.CommandType = CommandType.Text;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                deshabilitarConexion();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet NombresBancos()
        {
            try
            {
                habilitarConexion();
                DataSet datos = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                comando.CommandText = "SELECT * FROM [Tbl_Bancos]";
                comando.CommandType = CommandType.Text;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                deshabilitarConexion();
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
