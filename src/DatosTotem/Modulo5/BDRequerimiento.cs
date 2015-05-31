using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DominioTotem;

namespace DatosTotem.Modulo5
{
    public class BDRequerimiento
    {
	   #region Consultar requerimientos por proyecto
	   /// <summary>
	   /// Método que permite consultar los requerimientos de un proyecto
	   /// </summary>
	   /// <param name="codigo">
	   /// Código del proyecto a ser consultado
	   /// <returns>
	   /// Devuelve como resultado una lista con todos los
	   /// requerimientos correspondientes al proyecto seleccionado
	   /// </returns>
	   public static List<Requerimiento>
		ConsultarRequerimientosPorProyecto(int codigo)
	   {

		  List<Parametro> parametros = new List<Parametro>();

		  List<Requerimiento> listaRequerimientos =
			 new List<Requerimiento>();

		  Parametro parametro = new Parametro(
			 RecursosBDModulo5.PARAMETRO_CODIGO_PROYECTO,
			 SqlDbType.Int, codigo.ToString(), false);
		  parametros.Add(parametro);

		  try
		  {
			 BDConexion conexion = new BDConexion();

			 DataTable dataTableRequerimientos =
				conexion.EjecutarStoredProcedureTuplas(
				"M5_ConsultarRequerimientosPorProyecto", parametros);

			 foreach (DataRow fila in dataTableRequerimientos.Rows)
			 {
				listaRequerimientos.Add(
				    new DominioTotem.Requerimiento(
					   fila[RecursosBDModulo5.ATRIBUTO_REQ_CODIGO].ToString(),
					   fila[RecursosBDModulo5.ATRIBUTO_REQ_DESCRIPCION].ToString(),
					   fila[RecursosBDModulo5.ATRIBUTO_REQ_TIPO].ToString(),
					   fila[RecursosBDModulo5.ATRIBUTO_REQ_PRIORIDAD].ToString(),
					   fila[RecursosBDModulo5.ATRIBUTO_REQ_ESTATUS].ToString()
				    )
				);
			 }
		  }
		  catch (SqlException ex)
		  {
			 throw new ExcepcionesTotem.ExceptionTotemConexionBD(
				RecursoGeneralBD.Codigo,
				RecursoGeneralBD.Mensaje, ex);
		  }

		  return listaRequerimientos;
	   } 
	   #endregion
    }

}
