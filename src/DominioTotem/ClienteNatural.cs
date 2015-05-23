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
        private string cliNat_Telefono;

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

        public string Nat_Telefono
        {
            get { return cliNat_Telefono; }
            set { cliNat_Telefono = value; }
        }


        #endregion



    }
}
