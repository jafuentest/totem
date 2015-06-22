using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DAO.IntefazDAO.Modulo8
{
    public interface IDaoInvolucradosMinuta
    {


        /// <summary>
        /// Firma del metodo para consultar los datos de Usuario
        /// </summary>
        /// <param name="idUsuario">id del Usuarios</param>
        /// <returns>Retorna el Objeto Usuario</returns>
        Entidad ConsultarUsuarioMinutas(int idUsuario);
        /// <summary>
        /// Firma del metodo para consultar los datos de contacto
        /// </summary>
        /// <param name="idContacto">id del Contacto</param>
        /// <returns>Retorna el Objeto Contacto</returns>
        Entidad ConsultarContactoMinutas(int idContacto);

        /// <summary>
        /// Firma del metodo para la consulta de todos los involucrados en una Minuta o los responsables de un Acuerdo
        /// </summary>
        /// <param name="procedure">Es el nombre del procedimiento que se ejecutara</param>
        /// <param name="atributoInvo">Es el id del Contacto o Usuario segun sea el caso que el procedimiento
        /// retornara</param>
        /// <param name="parametro">Es el nombre del parametro minuta que que ejecuta en la BD el 
        /// procedimiento</param>
        /// <param name="id">Es el id del Acuerdo o Minuta que se encuentra vinculado con los 
        /// Involucrados</param>
        /// <returns></returns>
        List<int> ConsultarInvolucrado(string procedure, string atributoInvo, string parametro, string id);
        
        /// <summary>
        /// Firma del metodo para agregar un Usuario a la BD
        /// </summary>
        /// <param name="usuario">Usuario a agregar</param>
        /// <param name="idAcuerdo">id de Acuerdo vinculado</param>
        /// <param name="idProyecto">id de Proyecto</param>
        /// <returns>Retorna un Boolean para saber si se realizo la operación con éxito</returns>
        Boolean AgregarUsuarioEnAcuerdo(Entidad usuario, string idProyecto);


        /// <summary>
        /// Firma del metodo para agregar involucrado a la BD
        /// </summary>
        /// <param name="involucrado">involucrado a agregar</param>
        /// <param name="idProyecto">id de Proyecto</param>
        /// <param name="procedure">procedure a llamar</param>
        /// <param name="parametro">parametro a utilizar</param>
        /// <returns>Retorna un Boolean para saber si se realizo la operación con éxito</returns>
        bool AgregarInvolucradoEnMinuta(int involucrado, string idProyecto, string procedure, string parametro);
       
        /// <summary>
        /// Firma del metodo para Agregar un Contacto a un Acuerdo a la BD
        /// </summary>
        /// <param name="contacto">Contacto a agregar</param>
        /// <param name="idAcuerdo">id del Acuerdo vinculado</param>
        /// <param name="idProyecto">id de Proyecto</param>
        /// <returns>Retorna un Boolean para saber si se realizo la operación con éxito</returns>
        bool AgregarContactoEnAcuerdo(Entidad contacto, string idProyecto);

        /// <summary>
        /// Firma del metodo para eliminar un Usuario de un Acuerdo
        /// </summary>
        /// <param name="usuario">Usuario que se desea eliminar</param>
        /// <param name="idAcuerdo">id de Acuerdo vinculado</param>
        /// <param name="idProyecto">id del Proyecto</param>
        /// <returns>Retorna un Boolean para saber si se realizo la operación con éxito</returns>
        bool EliminarUsuarioEnAcuerdo(Entidad usuario, int idAcuerdo, string idProyecto);
        

        /// <summary>
        /// Firma del metodo para eliminar un Contacto de un Acuerdo
        /// </summary>
        /// <param name="Contacto">Contacto a eliminar</param>
        /// <param name="idAcuerdo">id del acuerdo vinculado</param>
        /// <param name="idProyecto">id del proyecto</param>
        /// <returns>Retorna un Boolean para saber si se realizo con exito la operación</returns>
        bool EliminarContactoEnAcuerdo(Entidad contacto, int idAcuerdo, string idProyecto);


        /// <summary>
        /// Firma del metodo para eliminar involucrados de una minuta
        /// </summary>
        /// <param name="idMinuta">minuta a eliminar involucrados</param>
        /// <returns>Retorna un Boolean para saber si se realizo con exito la operación</returns>
        bool EliminarInvolucradoEnMinuta(int idMinuta);
        
      


    }
}
