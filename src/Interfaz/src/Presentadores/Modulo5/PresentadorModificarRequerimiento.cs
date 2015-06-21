using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentadores.Modulo5
{
    public class PresentadorModificarRequerimiento
    {
        private Contratos.Modulo5.IContratoModificarRequerimiento vista;

        public PresentadorModificarRequerimiento(Contratos.Modulo5.IContratoModificarRequerimiento vista)
        {
            this.vista = vista;
        }


        /// <summary>
        /// Metodo encargado de eliminar un requerimiento particular
        /// </summary>
        public void EliminarRequerimiento()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado de modificar un requerimiento particular
        /// </summary>
        public void ModificarRequerimiento()
        {

            throw new NotImplementedException();

        }

        /// <summary>
        /// Metodo que carga los datos en la interfaz de modificar
        /// </summary>
        public void CargarDatos()
        {

        }
    }
}
