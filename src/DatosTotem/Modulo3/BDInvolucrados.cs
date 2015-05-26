using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;
using ExcepcionesTotem.Modulo1;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace DatosTotem.Modulo3
{
    public static class BDInvolucrados
    {
        /// <summary>
        /// Metodo que agrega la lista de usuarios involucrados a un proyecto
        /// </summary>
        /// <param name="lista">lista de usuarios a insertar</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public static bool agregarUsuariosInvolucrados(ListaInvolucradoUsuario listaUsuarios)
        {    
            Proyecto elProyecto = listaUsuarios.Proyecto;
            List<Parametro> parametros;

            Parametro paramProyectoCod, paramUsername; 
            BDConexion laConexion;

            foreach (Usuario elUsuario in listaUsuarios.Lista)
            {
                try
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    paramProyectoCod = new Parametro(RecursosBDModulo3.ParamCodProy, SqlDbType.VarChar, 
                        elProyecto.Codigo, false);
                    paramUsername = new Parametro(RecursosBDModulo3.ParamUsername, SqlDbType.VarChar, 
                        elUsuario.username, false);

                    parametros.Add(paramUsername);
                    parametros.Add(paramProyectoCod);

                    laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredInsertarUsuario, parametros);
                }
                catch (SqlException ex)
                {
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                }

            }
            return true;
        }
        /// <summary>
        /// Metodo que agrega la lista de contactos involucrados a un proyecto
        /// </summary>
        /// <param name="lista">lista de contactos a insertar</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public static bool agregarContactosInvolucrados(ListaInvolucradoContacto listaContactos)
        {
            Proyecto elProyecto = listaContactos.Proyecto;
            List<Parametro> parametros;

            Parametro paramProyectoCod, paramContactoID; 
            BDConexion laConexion;

            foreach (Contacto elContacto in listaContactos.Lista)
            {
                try
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    paramProyectoCod = new Parametro(RecursosBDModulo3.ParamCodProy, SqlDbType.VarChar, 
                        elProyecto.Codigo, false);
                    paramContactoID = new Parametro(RecursosBDModulo3.ParamContID, SqlDbType.Int, 
                        elContacto.Con_Id.ToString(), false);

                    parametros.Add(paramContactoID);
                    parametros.Add(paramProyectoCod);

                    laConexion.EjecutarStoredProcedure(RecursosBDModulo3.StoredInsertarCliente, parametros);
                }
                catch (SqlException ex)
                {
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                }

            }
            return true;
        }
        /// <summary>
        /// Metodo que consulta los usuarios involucrados a un proyecto dado
        /// </summary>
        /// <param name="p">proyecto del que se desean saber los involucrados</param>
        /// <returns>lista de usuarios involucrados al proyecto que recibe como parametro</returns>
        public static ListaInvolucradoUsuario consultarUsuariosInvolucradosPorProyecto(Proyecto p)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Metodo que consulta los contactos involucrados a un proyecto dado
        /// </summary>
        /// <param name="p">proyecto del que se desean saber los involucrados</param>
        /// <returns>lista de contactos involucrados al proyecto que recibe como parametro</returns>
        public static ListaInvolucradoContacto consultarContactosInvolucradosPorProyecto(Proyecto p)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Metodo que elimina un contacto involucrado a un proyecto
        /// </summary>
        /// <param name="c">contacto a eliminar</param>
        /// <param name="p">proyecto al que esta asociado</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public static bool eliminarContactoDeIvolucradosEnProyecto(Contacto c, Proyecto p)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Metodo que elimina un usuario involucrado a un proyecto
        /// </summary>
        /// <param name="c">usuario a eliminar</param>
        /// <param name="p">proyecto al que esta asociado</param>
        /// <returns>Valor booleano que refleja el exito de la operacion</returns>
        public static bool eliminarUsuariosDeIvolucradosEnProyecto(Usuario u, Proyecto p)
        {
            throw new NotImplementedException();
        }

    }
}
