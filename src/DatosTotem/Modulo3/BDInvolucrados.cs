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
        public static bool agregarUsuariosInvolucrados(ListaInvolucradoUsuario lista)
        {
            throw new NotImplementedException();
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

            string query = RecursosBDModulo3.StoredInsertarCliente;
            BDConexion laConexion;

            foreach (Contacto elContacto in listaContactos.Lista)
            {
                try
                {
                    laConexion = new BDConexion();
                    parametros = new List<Parametro>();

                    paramProyectoCod = new Parametro("@proyecto_codigo", SqlDbType.VarChar, elProyecto.Codigo, false);
                    paramContactoID = new Parametro("@contacto_id", SqlDbType.Int, elContacto.Con_Id.ToString(), false);

                    parametros.Add(paramContactoID);
                    parametros.Add(paramProyectoCod);

                    laConexion.EjecutarStoredProcedure(query, parametros);
                }
                catch (SqlException ex)
                {

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
