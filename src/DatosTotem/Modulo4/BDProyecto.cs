
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DominioTotem;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DatosTotem.Modulo4
{
    /// <summary>
    /// Clase para el gestionamiento de as minutas, con respecto a las conexiones y llamadas
    /// a la BD
    /// </summary>
    public class BDProyecto : BDConexion
    {
        private Proyecto proyecto;


        #region Create
        /// <summary>
        /// Método para Crear un proyecto en la bd
        /// </summary>
        /// <param name="proyecto">Proyecto a insertar en la bd</param>
        /// <returns>Retrorna el proyecto</returns>
        public Proyecto CrearProyecto(Proyecto proyecto)
        {
            throw new System.NotImplementedException();
        }
        #endregion


        /// <summary>
        /// Método para consultar un proyecto en la bd
        /// </summary>
        /// <param name="codigo">Codigo del proyecto a consultar</param>
        /// <returns>Retrorna el proyecto</returns>
        public Proyecto ConsultarProyecto(String codigo)
        {
            throw new System.NotImplementedException();
        }

       


        public Proyecto ObtenerObjetoProyecto(SqlDataReader BDProyecto)
        {
            throw new System.NotImplementedException();
        }
    }
}
