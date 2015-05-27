using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
   public class Contacto
    {
        #region Atributos
        private int conId;
        private string conNombre;
        private string conApellido;
        private string conCargo;
        private List<string> conTelefonos;
        private ClienteJuridico clienteJuridico;
        private ClienteNatural clienteNatural; 

        #endregion

        #region Propiedades


        public int Con_Id
        {
            get { return conId; }
            set { conId = value; }
        }

        public string Con_Nombre
        {
            get { return conNombre; }
            set { conNombre = value; }
        }
        public string Con_Apellido
        {
            get { return conApellido; }
            set { conApellido = value; }
        }


        public List<string> Con_Telefonos
        {
            get { return conTelefonos; }
            set { conTelefonos = value; }
        }
        public string ConCargo
        {
            get { return conCargo; }
            set { conCargo = value; }
        }

        public ClienteJuridico ConClienteJurid
        {
            get { return clienteJuridico; }
            set { clienteJuridico = value; }
        }

        public ClienteNatural ConClienteNat
        {
            get { return clienteNatural; }
            set { clienteNatural = value; }
        }
       
     #endregion

        #region Constructores

       /// <summary>
       /// Constructor de la Clase Contacto
       /// </summary>
        public Contacto() 
        {
            Con_Id = 0;
            Con_Nombre = string.Empty;
            Con_Apellido = string.Empty;
            ConCargo = string.Empty;
            Con_Telefonos = null;
            ConClienteJurid = null;
            ConClienteNat = null; 
        }


       /// <summary>
       /// Constructor de la Clase Contacto
       /// </summary>
       /// <param name="id">Número de Cédula o Identificador de Contacto</param>
        public Contacto(int id) 
        {
            Con_Id = id;
            Con_Nombre = string.Empty;
            Con_Apellido = string.Empty;
            ConCargo = string.Empty;
            Con_Telefonos = null;
            ConClienteJurid = null;
            ConClienteNat = null; 
        }


       /// <summary>
       /// Constructor de la Clase Contacto
       /// </summary>
       /// <param name="nombre">Nombres de la Persona Contacto de la Empresa</param>
       /// <param name="apellido">Apellidos de la Persona Contacto de la Empresa</param>
        public Contacto(string nombre, string apellido) 
        {
            Con_Id = 0;
            Con_Nombre = nombre; 
            Con_Apellido = apellido;
            ConCargo = string.Empty;
            Con_Telefonos = null;
            ConClienteJurid = null;
            ConClienteNat = null; 
        }


       /// <summary>
       /// Constructor de la Clase Contacto
       /// </summary>
       /// <param name="id">Número de Cédula o Identificador de la Clase Contacto</param>
       /// <param name="nombre">Nombres de la Persona Contacto de la Empresa</param>
       /// <param name="apellido">Apellidos de la Persona Contacto de la Empresa</param>
        public Contacto(int id, string nombre, string apellido) 
        {
            Con_Id = id;
            Con_Nombre = nombre;
            Con_Apellido = apellido;
            ConCargo = string.Empty;
            Con_Telefonos = null; 
        }

       /// <summary>
       /// Constructor de la Clase Contacto
       /// </summary>
        /// <param name="id">Número de Cédula o Identificador de la Clase Contacto</param>
        /// <param name="nombre">Nombres de la Persona Contacto de la Empresa</param>
        /// <param name="apellido">Apellidos de la Persona Contacto de la Empresa</param>
       /// <param name="cargo">Cargo que ocupa la Persona Contacto dentro de la Empresa</param>
        public Contacto(int id, string nombre, string apellido, string cargo) 
        {
            Con_Id = id;
            Con_Nombre = nombre;
            Con_Apellido = apellido;
            ConCargo = cargo;
            Con_Telefonos = null;
            ConClienteJurid = null;
            ConClienteNat = null; 
        }



       /// <summary>
       /// Constructor de la Clase Contacto
       /// </summary>
        /// <param name="id">Número de Cédula o Identificador de la Clase Contacto</param>
        /// <param name="nombre">Nombres de la Persona Contacto de la Empresa</param>
        /// <param name="apellido">Apellidos de la Persona Contacto de la Empresa</param>
        /// <param name="cargo">Cargo que ocupa la Persona Contacto dentro de la Empresa</param>
       /// <param name="telefonos">Télefonos de la Persona Contacto</param>
        public Contacto(int id, string nombre, string apellido, string cargo, List<string> telefonos) 
        {
            Con_Id = id;
            Con_Nombre = nombre;
            Con_Apellido = apellido;
            ConCargo = cargo;
            Con_Telefonos = telefonos;
            ConClienteJurid = null;
            ConClienteNat = null; 
        
        }

     /// <summary>
     /// Constructor de la Clase Contacto
     /// </summary>
     /// <param name="id">Número de Cédula o Identificador de la Clase Contacto</param>
     /// <param name="nombre">Nombres de la Persona Contacto de la Empresa</param>
     /// <param name="apellido">Apellidos de la Persona Contacto de la Empresa</param>
     /// <param name="cargo">Cargo que ocupa la Persona Contacto dentro de la Empresa</param>
     /// <param name="clienteNatural">El cliente natural del contacto</param>
     /// <param name="telefonos">Télefonos de la Persona Contacto</param>
       public Contacto(int id, string nombre, string apellido, string cargo, ClienteNatural clienteNatural ,List<string> telefonos)
       {
           Con_Id = id;
           Con_Nombre = nombre;
           Con_Apellido = apellido;
           ConCargo = cargo;
           Con_Telefonos = telefonos;
           ConClienteJurid = null;
           ConClienteNat = clienteNatural; 
       }

       /// <summary>
       /// Constructor de la Clase Contacto
       /// </summary>
       /// <param name="id">Número de Cédula o Identificador de la Clase Contacto</param>
       /// <param name="nombre">Nombres de la Persona Contacto de la Empresa</param>
       /// <param name="apellido">Apellidos de la Persona Contacto de la Empresa</param>
       /// <param name="cargo">Cargo que ocupa la Persona Contacto dentro de la Empresa</param>
       /// <param name="clienteJuridico">El cliente jurídico o empresa a la que pertenece el contacto</param>
       /// <param name="telefonos"></param>
       public Contacto(int id, string nombre, string apellido, string cargo, ClienteJuridico clienteJuridico, List<string> telefonos)
       {
           Con_Id = id;
           Con_Nombre = nombre;
           Con_Apellido = apellido;
           ConCargo = cargo;
           Con_Telefonos = telefonos;
           ConClienteJurid = clienteJuridico;
           ConClienteNat = null; 
               
       }

        #endregion

    }
}
