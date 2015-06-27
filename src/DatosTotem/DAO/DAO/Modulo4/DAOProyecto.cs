using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades.Modulo4;

namespace DAO.DAO.Modulo4
{
    public class DAOProyecto : DAO, IntefazDAO.Modulo4.IDaoProyecto
    {

        #region Metodos IDao

        public Boolean Agregar(Dominio.Entidad parametro)
        {
            if ( !existeProyecto((parametro as Proyecto).Codigo) )
            {
                try
                {
                    List<Parametro> parametros = new List<Parametro>();

                    Parametro parametroLista = new Parametro(RecursosDAOModulo4.
				    ParametroCodigoProyecto, SqlDbType.VarChar,
				    (parametro as Proyecto).Codigo, false);
                    parametros.Add(parametroLista);

                    parametroLista = new Parametro(RecursosDAOModulo4.
				    ParametroNombreProyecto, SqlDbType.VarChar,
				    (parametro as Proyecto).Nombre, false);
                    parametros.Add(parametroLista);

                    parametroLista = new Parametro(RecursosDAOModulo4.
				    ParametroEstadoProyecto, SqlDbType.Bit,
				    (parametro as Proyecto).Estado.ToString(), false);
                    parametros.Add(parametroLista);

                    parametroLista = new Parametro(RecursosDAOModulo4.
				    ParametroDescripcionProyecto, SqlDbType.VarChar,
				    (parametro as Proyecto).Descripcion, false);
                    parametros.Add(parametroLista);

                    parametroLista = new Parametro(RecursosDAOModulo4.
				    ParametroCostoProyecto, SqlDbType.Int,
				    (parametro as Proyecto).Costo.ToString(), false);
                    parametros.Add(parametroLista);

                    parametroLista = new Parametro(RecursosDAOModulo4.
				    ParametroMonedaProyecto, SqlDbType.VarChar,
				    (parametro as Proyecto).Moneda, false);
                    parametros.Add(parametroLista);

                    List<Resultado> resultados = EjecutarStoredProcedure(RecursosDAOModulo4.
				    ProcedimientoAgregarProyecto, parametros);

				if (resultados != null)
				    return true;
				else
				    throw new ExcepcionesTotem.Modulo4.ProyectoNoAgregadoException(
					   RecursosDAOModulo4.CodigoProyectoNoAgregado,
					   RecursosDAOModulo4.MensajeProyectoNoAgregado, new Exception());
                }
                catch (ExcepcionesTotem.ExceptionTotem ex)
                {
                    throw ex;
                }
            }
            else
		  {
			 throw new ExcepcionesTotem.Modulo4.CodigoRepetidoException(
				RecursosDAOModulo4.CodigoProyectoExiste,
				RecursosDAOModulo4.MensajeCodigoProyectoExiste, new Exception());
		  }
        }
        public bool Modificar(Dominio.Entidad parametro)
        {
            try
            {
                Dominio.Entidades.Modulo4.Proyecto proyecto = (Dominio.Entidades.Modulo4.Proyecto)parametro;
                bool proyectoModificado = false;

                if (proyecto != null || proyecto.Id != null || proyecto.Codigo != ""
                         || proyecto.Nombre != "" || proyecto.Estado != null ||
                         proyecto.Descripcion != "" || proyecto.Costo != null || proyecto.Moneda != ""
                         )
                {
                    #region Asignacion de Parametros bd
                    List<Parametro> parametros = new List<Parametro>();

                    Parametro parametroBD = new Parametro(RecursosDAOModulo4.ParametroCodigoProyecto, SqlDbType.VarChar,
                       proyecto.Codigo, false);
                    parametros.Add(parametroBD);

                    parametroBD = new Parametro(RecursosDAOModulo4.ParametroNombreProyecto
                       , SqlDbType.VarChar,
                       proyecto.Nombre, false);
                    parametros.Add(parametroBD);

                    parametroBD = new Parametro(RecursosDAOModulo4.ParametroEstadoProyecto
                       , SqlDbType.Bit,
                       proyecto.Estado.ToString(), false);
                    parametros.Add(parametroBD);

                    parametroBD = new Parametro(RecursosDAOModulo4.ParametroDescripcionProyecto
                       , SqlDbType.VarChar,
                       proyecto.Descripcion, false);
                    parametros.Add(parametroBD);

                    parametroBD = new Parametro(RecursosDAOModulo4.ParametroCostoProyecto
                       , SqlDbType.Int,
                       proyecto.Costo.ToString(), false);
                    parametros.Add(parametroBD);

                    parametroBD = new Parametro(RecursosDAOModulo4.ParametroMonedaProyecto
                       , SqlDbType.VarChar,
                       proyecto.Moneda, false);
                    parametros.Add(parametroBD);
                    #endregion

                    List<Resultado> resultados = base.EjecutarStoredProcedure(RecursosDAOModulo4.ProcedimientoModificarProyecto
                             , parametros);

                    if (resultados != null)
                    {
                        proyectoModificado = true;
                    }
                    else
                    {
                        proyectoModificado = false;
                        //agregar las excepciones
                        throw new ExcepcionesTotem.Modulo4.ProyectoNoModificadoException(
                       RecursosDAOModulo4.CodigoProyectoNoModificado,
                       RecursosDAOModulo4.MensajeProyectoNoModificado, new Exception());
                    }


                }




                return proyectoModificado;

            }
            //falta otro catch para capturar+execpeciones
            catch (ExcepcionesTotem.ExceptionTotem e)
            {

                throw e;
            }
        }
        public Dominio.Entidad ConsultarXId(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }
        public List<Dominio.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        } 

