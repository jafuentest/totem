using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;
using ExcepcionesTotem.Modulo2;
using System.Data;
using System.Data.SqlClient;






namespace DatosTotem.Modulo2
{

    /// <summary>
    /// Clase encargada de acceder a la base de Datos relacionadas con la información sobre la gestión
    /// de Clientes y Empresas.
    /// </summary>
    public class BDCliente
    {

        private BDConexion _operacionBD;
        private ClienteNatural Clientenatural = new ClienteNatural();
        private SqlConnection conexion;
        private SqlCommand comando; 

        /// <summary>
        /// Constructor de la Clase BDCliente
        /// </summary>
        public BDCliente() 
        {
           // this.conexion = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\totem\totem\src\DatosTotem\BaseDeDatos\BaseDeDatosTotem.mdf;Integrated Security=True"); 
           // this.conexion = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\BaseDeDatos\BaseDeDatosTotem.mdf;Integrated Security=True");
            this.conexion = new SqlConnection(@RecursoGeneralBD.StringDeConexion);
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Agregar un Cliente Jurídico
        /// </summary>
        /// <param name="clienteJuridico">Información del Cliente Jurídico</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
        public bool AgregarClienteJuridico(ClienteJuridico clienteJuridico, int fkLugar) 
        {
            bool respuesta = false;

            try
            {
                int nroDeFilasAfectadas = 0;

                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureAgregarClienteJuridico, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroRif, clienteJuridico.Jur_Id);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroNombre, clienteJuridico.Jur_Nombre);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroLogo, string.Empty);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroLugar, fkLugar);

                this.conexion.Open();

                nroDeFilasAfectadas = this.comando.ExecuteNonQuery();

