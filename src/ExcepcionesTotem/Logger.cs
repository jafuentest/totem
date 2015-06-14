using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;

namespace ExcepcionesTotem
{
    public class Logger
    {
        /// <summary>
        /// Metodo que escribe mensajes de error en un log
        /// </summary>
        /// <param name="clase">Clase en la que ocurrio el error</param>
        /// <param name="ex">excepcion que ocurrio</param>
        public static void EscribirError(string clase, Exception ex)
        {
            if (clase != null && ex != null && clase != "")
            {
                XmlConfigurator.Configure();
                ILog log = LogManager.GetLogger(clase);
                log.Error("*******************************************************");
                log.Error("Mensaje: " + ex.Message);
                log.Error("Origen: " + ex.Source);
                log.Error("Metodo: " + ex.TargetSite);
                log.Error("StackTrace: " + ex.StackTrace);
                log.Error("InnerException: " + ex.InnerException);
            }
            else
            {
                throw new LoggerException(ExcepcionesTotemRecursosGenerales.Codigo_Error_Log,
                    ExcepcionesTotemRecursosGenerales.Mensaje_Error_Log,
                    new LoggerException());
            }
        }
        /// <summary>
        /// Metodo que escribe mensajes de info en un log
        /// </summary>
        /// <param name="clase">Clase en la que se llama</param>
        /// <param name="mensaje">mensaje a mostrar en el log</param>
        /// <param name="metodo">metodo en la que se origino</param>
        public static void EscribirInfo(string clase, string mensaje,
            string metodo)
        {
            if (clase != null && clase != "" && mensaje != null && mensaje != ""
                && metodo != null && metodo != "")
            {
                XmlConfigurator.Configure();
                ILog log = LogManager.GetLogger(clase);
                log.Error("*******************************************************");
                log.Error("Mensaje: " + mensaje);
                log.Error("Metodo: " + metodo);
            }
            else
            {
                throw new LoggerException(ExcepcionesTotemRecursosGenerales.Codigo_Error_Log,
                    ExcepcionesTotemRecursosGenerales.Mensaje_Error_Log,
                    new LoggerException());
            }
        }
        /// <summary>
        /// Metodo que escribe mensajes de warning en un log
        /// </summary>
        /// <param name="clase">Clase en la que se llama</param>
        /// <param name="mensaje">mensaje a mostrar en el log</param>
        /// <param name="metodo">metodo en la que se origino</param>
        public static void EscribirWarning(string clase, string mensaje,
            string metodo)
        {
            if (clase != null && clase != "" && mensaje != null && mensaje != ""
                && metodo != null && metodo != "")
            {
                XmlConfigurator.Configure();
                ILog log = LogManager.GetLogger(clase);
                log.Error("*******************************************************");
                log.Error("Mensaje: " + mensaje);
                log.Error("Metodo: " + metodo);
            }
            else
            {
                throw new LoggerException(ExcepcionesTotemRecursosGenerales.Codigo_Error_Log,
                    ExcepcionesTotemRecursosGenerales.Mensaje_Error_Log,
                    new LoggerException());
            }
        }
    }
}
