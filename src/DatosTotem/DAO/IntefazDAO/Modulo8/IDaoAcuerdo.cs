using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAO.IntefazDAO.Modulo8
{
    public interface IDaoAcuerdo : IDao<Entidad, bool, Entidad>
    {
        #region Firma de Metodos

        bool AgregarAcuerdo(Entidad parametro, int idMinuta, string idProyecto);

        /// <summary>
        /// Metodo para consultar los Acuerdos vinculados a una minuta es especifico
        /// </summary>
        /// <param name="idMinuta">id de la minuta </param>
        /// <returns>Retorna un DataTable de Acuerdos vinculados a la Minuta</returns>
        List<Entidad> ConsultarTodos(int idMinuta);

        /// <summary>
        /// Metodo para obtener los responsables Usuarios de un Acuerdo de una Minuta
        /// </summary>
        /// <param name="IdAcuerdo">Id del acuerdo del que se desea consultar</param>
        /// <returns>Retorna un DataTable de Usuarios</returns>
        List<Entidad> ObtenerUsuarioAcuerdo(int IdAcuerdo);

        /// <summary>
        /// Metodo para obtener los responsables Contactos de un Acuerdo de una Minuta
        /// </summary>
        /// <param name="IdAcuerdo">Id del acuerdo del que se desea consultar</param>
        /// <returns>Retorna un DataTable de Contactos</returns>
        List<Entidad> ObtenerContactoAcuerdo(int IdAcuerdo);

        /// <summary>
        /// Metodo para eliminar un Acuerdo de una Minuta
        /// </summary>
        /// <param name="parametro">Entidad que representa el acuerdo a eliminar</param>
        /// <param name="codigoProyecto">Codigo del unico del proyecto</param>
        /// <returns>Retorna un true o false dependiento si la accion se pudo realizar con exito o no</returns>
        bool Eliminar(Entidad parametro, String codigoProyecto);

        #endregion
    }
}