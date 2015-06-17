using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Entidades.Modulo2
{
   public class Contacto : Entidad 
    {
        #region Atributos
        private String conCedula;
        private String conNombre;
        private String conApellido;
        private String conCargo;
        private Telefono conTelefono;
        private ClienteJuridico clienteJuridico;
        private ClienteNatural clienteNatural; 

        #endregion

        #region Propiedades
        public String Con_Nombre
        {
            get { return conNombre; }
            set { conNombre = value; }
        }
        public String Con_Apellido
        {
            get { return conApellido; }
            set { conApellido = value; }
        }
        public Telefono Con_Telefono
        {
            get { return conTelefono; }
            set { conTelefono = value; }
        }
        public String ConCargo
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

        public String ConCedula
        {
            get { return conCedula; }
            set { conCedula = value; }
        }
       
     #endregion

        #region Constructores

       /// <summary>
       /// Constructor de la Clase Contacto
       /// </summary>
        public Contacto() : base()
        {
            Con_Nombre = String.Empty;
            Con_Apellido = String.Empty;
            ConCargo = String.Empty;
            Con_Telefono = null;
            ConClienteJurid = null;
            ConClienteNat = null; 
        }

       /// <summary>
       /// Constructor de la Clase Contacto
       /// </summary>
       /// <param name="id">Número de Cédula o Identificador de Contacto</param>
        public Contacto(int id) : base(id)
        {
            Con_Nombre = String.Empty;
            Con_Apellido = String.Empty;
            ConCargo = String.Empty;
            Con_Telefono = null;
            ConClienteJurid = null;
            ConClienteNat = null; 
        }

       /// <summary>
       /// Constructor de la Clase Contacto
       /// </summary>
       /// <param name="nombre">Nombres de la Persona Contacto de la Empresa</param>
       /// <param name="apellido">Apellidos de la Persona Contacto de la Empresa</param>
        public Contacto(String nombre, String apellido) : base()
        {
            Con_Nombre = nombre; 
            Con_Apellido = apellido;
            ConCargo = String.Empty;
            Con_Telefono = null;
            ConClienteJurid = null;
            ConClienteNat = null; 
        }

       /// <summary>
       /// Constructor de la Clase Contacto
       /// </summary>
       /// <param name="id">Número de Cédula o Identificador de la Clase Contacto</param>
       /// <param name="nombre">Nombres de la Persona Contacto de la Empresa</param>
       /// <param name="apellido">Apellidos de la Persona Contacto de la Empresa</param>
        public Contacto(int id, String nombre, String apellido) : base(id)
        {
            Con_Nombre = nombre;
            Con_Apellido = apellido;
            ConCargo = String.Empty;
            Con_Telefono = null; 
        }

       /// <summary>
       /// Constructor de la Clase Contacto
       /// </summary>
        /// <param name="id">Número de Cédula o Identificador de la Clase Contacto</param>
        /// <param name="nombre">Nombres de la Persona Contacto de la Empresa</param>
        /// <param name="apellido">Apellidos de la Persona Contacto de la Empresa</param>
       /// <param name="cargo">Cargo que ocupa la Persona Contacto dentro de la Empresa</param>
        public Contacto(int id, String nombre, String apellido, String cargo) : base(id)
        {
            Con_Nombre = nombre;
            Con_Apellido = apellido;
            ConCargo = cargo;
            Con_Telefono = null;
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
       /// <param name="telefono">Télefonos de la Persona Contacto</param>
        public Contacto(int id, String nombre, String apellido, String cargo, Telefono telefono) : base(id)
        {
            Con_Nombre = nombre;
            Con_Apellido = apellido;
            ConCargo = cargo;
            Con_Telefono = telefono;
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
     /// <param name="telefono">Télefonos de la Persona Contacto</param>
       public Contacto(int id, String nombre, String apellido, String cargo, ClienteNatural clienteNatural,
           Telefono telefono) : base(id)
       {
           Con_Nombre = nombre;
           Con_Apellido = apellido;
           ConCargo = cargo;
           Con_Telefono = telefono;
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
       /// <param name="telefono"></param>
       public Contacto(int id, String nombre, String apellido, String cargo, ClienteJuridico clienteJuridico,
           Telefono telefono)
           : base(id)
       {
           Con_Nombre = nombre;
           Con_Apellido = apellido;
           ConCargo = cargo;
           Con_Telefono = telefono;
           ConClienteJurid = clienteJuridico;
           ConClienteNat = null;

       }
       public Contacto(String cedula, String nombre, String apellido, String cargo, Entidad clienteJuridico,
           Entidad telefono)
           : base()
       {
           ConCedula = cedula;
           Con_Nombre = nombre;
           Con_Apellido = apellido;
           ConCargo = cargo;
           Con_Telefono = (Telefono)telefono;
           ConClienteJurid = (ClienteJuridico)clienteJuridico;
           ConClienteNat = null;

       }
       public Contacto(String cedula, String nombre, String apellido, String cargo, Entidad telefono)
       {
           ConCedula = cedula;
           Con_Nombre = nombre;
           Con_Apellido = apellido;
           ConCargo = cargo;
           Con_Telefono = (Telefono)telefono;
           ConClienteNat = null;
       }
        #endregion

    }
}
