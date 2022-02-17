using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica_Negocio
{
    public class Cls_Usuario
    {
        private string usuario;
        private string contraseña;

        public string Usuario
        {
            get { return this.usuario; }
            set
            {
                if (value.Trim().Equals(""))
                {
                    throw new Exception("Ingrese el usuario");
                }
                else
                {
                    this.usuario = value.Trim();
                }
            }
        }

        public string Contraseña
        {
            get { return this.contraseña; }
            set
            {
                if (value.Trim().Equals(""))
                {
                    throw new Exception("Ingrese la contraseña correctamente");
                }
                else
                {
                    this.contraseña = value.Trim();
                }
            }
        }

        public Cls_Usuario()
        {
            this.Usuario = "default";
            this.Contraseña = "default";
        }

        public Cls_Usuario(string pUsuario, string pContraseña)
        {
            this.Usuario = pUsuario;
            this.Contraseña = pContraseña;
        }
    }
}
