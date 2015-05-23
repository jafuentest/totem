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

       
        private List<String> conTelefonos;

        #endregion

        #region Gets y Sets


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


        public List<String> Con_Telefonos
        {
            get { return conTelefonos; }
            set { conTelefonos = value; }
        }
        public string ConCargo
        {
            get { return conCargo; }
            set { conCargo = value; }
        }


     #endregion
    }
}
