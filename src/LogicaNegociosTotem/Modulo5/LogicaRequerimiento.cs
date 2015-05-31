using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using DominioTotem;

namespace LogicaNegociosTotem.Modulo5
{
    /// <summary>
    /// Clase que maneja la lógica de los requerimientos
    /// </summary>
    public static class LogicaRequerimiento
    {
	   /*
        #region Crear
        /// <summary>
        /// Metodo para Agregar un requerimiento en la BD
        /// </summary>
        /// <param name="requerimiento">requerimiento a crear
        /// <param name="proyecto">proyecto al que se le agrega el requerimiento</param>
        /// <returns>Retorna True si se crea, de lo contrario genera
        /// una exception()</returns>

        public static bool CrearRequerimiento(DominioTotem.Requerimiento requerimiento, DominioTotem.Proyecto proyecto)
        {

            try
            {
                return DatosTotem.Modulo5.BDRequerimiento.CrearRequerimiento(requerimiento);
            }
           
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
	   */

	   #region Consultar requerimientos por proyecto
	   /// <summary>
        /// Método que permite consultar los requerimientos de un proyecto
        /// </summary>
        /// <param name="codigo">
	   /// Código del proyecto a ser consultado
        /// <returns>
	   /// Devuelve como resultado una lista con todos los
	   /// requerimientos correspondientes al proyecto seleccionado
	   /// </returns>
	   public static List<Requerimiento>
		  ConsultarRequerimientosPorProyecto(int codigo)
        {
		  return DatosTotem.Modulo5.BDRequerimiento.
			 ConsultarRequerimientosPorProyecto(codigo);
        }
        #endregion

    }
}
