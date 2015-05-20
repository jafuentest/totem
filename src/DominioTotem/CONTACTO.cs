using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
    class CONTACTO
    {
        #region Atributos
        private int Con_id;
        private string Con_nombre;
        private string Con_apellido;
        private List<TELEFONO> Con_telefonos;

        #endregion

        #region Gets y Sets


        public int Con_ID
        {
            get { return Con_id; }
            set { Con_id = value; }
        }

        public string Con_NOMBRE
        {
            get { return Con_nombre; }
            set { Con_nombre = value; }
        }
        public string Con_APELLIDO
        {
            get { return Con_apellido; }
            set { Con_apellido = value; }
        }


        public List< > Con_TELEFONOS
        {
            get { return Con_telefonos; }
            set { Con_telefonos = value; }
        }

         #endregion


        
        #region Constructores

/*

             public Contacto()
        {
            Con_id= 0;
            Con_nombre="" ;
            Con_apellido= "";
            Con_telefonos= null;
         }
   */     
          #endregion


    }
}
