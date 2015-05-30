﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DatosTotem.Modulo5
{
    public class BDRequerimiento
    {
	   public static string ListarRequerimientosPorProyecto(int codigo)
	   {
		  string query = "***";

		  List<Parametro> parametros = new List<Parametro>();

		  Parametro parametro = new Parametro("@pro_codigo",
			 SqlDbType.Int, Convert.ToString(codigo), false);
		  parametros.Add(parametro);

		  try
		  {
			 BDConexion con = new BDConexion();
			 List<Resultado> resultados = con.EjecutarStoredProcedure(
				"Procedure_ConsultarTodosRequerimiento", parametros);

			 if (resultados != null)
			 {

				query = resultados.ToString();

				foreach (Resultado resultado in resultados)
				{
				    if( resultado.etiqueta.Equals("req_codigo") )
					   query = (string) resultado.valor;
				}
			 }
		  }
		  catch (SqlException ex)
		  {
			 throw new ExcepcionesTotem.ExceptionTotemConexionBD(
				RecursoGeneralBD.Codigo,
				RecursoGeneralBD.Mensaje, ex);
		  }

		  return query;
	   }

    }
}