        #endregion

        #region Metodos IDaoProyecto

	   #region consultarProyectosPorUsuario
	   /// <summary>
	   /// Firma del método que permite consultar todos los proyectos asociados a un
	   /// usuario particular
	   /// </summary>
	   /// <param name="nombreUsuario">Nombre del usuario a consultar</param>
	   /// <returns>Lista con los proyectos asociados a un usuario</returns>
	   public List<Dominio.Entidad> consultarProyectosPorUsuario(String nombreUsuario)
	   {

		  List<Dominio.Entidad> listaProyectos = null;

		  try
		  {
			 List<Parametro> parametros = new List<Parametro>();

			 Parametro parametroLista = new Parametro(RecursosDAOModulo4.ParametroUsuario,
				SqlDbType.VarChar, nombreUsuario, false);
			 parametros.Add(parametroLista);

			 DataTable listaDTProyectos = EjecutarStoredProcedureTuplas(
				RecursosDAOModulo4.ProcedimientoProyectosDeUsuario, parametros);

			 if (listaDTProyectos != null)
			 {
				listaProyectos = new List<Dominio.Entidad>();

				foreach (DataRow fila in listaDTProyectos.Rows)
				{
				    listaProyectos.Add(new Dominio.Entidades.Modulo4.Proyecto(
					   fila[RecursosDAOModulo4.AtributoCodigoProyecto].ToString(),
					   fila[RecursosDAOModulo4.AtributoNombreProyecto].ToString(),
					   Boolean.Parse(fila[RecursosDAOModulo4.AtributoEstadoProyecto].ToString()),
					   fila[RecursosDAOModulo4.AtributoDescripcionProyecto].ToString(),
					   fila[RecursosDAOModulo4.AtributoMonedaProyecto].ToString(),
					   Convert.ToInt32(fila[RecursosDAOModulo4.AtributoCostoProyecto].ToString())
					   )
				    );
				}
			 }
		  }
		  catch (ExcepcionesTotem.ExceptionTotem ex)
		  {			 
			 throw ex;
		  }

		  if( listaProyectos.Count == 0 )
			 throw new ExcepcionesTotem.Modulo4.UsuarioSinProyectosException(
				RecursosDAOModulo4.CodigoUsuarioSinProyectos,
				RecursosDAOModulo4.MensajeUsuarioSinProyectos, new Exception());

		  return listaProyectos;
	   }
	   #endregion

