using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegociosTotem.Modulo4
{
    /// <summary>
    /// Clase que maneja la logica de los proyectos
    /// </summary>
    public static class LogicaProyecto
    {

        #region metodos


        /// <summary>
        /// Metodo para Agregar un proyecto en BD
        /// </summary>
        /// <param name="proyecto">proyecto a crear
        /// <returns>Retorna True si se crea, de lo contrario genera
        /// una exception(CodigoRepetido)</returns>
        public static bool CrearProyecto(DominioTotem.Proyecto proyecto) 
        {

            try
            {
                return DatosTotem.Modulo4.BDProyecto.CrearProyecto(proyecto);
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException)
            {
                return false;
            }
        }


        /// <summary>
        /// Metodo para Agregar un proyecto en BD
        /// </summary>
        /// <param name="proyecto">proyecto a crear
        /// <param name="clienteJuridico">Cliente juridico del proyecto</param>
        /// <returns>Retorna True si se crea, de lo contrario genera
        /// una exception(CodigoRepetido)</returns>
        public static bool CrearProyecto(DominioTotem.Proyecto proyecto, DominioTotem.ClienteJuridico clienteJuridico)
        {

            try
            {
                return DatosTotem.Modulo4.BDProyecto.CrearProyecto(proyecto,clienteJuridico);
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException)
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo para Agregar un proyecto en BD
        /// </summary>
        /// <param name="proyecto">proyecto a crear
        /// <param name="clienteNatural">Cliente natural del proyecto</param>
        /// <returns>Retorna True si se crea, de lo contrario genera
        /// una exception(CodigoRepetido)</returns>
        public static bool CrearProyecto(DominioTotem.Proyecto proyecto, DominioTotem.ClienteNatural clienteNatural)
        {

            try
            {
                return DatosTotem.Modulo4.BDProyecto.CrearProyecto(proyecto, clienteNatural);
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException)
            {
                return false;
            }
        }


        /// <summary>
        /// Metodo para consultar un proyecto en BD
        /// </summary>
        /// <param name="codigo">codigo del proyecto a consultar
        /// <returns>Devuelve como resultado un proyecto en caso 
        /// contrario devuelve null</returns>
        /// 
        public static DominioTotem.Proyecto ConsultarProyecto(String codigo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para Modificar un proyecto en BD
        /// </summary>
        /// <param name="proyecto">proyecto a crear
        /// <returns>Devuelve True si lo modifica, de lo contrario devuelve false</returns>
        public static bool ModificarProyecto(DominioTotem.Proyecto proyecto, String codigoAnterior)
        {
            try
            {
                return DatosTotem.Modulo4.BDProyecto.ModificarProyecto(proyecto, codigoAnterior);
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException)
            {
                return false;
            }
        }

        public static void GenerarERS(DominioTotem.Proyecto proyecto)
        {
            throw new NotImplementedException();
        }

        public static void GenerarFactura(DominioTotem.Proyecto proyecto)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
