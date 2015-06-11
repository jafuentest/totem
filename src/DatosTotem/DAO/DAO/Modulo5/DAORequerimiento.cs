using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO.DAO.Modulo5
{
    public class DAORequerimiento : DAO, IntefazDAO.Modulo5.IDaoRequerimiento
    {
        /// <summary>
        /// Metodo que busca el ID de un proyecto en la base de datos
        /// usando el codigo del proyecto
        /// </summary>
        /// <param name="codigo">codigo del proyecto</param>
        /// <returns>integer con el id del proyecto</returns>
        public int BuscarIdProyecto(string codigo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que verifica el requerimiento en la base de datos
        /// </summary>
        /// <param name="requerimiento">Requerimiento a validar</param>
        /// <returns>true si existe el requerimiento</returns>
        public bool VerificarRequerimiento(Dominio.Entidad requerimiento)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que elimina un requerimiento asociado a un proyecto
        /// </summary>
        /// <param name="requerimiento">Requerimiento a eliminar</param>
        /// <param name="idProyecto">id del proyecto</param>
        /// <returns>true si lo logro eliminar</returns>
        public bool EliminarRequerimiento(Dominio.Entidad requerimiento, int idProyecto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que retorna todos los requerimientos asociados a un proyecto
        /// </summary>
        /// <param name="codigoProyecto">Codigo del proyecto</param>
        /// <returns>Lista de requerimientos</returns>
        public List<Dominio.Entidad> ConsultarRequerimientoDeProyecto(string codigoProyecto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que se encarga de agregar requerimientos a un proyecto
        /// </summary>
        /// <param name="requerimiento">requerimiento a agregar</param>
        /// <param name="idProyecto">id del proyecto asociado</param>
        /// <returns>true si logro agregarlo</returns>
        public bool AgregarRequerimiento(Dominio.Entidad requerimiento, int idProyecto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <returns></returns>
        public bool Agregar(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que modifica un requerimiento en la base de datos
        /// </summary>
        /// <param name="parametro">Requerimiento a modificar</param>
        /// <returns>true si lo logro modificar</returns>
        public bool Modificar(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que busca a un requerimiento por su codigo
        /// </summary>
        /// <param name="parametro">Requerimiento con su codigo</param>
        /// <returns>Requerimiento con todos los datos</returns>
        public Dominio.Entidad ConsultarXId(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo no implementado
        /// </summary>
        /// <returns></returns>
        public List<Dominio.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
