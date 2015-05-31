using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DominioTotem;

namespace DatosTotem.Modulo5
{
    public class BDRequerimiento
    {
	   #region Retornar id por código del proyecto
	   /// <summary>
	   /// Método que permite devolver el identificador único del
	   /// proyecto
	   /// </summary>
	   /// <param name="codigo">
	   /// Código del proyecto
	   /// <returns>
	   /// Devuelve como resultado el identificador único del proyecto
	   /// buscado mediante su código
	   /// </returns>
	   public static int RetornarIdPorCodigoProyecto(string codigo)
	   {
		  int id = -1;

		  List<Parametro> parametros = new List<Parametro>();

		  Parametro parametro = new Parametro(
			 RecursosBDModulo5.PARAMETRO_PRO_CODIGO,
			 SqlDbType.VarChar, codigo, false);
		  parametros.Add(parametro);

		  parametro = new Parametro(
			 RecursosBDModulo5.PARAMETRO_PRO_ID, SqlDbType.Int, true);
		  parametros.Add(parametro);

		  try
		  {
			 BDConexion conexion = new BDConexion();

			 List<Resultado> proyecto = conexion.
				EjecutarStoredProcedure(
				RecursosBDModulo5.
				PROCEDIMIENTO_RETORNAR_ID_POR_CODIGO_PROYECTO,
				parametros);

			 if (proyecto != null)
			 {
				foreach (Resultado atributo in proyecto)
				{
				    if ( atributo.etiqueta.Equals(
					   RecursosBDModulo5.PARAMETRO_PRO_ID) )
				    {
					   if ( atributo.valor.ToString() != "" )
						  id = Convert.ToInt32(atributo.valor);
				    }
				}
			 }
		  }
		  catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
		  {
			 throw new ExcepcionesTotem.ExceptionTotemConexionBD(
				ex.Codigo,
				ex.Mensaje, ex);
		  }

		  return id;
	   }
	   #endregion


	   #region Consultar requerimientos por proyecto
	   /// <summary>
	   /// Método que permite consultar los requerimientos de un proyecto
	   /// </summary>
	   /// <param name="id">
	   /// Identificador único del proyecto a ser consultado
	   /// <returns>
	   /// Devuelve como resultado una lista con todos los
	   /// requerimientos correspondientes al proyecto seleccionado
	   /// </returns>
	   public static List<Requerimiento>
		ConsultarRequerimientosPorProyecto(int id)
	   {

		  if ( id == -1 )
		  {
			 throw new ExcepcionesTotem.Modulo5.
				ProyectoNoEncontradoException(
				RecursosBDModulo5.EXCEPCION_PRO_NO_ENC_CODIGO,
				RecursosBDModulo5.EXCEPCION_PRO_NO_ENC_MENSAJE,
				new Exception()
				);
		  }

		  List<Parametro> parametros = new List<Parametro>();

		  List<Requerimiento> listaRequerimientos =
			 new List<Requerimiento>();

		  Parametro parametro = new Parametro(
			 RecursosBDModulo5.PARAMETRO_PRO_ID,
			 SqlDbType.Int, id.ToString(), false);
		  parametros.Add(parametro);

		  try
		  {
			 BDConexion conexion = new BDConexion();

			 DataTable dataTableRequerimientos =
				conexion.EjecutarStoredProcedureTuplas(
				RecursosBDModulo5.
				PROCEDIMIENTO_CONSULTAR_REQUERIMIENTOS_POR_PROYECTO, 
				parametros);

			 foreach (DataRow fila in dataTableRequerimientos.Rows)
			 {
				listaRequerimientos.Add(
				    new DominioTotem.Requerimiento(
					   Convert.ToInt32(fila[RecursosBDModulo5.ATRIBUTO_REQ_ID]),
					   fila[RecursosBDModulo5.ATRIBUTO_REQ_CODIGO].ToString(),
					   fila[RecursosBDModulo5.ATRIBUTO_REQ_DESCRIPCION].ToString(),
					   fila[RecursosBDModulo5.ATRIBUTO_REQ_TIPO].ToString(),
					   fila[RecursosBDModulo5.ATRIBUTO_REQ_PRIORIDAD].ToString(),
					   fila[RecursosBDModulo5.ATRIBUTO_REQ_ESTATUS].ToString()
				    )
				);
			 }
		  }
		  catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
		  {
			 throw new ExcepcionesTotem.ExceptionTotemConexionBD(
				ex.Codigo,
				ex.Mensaje, ex);
		  }

		  return listaRequerimientos;
	   } 
	   #endregion
    }

}
