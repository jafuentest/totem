using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;
using System.Data.SqlClient;
using ExcepcionesTotem;
using System.Data;

namespace DatosTotem.Modulo2
{

    /// <summary>
    /// Clase para acceso a datos referente a las direcciones de un 
    /// Cliente en Base de Datos
    /// </summary>
   public class BDLugar
    {

       private List<Lugar> _listaLugar;
       private SqlConnection conexion;
       private SqlCommand comando;
       private Lugar _lugar; 
       /// <summary>
       /// Constructor de la Clase BDLugar
       /// </summary>
       public BDLugar() 
       {
           this.conexion = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\totem\totem\src\DatosTotem\BaseDeDatos\BaseDeDatosTotem.mdf;Integrated Security=True");    
       
       }

       /// <summary>
       /// Método que accede a la Base de Datos 
       /// para llenar una lista de países en el Combo Box de Países
       /// </summary>
       /// <returns>Lista de Tipo Lugar (Países)</returns>
       public List<Lugar> LlenarCBPaisesBD()
       {
           _listaLugar = new List<Lugar>();

           this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureLlenarComboPais, conexion);
           this.comando.CommandType = CommandType.StoredProcedure;
           SqlDataReader _lectura;

           try
           {
               this.conexion.Open();
               _lectura = comando.ExecuteReader();
               while (_lectura.Read())
               {
                   _lugar = ConsultarLugarBD(_lectura);
                   if (_lugar != null)
                   {
                       _listaLugar.Add(_lugar);
                   }
               }
           }

           catch (SqlException ex) 
           {
               throw ex; 
           }
           catch(NullReferenceException ex)
           {
               throw ex; 
           }
           catch (Exception ex)
           {
               throw ex;

           }
           finally
           {
               this.conexion.Close(); 
           }

           return _listaLugar;
           
       }


       /// <summary>
       /// ¨Método que accede a la Base de Datos para llenar una lista
       /// de estados asociados a un país según su id
       /// </summary>
       /// <param name="idPais">Id del País al que pertenecen los estados</param>
       /// <returns>Lista de Estados</returns>
       public List<Lugar> LlenarCBEstadosBD(int idPais) 
       {
           _listaLugar = new List<Lugar>();

           this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureLlenarComboEstado, conexion);
           this.comando.CommandType = CommandType.StoredProcedure;
           this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroIdPais, idPais);
           SqlDataReader _lectura;

           try
           {
               this.conexion.Open();
               _lectura = comando.ExecuteReader();
               while (_lectura.Read())
               {
                   _lugar = ConsultarLugarBD(_lectura);
                   if (_lugar != null)
                   {
                       _listaLugar.Add(_lugar);
                   }
               }
           }

           catch (SqlException ex)
           {
               throw ex;
           }
           catch (NullReferenceException ex)
           {
               throw ex;
           }
           catch (Exception ex)
           {
               throw ex;

           }
           finally
           {
               this.conexion.Close();
           }

           return _listaLugar;
       }

       /// <summary>
       /// Método que retorna un listado de ciudades accediendo a la Base de Datos 
       /// según el id del estado al que pertenecen
       /// </summary>
       /// <param name="idEstado">Id del estado al que pertenece la ciudad</param>
       /// <returns>Listado de Ciudades</returns>
       public List<Lugar> LlenarCBCiudadesBD(int idEstado)
       {
           _listaLugar = new List<Lugar>();

           this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureLlenarComboCiudad, conexion);
           this.comando.CommandType = CommandType.StoredProcedure;
           this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroIdEstado, idEstado);
           SqlDataReader _lectura;

           try
           {
               this.conexion.Open();
               _lectura = comando.ExecuteReader();
               while (_lectura.Read())
               {
                   _lugar = ConsultarLugarBD(_lectura);
                   if (_lugar != null)
                   {
                       _listaLugar.Add(_lugar);
                   }
               }
           }

           catch (SqlException ex)
           {
               throw ex;
           }
           catch (NullReferenceException ex)
           {
               throw ex;
           }
           catch (Exception ex)
           {
               throw ex;

           }
           finally
           {
               this.conexion.Close();
           }

           return _listaLugar;
       }


       /// <summary>
       /// Método que accede directamente a Base de Datos
       /// para la recuperación de una lista de lugares
       /// </summary>
       /// <param name="lector">lector de Base de Datos</param>
       /// <returns>Lugar a buscar</returns>
       public Lugar ConsultarLugarBD(SqlDataReader lector) 
       {
           Lugar lugar = new Lugar();

           try
           {
               lugar.IdLugar = lector.GetInt32(0);
               lugar.NombreLugar = lector.GetString(1); 

           }
           catch (SqlException ex)
           {
               throw ex; 
           }
           catch (NullReferenceException ex)
           {
               throw  ex;
           }
           catch (Exception ex) 
           {
               throw ex; 
           }

           return lugar; 
       }


    }
}
