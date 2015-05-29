using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LogicaNegociosTotem.Modulo4
{
    /// <summary>
    /// Clase que maneja la logica de los proyectos
    /// </summary>
    public static class LogicaProyecto
    {

        #region Crear


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
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException e)
            {
                throw e;
            }
            catch (Exception e)
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
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException e)
            {
                throw e;
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
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException e)
            {
                throw e;
            }
        }

        #endregion

        #region Consultar
        /// <summary>
        /// Metodo para consultar un proyecto en BD
        /// </summary>
        /// <param name="codigo">codigo del proyecto a consultar
        /// <returns>Devuelve como resultado un proyecto en caso 
        /// contrario devuelve null</returns>
        /// 
        public static DominioTotem.Proyecto ConsultarProyecto(String codigo)
        {
            return DatosTotem.Modulo4.BDProyecto.ConsultarProyecto(codigo);
        }

        /// <summary>
        /// Metodo para consultar los proyecto de un usuario BD
        /// </summary>
        /// <param name="username">usuario para obtener sus proyectos
        /// <returns>Devuelve como resultado un DataTableen caso 
        /// contrario devuelve null</returns>
        /// 
        public static DataTable ConsultarTodosLosProyectos(String username)
        {
            try
            {
            return DatosTotem.Modulo4.BDProyecto.ConsultarProyectosUsuario(username);
            }
            catch(ExcepcionesTotem.Modulo4.InvolucradosInexistentesException e)
            {
                throw e;
            }
        }

        #endregion

        #region Modificar
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
        #endregion

        #region Generar Documentos
        /// <summary>
        /// Metodo para generar el documento ERS del un proyecto (archivo .pdf descargable).
        /// Excepciones posibles: 
        /// CasosDeUsoInexistentesException()
        /// RequerimientosInexistentesException()
        /// InvolucradosInexistentesException()
        /// </summary>
        /// <param name="codigo">Codigo del proyecto al que se le generara el ERS</param>
        public static void GenerarERS(String codigo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para generar la factura del un proyecto (archivo .pdf descargable).
        /// Excepciones posibles:
        /// RequerimientosInexistentesException()
        /// InvolucradosInexistentesException()
        /// </summary>
        /// <param name="codigo">Codigo del proyecto al que se le generara la factura</param>
        public static void GenerarFactura(String codigo)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
