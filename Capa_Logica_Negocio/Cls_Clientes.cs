using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica_Negocio
{
    public class Cls_Clientes
    {
        #region Atributos
        private string cedulaCliente;
        private string nombreCliente;
        private string telefonoCliente;
        private string direccionCliente;
        #endregion

        #region Propiedades
        public string Cedula
        {
            get { return this.cedulaCliente; }
            set
            {
                if(value.Trim().Equals(""))
                {
                    throw new Exception("Ingrese el número de cédula para el cliente");
                }
                else
                {
                    this.cedulaCliente = value.Trim();
                }
            }
        }

        public string Nombre
        {
            get { return this.nombreCliente; }
            set
            {
                if (value.Trim().Equals(""))
                {
                    throw new Exception("Ingrese el nombre del cliente");
                }
                else
                {
                    this.nombreCliente = value.Trim();
                }
            }
        }

        public string Telefono
        {
            get { return this.telefonoCliente; }
            set
            {
                if (value.Trim().Equals(""))
                {
                    throw new Exception("Ingrese el número de telefono para el cliente");
                }
                else
                {
                    this.telefonoCliente = value.Trim();
                }
            }
        }

        public string Direccion
        {
            get { return this.direccionCliente; }
            set
            {
                if (value.Trim().Equals(""))
                {
                    throw new Exception("Ingrese la dirección del cliente");
                }
                else
                {
                    this.direccionCliente = value.Trim();
                }
            }
        }
        #endregion

        #region Constructores
        public Cls_Clientes()
        {
            this.Cedula = "default";
            this.Nombre = "default";
            this.Telefono = "default";
            this.Direccion = "default";
        }

        public Cls_Clientes(string pCedula, string pNombre, string pTelefono, string pDireccion)
        {
            this.Cedula = pCedula;
            this.Nombre = pNombre;
            this.Telefono = pTelefono;
            this.Direccion = pDireccion;
        }
        #endregion

    }
}
