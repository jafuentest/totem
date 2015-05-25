using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DatosTotem
{
    /// <summary>
    /// Clase para el manejo de parametros de la base de datos
    /// Atributos:
    /// etiqueta: etiqueta del parametro ejemplo: @nombreDeUsuario
    /// tipoDato: SqlDbType con el tipo de dato del parametro ejemplo: SqlDbType.VarChar
    /// valor: string con el valor que se le asigno al parametro ejemplo: Pepe
    /// </summary>
    public class Parametro
    {
        public string etiqueta { get; set; }
        public SqlDbType tipoDato { get; set; }
        public string valor { get; set; }

        /// <summary>
        /// Metodo constructor con campos vacios
        /// </summary>
        public Parametro()
        {
        }

        /// <summary>
        /// Metodo constructor con todos los campos asignados
        /// </summary>
        /// <param name="etiqueta">etiqueta del parametro ejemplo: @nombreDeUsuario</param>
        /// <param name="tipoDato">SqlDbType con el tipo de dato del parametro 
        /// ejemplo: SqlDbType.VarChar</param>
        /// <param name="valor">valor: string con el valor que se le asigno al 
        /// parametro ejemplo: Pepe</param>
        public Parametro(string etiqueta, SqlDbType tipoDato, string valor)
        {
            this.etiqueta = etiqueta;
            this.tipoDato = tipoDato;
            this.valor = valor;
        }


    }
}
