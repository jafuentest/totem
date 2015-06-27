using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos.IntefazDAO.Modulo8
{
    public interface IDaoPunto : IDao<Entidad, bool, Entidad>
    {
        /// <summary>
        /// Metodo para Agregar un punto en especifico de cualquier Minuta
        /// </summary>
        /// <param name="punto">Objeto Minuta, con todos los valores a modificar</param>
        /// <param name="idMinuta">Id de la Minuta relcionada</param>
        /// <returns>retorna el id del punto insertado en caso contrario retorna 0</returns>
        int AgregarPunto(Entidad punto, int idMinuta);
        /// <summary>
        /// Firma de metodo para para consultar los puntos de una minuta
        /// </summary>
        /// <param name="idMinuta">Id de la Minuta a consultar</param>
        /// <returns>Retorna una lista de Puntos</returns>
        List<Entidad> ConsultarPuntoBD(int idMinuta);


        /// <summary>
        /// Firma de metodo para modificar un punto en especifico de cualquier Minuta
        /// </summary>
        /// <param name="punto">Objeto Punto, con todos los valores a modificar</param>
        /// <param name="idMinuta">Id de la Minuta relcionada</param>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        Boolean ModificarPuntoBD(Entidad punto, int idMinuta);

        /// <summary>
        /// Firma de metodo para para Eliminar un Punto de una Minuta
        /// </summary>
        /// <param name="punto">Objeto Punto</param>
        /// <param name="idMinuta">Id de la Minuta del punto a eliminar</param>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        Boolean EliminarPuntoBD(Entidad punto, int idMinuta);
       
    }
}