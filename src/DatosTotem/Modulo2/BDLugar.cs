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
           try
           {
               //Obtenemos la ruta de la Base de Datos
               String[] aux = AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { "src" }, StringSplitOptions.None);
               String configuracion = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + aux[0] + @"src\DatosTotem\BaseDeDatos\BaseDeDatosTotem.mdf;Integrated Security=True";

               //La colocamos en la configuracion
               this.conexion = new SqlConnection(configuracion);
           }
           catch (Exception e)
           {
               throw new Exception("Error en la Configuracion de la BD", e);
           }
       
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
       /// Consulta la direccion con pais estado ciudad y direccion
       /// </summary>
       /// <param name="direccion">id la direccion para buscar a donde pertenece</param>
       /// <returns>lista deid correspondiente al pais, estado, ciudad y direccion</returns>
       public List<int> ConsultarDireccionCompletaBD(int direccion)
       {
           List<int> direccionCompleta = new List<int>();
           
           this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureConsultarDireccionCompleta,
                                this.conexion);
           comando.CommandType = CommandType.StoredProcedure;
           comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.ParametroIdDireccion, direccion));

           SqlDataReader _lectura;
           int idDireccion = 0;
           try
           {
               this.conexion.Open();
               _lectura = comando.ExecuteReader();
               while (_lectura.Read())
               {
                   idDireccion = _lectura.GetInt32(0);
                   direccionCompleta.Add(idDireccion);
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

           return direccionCompleta;
       }

       /// <summary>
       /// Método que accede a Base de Datos 
       /// para obtener el código postal dado el 
       /// identificador de una ciudad
       /// </summary>
       /// <param name="idCiudad">Nombre de la ciudad</param>
       /// <returns>El número de código postal</returns>
       public int CargarCodigoPostal(int idCiudad) 
       {

           int numero = 0; 
           this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureCargarCodigoPostal,
                                this.conexion);
           comando.CommandType = CommandType.StoredProcedure;
           comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.ParametroIdCiudad, idCiudad));

           SqlDataReader _lectura;
          
           try
           {
               this.conexion.Open();
               _lectura = comando.ExecuteReader();
               while (_lectura.Read())
               {
                   numero = _lectura.GetInt32(0);
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

           return numero;
       }

       /// <summary>
       /// Método que accede directamente a Base de Datos
       /// para la recuperación de un registro de lugar
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


       /// <summary>
       /// Consulta la direccion completa de un empleado en particular
       /// </summary>
       /// <param name="direccion">id de la direccion donde reside el empleado</param>
       /// <returns>un stringcon la informacion del pais, estado, ciudad y direccio de un empleado</returns>
       public string ObtenerDireccionConcatenadaBD(int direccion)
       {
           string _direccion = string.Empty;
           
           SqlCommand comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureObtenerDireccion, this.conexion);
           comando.CommandType = CommandType.StoredProcedure;
           comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.ParametroIdDireccion, direccion));
           SqlDataReader _lectura;

           try
           {
               this.conexion.Open();
               _lectura = comando.ExecuteReader();
               while (_lectura.Read())
               {
                   _direccion = _lectura.GetString(0);
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
           return _direccion;
       }

    }
}