        # region consultarProyecto
        /// <summary>
        /// Metodo que
        /// consulta un proyecto a la base de datos
        /// </summary>
        /// <param name="codigo"> codigo del proyecto a consultar</param>
        /// <returns>Entidad con la informacion del proyecto consultado</returns>

        public Dominio.Entidad consultarProyecto(String codigo)
        {
            throw new NotImplementedException();
        }
        # endregion

        # region eliminarProyecto
        /// <summary>
        /// Metodo que
        /// elimina un proyecto de la base de datos
        /// </summary>
        /// <param name="codigo"> codigo del proyecto a eliminar</param>
        /// <returns>True si el proyecto fue eliminado excitosamente</returns>

        public bool eliminarProyecto(String codigo)
        {
            throw new NotImplementedException();
        }
        # endregion

        # region existeProyecto
        /// <summary>
        /// Método para verificar si existe un proyecto en la bd
        /// </summary>
        /// <param name="codigo">Codigo del proyecto a verificar</param>
        /// <returns>Retrorna true si existe o false si no existe</returns>

        public bool existeProyecto(String codigo)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosDAOModulo4.ParametroCodigoProyecto, SqlDbType.VarChar, codigo, false);
            parametros.Add(parametro);

            parametro = new Parametro(RecursosDAOModulo4.ParametroResultado, SqlDbType.Int, true);
            parametros.Add(parametro);


            List<Resultado> resultados = EjecutarStoredProcedure(RecursosDAOModulo4.ProcedimientoExisteProyecto, parametros);


            //if (int.Parse(resultados[0].valor) == 1)
            if (resultados != null)
            {
                return true;
            }
            else
                return false;
        }

        # region contarRequerimientos
        /// <summary>
        /// Método para contar los requerimientos de un proyecto
        /// </summary>
        /// <param name="codigo">Codigo del proyecto a consultar </param>
        /// <returns>Retorna el numero de requerimientos </returns>

        public int contarRequerimientosProyecto(String codigo)
        {
            throw new NotImplementedException();
        }
        # endregion

        # region consultarRequerimientosFinalizadosPorProyecto
        /// <summary>
        /// Método para consultar los requerimientos finalizados de un proyecto en la bd
        /// </summary>
        /// <param name="codigo">codigo del proyecto para buscar sus requerimientos </param>
        /// <returns>Retrorna los requerimientos finalizados</returns>
        public List<Dominio.Entidad> consultarRequerimientosFinalizadosPorProyecto(String codigo)
        {
            throw new NotImplementedException();
        }
        # endregion

        # region consultarTodoslosClienteNaturales
        /// <summary>
        /// Método para consultar todos los clientes naturales
        /// </summary>
        /// <returns>Retorna todos los clientes naturales</returns>
        public System.Data.DataTable consultarTodoslosClienteNaturales()
        {
            throw new NotImplementedException();
        }
        # endregion

        # region obtenerIdClienteNatural
        /// <summary>
        /// Método para consultar el id de un cliente naturale
        /// </summary>
        /// <returns>Retorna todos los clientes naturales</returns>
        public int obtenerIdClienteNatural(String cedula)
        {
            throw new NotImplementedException();
        }
        # endregion

        # region buscarProyectos
        /// <summary>
        /// Método para buscar proyectos en la bd
        /// </summary>
        /// <param name="busqueda">Cadena para la busqueda</param>
        /// <returns>Retrorna los proyectos de relacionado con el parametro</returns>
        public System.Data.DataTable buscarProyectos(String busqueda, String username)
        {
            throw new NotImplementedException();
        }
        # endregion

        # endregion

    }
}
