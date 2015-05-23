using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
   public class ClienteNatural
    {

        #region Atributos
        private string cliNat_Id;
        private string cliNat_Nombre;
        private string cliNat_Apellido;
        private string cliNat_Direccion;
        private string cliNat_Correo;
        private List<string> cliNat_Telefonos;

        #endregion


        #region Propiedades
        public string Nat_Id
        {
            get { return cliNat_Id;  }
            set { cliNat_Id = value; }
        }



        public string Nat_Nombre
        {
            get { return cliNat_Nombre; }
            set { cliNat_Nombre = value; }
        }



        public string Nat_Apellido
        {
            get { return cliNat_Apellido; }
            set { cliNat_Apellido = value; }
        }

        public string Nat_Direccion
        {
            get { return cliNat_Direccion; }
            set { cliNat_Direccion = value; }
        }


        public string Nat_Correo
        {
            get { return cliNat_Correo; }
            set { cliNat_Correo = value; }
        }

        public List<string> Nat_Telefonos
        {
            get { return cliNat_Telefonos; }
            set { cliNat_Telefonos = value; }
        }


        #endregion


       /// <summary>
       /// Constructor de la Clase Cliente Natural 
       /// </summary>
        public ClienteNatural() 
        {
            Nat_Id = string.Empty;
            Nat_Nombre = string.Empty;
            Nat_Apellido = string.Empty;
            Nat_Correo = string.Empty;
            Nat_Direccion = string.Empty;
            Nat_Telefonos = null; 
        
        }


       /// <summary>
       /// Constructor de la Clase Cliente Natural
       /// </summary>
       /// <param name="nombre">Nombre del Cliente</param>
       /// <param name="apellido">Apellido del Cliente </param>
        public ClienteNatural(string nombre, string apellido)
        {
            Nat_Id = string.Empty;
            Nat_Nombre = nombre;
            Nat_Apellido = apellido;
            Nat_Correo = string.Empty;
            Nat_Direccion = string.Empty;
            Nat_Telefonos = null;

        }

       /// <summary>
       /// Constructor de la Clase Cliente Natural
       /// </summary>
       /// <param name="id">Número de Cédula o Identificador del Cliente</param>
       /// <param name="nombre">Nombre del Cliente </param>
       /// <param name="apellido">Apellido del Cliente</param>
        public ClienteNatural(string id, string nombre, string apellido)
        {
            Nat_Id = id;
            Nat_Nombre = nombre;
            Nat_Apellido = apellido;
            Nat_Correo = string.Empty;
            Nat_Direccion = string.Empty;
            Nat_Telefonos = null;

        }


       /// <summary>
       /// Constructor de la clase Cliente Natural
       /// </summary>
       /// <param name="id">Número de Cédula o Identificador del Cliente</param>
       /// <param name="nombre">Nombre del Cliente</param>
       /// <param name="apellido">Apellido del Cliente</param>
       /// <param name="correo">Correo del Cliente</param>
        public ClienteNatural(string id, string nombre, string apellido, string correo)
        {
            Nat_Id = id;
            Nat_Nombre = nombre;
            Nat_Apellido = apellido;
            Nat_Correo = correo;
            Nat_Direccion = string.Empty;
            Nat_Telefonos = null;

        }


       /// <summary>
       /// Constructor de la clase Cliente Natural
       /// </summary>
       /// <param name="id">Número de Cédula o Identificador del Cliente</param>
       /// <param name="nombre">Nombre del Cliente</param>
       /// <param name="apellido">Apellido del Cliente</param>
       /// <param name="correo">Correo del Cliente</param>
       /// <param name="direccion">Dirección del Cliente</param>
        public ClienteNatural(string id, string nombre, string apellido, string correo, string direccion)
        {
            Nat_Id = id;
            Nat_Nombre = nombre;
            Nat_Apellido = apellido;
            Nat_Correo = correo;
            Nat_Direccion = direccion;
            Nat_Telefonos = null;
        }


       /// <summary>
       /// Constructor de la clase Cliente Natural
       /// </summary>
       /// <param name="id">Número de Cédula o Identificador del Cliente</param>
       /// <param name="nombre">Nombre del Cliente</param>
       /// <param name="apellido">Apellido del Cliente</param>
       /// <param name="correo">Correo del Cliente</param>
       /// <param name="direccion">Dirección del Cliente</param>
       /// <param name="telefonos">Télefonos del Cliente</param>
        public ClienteNatural(string id, string nombre, string apellido, string correo, string direccion, List<string> telefonos)
        {
            Nat_Id = id;
            Nat_Nombre = nombre;
            Nat_Apellido = apellido;
            Nat_Correo = correo;
            Nat_Direccion = direccion;
            Nat_Telefonos = telefonos;
        }




    }
}
