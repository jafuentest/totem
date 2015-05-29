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
    /// Clase que maneja la logica de los requerimientos
    /// </summary>
    public static class LogicaRequerimiento
    {
        #region Crear


        /// <summary>
        /// Metodo para Agregar un requerimiento en la BD
        /// </summary>
        /// <param name="requerimiento">requerimiento a crear
        ///  /// <param name="proyecto">proyecto al que se le agrega el requerimiento</param>
        /// <returns>Retorna True si se crea, de lo contrario genera
        /// una exception(///)</returns>
        /// 
       /* public static bool CrearRequerimiento(DominioTotem.Requerimiento requerimiento, DominioTotem.Proyecto proyecto)
        {

            try
            {
                return DatosTotem.Modulo5.BDRequerimiento.CrearRequerimiento(requerimiento);
            }
           
            catch (Exception e)
            {
                return false;
            }
        }/*

        #endregion

        #region Consultar
        /// <summary>
        /// Metodo para consultar un proyecto en BD
        /// </summary>
        /// <param name="codigo">codigo del proyecto a consultar
        /// <returns>Devuelve como resultado un proyecto en caso 
        /// contrario devuelve null</returns>
        /// 
       /* public static DominioTotem.Proyecto ConsultarRequerimiento(String codigo)
        {
            return DatosTotem.Modulo5.BDRequerimiento.ListarRequerimientosPorProyecto(codigo);
        }*/

        #endregion






    }
}
