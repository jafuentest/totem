using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo2;
using System.Data;
using System.Data.SqlClient;

namespace DatosTotem.Modulo2
{
   public class BDContacto
    {
        SqlConnection conexion;
        SqlCommand comando;

       public BDContacto()
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
       /// Método que accede a Base de Datos para 
       /// insertar información sobre el contacto de una empresa
       /// </summary>
       /// <param name="contacto">Información del Contacto</param>
       /// <returns>True si se realizó, false en caso contrario</returns>
       public bool AgregarContacto(Contacto contacto) 
       {
           throw new NotImplementedException(); 
       }

       /// <summary>
       /// Método que accede a Base de Datos 
       /// para obtener los contactos de una empresa dada
       /// </summary>
       /// <returns>Lista de Contactos de la empresa</returns>
       public List<Contacto> ConsultarDatosContactos(string rif)
       {
           List<Contacto> contactos = new List<Contacto>();
           Contacto contacto;
           try
           {
               this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureDatosContactos, this.conexion);
               this.comando.CommandType = CommandType.StoredProcedure;
               this.comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.ParametroRif,
                                         rif));

               SqlDataReader lectura;
               this.conexion.Open();
               lectura = this.comando.ExecuteReader();
               while (lectura.Read())
               {
                   contacto = ObtenerBDContacto(lectura);
                   contactos.Add(contacto);
               }
           }
           catch (SqlException ex)
           {
               throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                   RecursoGeneralBD.Codigo,
                   RecursoGeneralBD.Mensaje,
                   ex);
           }
           catch (NullReferenceException ex)
           {
               throw new ClienteInexistenteException(
                   RecursosBaseDeDatosModulo2.CodigoClienteInexistente,
                   RecursosBaseDeDatosModulo2.MensajeClienteInexistente,
                   ex);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               this.conexion.Close();
           }
           return contactos;
       }

       /// <summary>
       /// Método que trae de la Base de Datos
       /// los contactos que tiene una determinada empresa
       /// </summary>
       /// <param name="lector"></param>
       /// <returns></returns>
       public Contacto ObtenerBDContacto(SqlDataReader lector)
       {
           Contacto contacto = new Contacto();
           List<string> telefonos = new List<string>();
           string telefono = string.Empty;
           try
           {
               contacto.Con_Id = lector.GetInt32(0);
               contacto.Con_Nombre = lector.GetString(1);
               contacto.Con_Apellido = lector.GetString(2);
               contacto.ConCargo = lector.GetString(3);
               int codigo = lector.GetInt32(4);
               int numero = lector.GetInt32(5);
               telefono = codigo.ToString() + numero.ToString();
               telefonos.Add(telefono);
               contacto.Con_Telefonos = telefonos;

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

           return contacto;
       }

    }
}
