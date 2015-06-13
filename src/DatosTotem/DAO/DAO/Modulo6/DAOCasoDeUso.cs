using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo6;
using DAO.IntefazDAO.Modulo6;
using Dominio;
using System.Data.SqlClient;
using System.Data; 

namespace DAO.DAO.Modulo6
{
   public class DAOCasoDeUso: DAO, IDaoCasoDeUso
    {
        /// <summary>
        /// Método de Dao que se conecta a Base de Datos
        /// para agregar un Caso de Uso
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad Caso de Uso
        /// con los datos del caso de uso a ser agregado</param>
        /// <returns>True si lo agregó, false en caso contrario</returns>
        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>
        /// Método de DAO que accede a la Base de Datos 
        /// para actualizar los datos de un Caso de Uso
        /// </summary>
        /// <param name="parametro">Objeto Entidad de tipo Caso de Uso</param>
        /// <returns>True si modificó, false en 
        /// caso contrario</returns>
        public bool Modificar(Entidad parametro)
        {
            return false;
        }

        /// <summary>
        /// Método que accede a Base de Datos para
        /// consultar los datos específicos de un caso de uso.
        /// </summary>
        /// <param name="parametro">El Caso de Uso a consultar</param>
        /// <returns>Los datos específicos del Actor</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            Entidad laEntidad;
            laEntidad = FabricaEntidades.ObtenerCasoDeUso();
            return laEntidad;
        }

        /// <summary>
        /// Método de DAO que accede a la Base de Datos
        /// para traer una lista de todos los casos de usos registrados
        /// en Base de Datos.
        /// </summary>
        /// <returns>Lista de todos los casos de uso</returns>
        public List<Entidad> ConsultarTodos()
        {
            return new List<Entidad>();
        }
    }
}