                if (nroDeFilasAfectadas > 0)
                    respuesta = true; 

            }

            catch (SqlException e)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje,e); 
            }
            catch (NullReferenceException e)
            {
                throw e; 
            }
            catch (Exception e)
            {
                throw e;  
            }
            finally 
            {
                this.conexion.Close(); 
            }

            return respuesta;  
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Agregar un Cliente Natural
        /// </summary>
        /// <param name="clienteNatural">Información del Cliente Natural</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
        public bool AgregarClienteNatural(ClienteNatural clienteNatural , int fkLugar) 
        {

             bool respuesta = false;

            try
            {
                int nroDeFilasAfectadas = 0;

                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureAgregarClienteNatural, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.Parametroidentificador, Clientenatural.Nat_Id);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroNombren, Clientenatural.Nat_Nombre);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroApellidon, Clientenatural.Nat_Apellido);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroCorreon, Clientenatural.Nat_Correo);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroLugarn, fkLugar);
                this.conexion.Open();

                nroDeFilasAfectadas = this.comando.ExecuteNonQuery();

                if (nroDeFilasAfectadas > 0)
                    respuesta = true;


            }

            catch (SqlException e)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, e);
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.conexion.Close();
            }

            return respuesta;       
           
        
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Eliminar un Cliente Natural
        /// </summary>
        /// <param name="clienteNatural">Información del Cliente Natural</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
        public bool EliminarClienteNatural(string cedula)
        {
            bool respuesta = false;

            try
            {
                int nroDeFilasAfectadas = 0;

                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureEliminarClienteNatural, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroCedula, cedula);
               
                this.conexion.Open();

                nroDeFilasAfectadas = this.comando.ExecuteNonQuery();

                if (nroDeFilasAfectadas > 0)
                    respuesta = true;
                
            }

            catch (SqlException e)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, e);
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.conexion.Close();
            }

            return respuesta;  

           
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Modificar un Cliente Natural
        /// </summary>
        /// <param name="clienteNatural">Información del Cliente Natural</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
        public bool ModificarClienteNatural(ClienteNatural clienteNatural)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Modificar un Cliente Jurídico
        /// </summary>
        /// <param name="clienteNatural">Información del Cliente Natural</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
        public bool ModificarClienteJuridico(ClienteJuridico clienteNatural)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Consultar un Cliente Jurídico en específico
        /// </summary>
        /// <returns>Retorna el objeto de tipo Cliente Juridico, null si el objeto no existe</returns>
        public ClienteJuridico ConsultarClienteJuridico(int idCliente) 
        {
            ClienteJuridico clienteJuridico = new ClienteJuridico();
            try
            {

                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureConsultarDatosClienteJuridico, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.ParametroIdClienteJuridico,
                                            idCliente));

                SqlDataReader lectura;
                this.conexion.Open();
                lectura = this.comando.ExecuteReader();

                while (lectura.Read())
                {
                    clienteJuridico = ObtenerClienteJuridicoBD(lectura);
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


            return clienteJuridico;            
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Consultar un Cliente Natural en específico
        /// </summary>
        /// <returns>Retorna el objeto de tipo Cliente Juridico, null si el objeto no existe</returns>
        public ClienteNatural ConsultarClienteNatural(int idCliente)
        {
            ClienteNatural clienteNatural = new ClienteNatural();
            try
            {

                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureDetallarCliente, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.ParametroIdClienteNatural,
                                            idCliente));

                SqlDataReader lectura;
                this.conexion.Open();
                lectura = this.comando.ExecuteReader();

                while (lectura.Read())
                {
                    clienteNatural = ObtenerClienteNaturalBD(lectura);
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


            return clienteNatural;
        }

        /// <summary>
        /// Método que accede a la Base de Datos para consultar una lista de Clientes Jurídicos
        /// </summary>
        /// <returns>Retorna una lista de Clientes Juridicos, null si el objeto no existe</returns>
        public List<ClienteJuridico> ConsultarClientesJuridicos()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Método que accede a la Base de Datos para consultar una lista de Clientes Naturales
        /// </summary>
        /// <returns>Retorna una lista de Clientes Naturales, null si el objeto no existe</returns>
        public List<ClienteNatural> ConsultarClientesNaturales()
        {
            throw new NotImplementedException();
        }


       /// <summary>
       /// Método que retorna una lista de Clientes Jurídicos dado un parámetro de búsqueda
       /// </summary>
       /// <param name="parametroBusqueda">Parámetro de Búsqueda</param>
       /// <returns>Retorna una lista de clientes jurídicos que cumplan con el 
       /// parámetro de búsqueda, null si ninguno cumple con el parámetro</returns>
        public List<ClienteJuridico> ConsultarClientesJuridicosParametrizados(string parametroBusqueda)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que retorna una lista de Clientes Naturales dado un parámetro de búsqueda
        /// </summary>
        /// <param name="parametroBusqueda">Parámetro de Búsqueda</param>
        /// <returns>Retorna una lista de clientes naturales que cumplan con el 
        /// parámetro de búsqueda, null si ninguno cumple con el parámetro</returns>
        public List<ClienteNatural> ConsultarClientesNaturalesParametrizados(string parametroBusqueda)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que obtiene directamente de la Base de Datos
        /// un registro de tipo Cliente Natural
        /// </summary>
        /// <param name="lector">Cliente Natural seleccionado</param>
        public ClienteNatural ObtenerClienteNaturalBD(SqlDataReader lector) 
        {
            ClienteNatural clienteNatural = new ClienteNatural();
            Lugar lugar = new Lugar();
            List<string> telefonos = new List<string>(); 
           try
           {
               clienteNatural.Nat_Id = lector.GetString(0);
               clienteNatural.Nat_Nombre = lector.GetString(1);
               clienteNatural.Nat_Apellido = lector.GetString(2);
               clienteNatural.Nat_Correo = lector.GetString(4);
               int codigo = lector.GetInt32(5);
               int numero = lector.GetInt32(6);
               string numeroCompleto = codigo.ToString() + numero.ToString();
               telefonos.Add(numeroCompleto); 
               clienteNatural.Nat_Telefonos=telefonos;
               clienteNatural.Nat_Pais = lector.GetString(7);
               clienteNatural.Nat_Estado = lector.GetString(8);
               lugar.NombreLugar = lector.GetString(9);
               clienteNatural.Nat_Direccion = lector.GetString(10);

               lugar.CodigoPostal = lector.GetInt32(11).ToString();
               clienteNatural.Nat_Ciudad = lugar; 
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

           return clienteNatural; 
         }


        /// <summary>
        /// Método que obtiene directamente de Base de Datos
        /// la información relacionada a un cliente Jurídico
        /// </summary>
        /// <param name="lector">Cliente Jurídico Seleccionado</param>
        /// <returns></returns>
        public ClienteJuridico ObtenerClienteJuridicoBD(SqlDataReader lector) 
        {
            ClienteJuridico clienteJuridico = new ClienteJuridico();
            Lugar lugar = new Lugar();
            List<string> telefonos = new List<string>();
            List<Contacto> contactos = new List<Contacto>(); 
           try
           {
               clienteJuridico.Jur_Id = lector.GetString(1);
               clienteJuridico.Jur_Nombre = lector.GetString(2);
               clienteJuridico.Jur_Pais = lector.GetString(3);
               clienteJuridico.Jur_Estado = lector.GetString(4);
               lugar.NombreLugar = lector.GetString(5);
               lugar.CodigoPostal = lector.GetInt32(6).ToString();
               clienteJuridico.Jur_Ciudad = lugar; 
               clienteJuridico.Jur_Direccion = lector.GetString(7);
               int codigo = lector.GetInt32(8);
               int numero = lector.GetInt32(9);
               string numeroCompleto = codigo.ToString() + numero.ToString();
               telefonos.Add(numeroCompleto); 
               clienteJuridico.Jur_Telefonos = telefonos;
               string nombreContacto = lector.GetString(10); 
               string apellidoContacto = lector.GetString(11); 
               contactos.Add(new Contacto(nombreContacto,apellidoContacto));
               clienteJuridico.Jur_Contactos = contactos;      

              
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

           return clienteJuridico; 
         }
 }

    

    
}
