
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


        #region Creates
        /// <summary>
        /// Método para Crear un proyecto con cliente juridico en la bd
        /// </summary>
        /// <param name="proyecto">Proyecto a insertar en la bd</param>
        /// <param name="clienteJuridico">Cliente juridico del proyecto a insertar </param>
        /// <returns>Retrorna el proyecto</returns>
        public Proyecto CrearProyectoClienteJuridico(Proyecto proyecto, ClienteJuridico clienteJuridico)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para Crear un proyecto con cliente natural en la bd
        /// </summary>
        /// <param name="proyecto">Proyecto a insertar en la bd</param>
        /// <param name="clienteNatural">Cliente natural del proyecto a insertar </param>
        /// <returns>Retrorna el proyecto</returns>
        public Proyecto CrearProyectoClienteNatural(Proyecto proyecto, ClienteNatural clienteNatural )
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Consulta
        /// <summary>
        /// Método para consultar un proyecto en la bd
        /// </summary>
        /// <param name="codigo">Codigo del proyecto a consultar</param>
        /// <returns>Retrorna el proyecto</returns>
        public Proyecto ConsultarProyecto(String codigo)
        {
            throw new NotImplementedException();
        }

        #endregion


        public Proyecto ObtenerObjetoProyecto(SqlDataReader BDProyecto)
        {
            throw new NotImplementedException();

        }
    }
}
