using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Presentadores
{
    /// <summary>
    /// Clase encargada de resolver validaciones de expresiones regulares y cualquier
    /// otro tipo de validacion requerida sobre un dato que se ingreso por el usuario
    /// al sistema
    /// </summary>
    public static class Validaciones
    {

        #region Metodos de validaciones

        ///<sumary>
        ///Metodo que valida la expresion regular en una lista de datos
        ///</sumary>
        ///<param name="datos">Lista de String con los datos a validar</param>
        ///<param name="expresionRegular">Regex con la expresion regular a validar</param>
        ///<returns>true, si todo los datos de la lista cumplen con la expresion regular
        ///         false, si al menos un dato no cumple con la expresion regular</returns>
        public static bool ValidarExpresionRegular(List<String> datos, Regex expresionRegular)
        {
            for (int i = 0; i < datos.Count; i++)
            {
                if (!expresionRegular.IsMatch(datos[i]))
                {
                   return false;
                }
            }
            return true;
        }

        ///<sumary>
        ///Metodo que se encarga de validar si los datos de la lista alguno de ellos esta vacio  
        ///</sumary>
        ///<param name="datos">Lista de String con los datos a validar</param>
        ///<returns>true, sin ningun dato en la lista esta vacio
        ///         false, si al menos un dato es igual a vacio</returns>
        public static bool ValidarCamposVacios(List<String> datos)
        {
            String caracterVacio = "";

            for (int i = 0; i < datos.Count; i++)
            {
                if (datos[i].Equals(caracterVacio))
                {
                    return false;
                }
            }
            return true;
        }

        ///<sumary>
        ///Metodo que se encarga de validar en la lista de datos si cumplen 
        ///con la expresion regular solo de caracteres alfabeticos  
        ///</sumary>
        ///<param name="datos">Lista de String con los datos a validar</param>
        ///<returns>true, si todo los datos de la lista cumplen con la expresion regular
        ///         false, si al menos un dato no cumple con la expresion regular</returns>
        public static bool ValidarCaracteresAlfabeticos(List<String> datos)
        {
            Regex regex = new Regex(RecursosGeneralPresentadores.Expresion_Regular_Alfabeticos);
            return ValidarExpresionRegular(datos, regex);
        }

        ///<sumary>
        ///Metodo que se encarga de validar en la lista de datos si cumplen 
        ///con la expresion regular solo de caracteres alfanumericos 
        ///Retorno: true, si todo los datos de la lista cumplen con la expresion regular
        ///         false, si al menos un dato no cumple con la expresion regular
        ///</sumary>
        public static bool ValidarCaracteresAlfaNumericos(List<String> datos)
        {
            Regex regex = new Regex(RecursosGeneralPresentadores.Expresion_Regular_Alfanumericos);
            return ValidarExpresionRegular(datos, regex);

        }

        /// <summary>
        /// Metodo que se encarga de validad en la lista de datos si cumplen
        /// con la expresion regular de caracteres numericos
        /// </summary>
        /// <param name="datos">Lista de String con los datos del proyecto</param>
        /// <returns>boolean: true, si los datos cumplen con la expresion regular
        ///                 false, si los datos no cumplen con la expresion regular</returns>
        public static bool ValidarCaracteresNumericos(List<String> datos)
        {
            Regex regex = new Regex(RecursosGeneralPresentadores.Expresion_Regular_Numericos);
            return ValidarExpresionRegular(datos, regex);
        }

        /// <summary>
        /// Metodo que valida que la lista de fechas no sean mayores a la fecha actual del sistema
        /// </summary>
        /// <param name="datos">Lista de Fechas con las que se va a validar </param>
        /// <returns>boolean: true, si las fechas son menores a la fecha actual del sistema
        ///                     false, si por lo menos una fecha es mayor a la fecha actual</returns>
        public static bool ValidarFechasConLaFechaActualMenores(List<DateTime> datos)
        {
            DateTime fechaActual = DateTime.Now;
            for (int i = 0; i < datos.Count; i++)
            {
                if (datos[i].CompareTo(fechaActual) > 0)
                {
                    return false;
                }
            }

            return true;
        }


        #endregion
    }
}
