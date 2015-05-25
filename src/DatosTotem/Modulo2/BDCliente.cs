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
            this.conexion = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\totem\totem\src\DatosTotem\BaseDeDatos\BaseDeDatosTotem.mdf;Integrated Security=True"); 
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
        public bool AgregarClienteNatural(ClienteNatural clienteNatural) 
        {

            bool respuesta;
            _operacionBD = new BDConexion();
            SqlCommand comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureAgregarClienteNatural, _operacionBD.Conectar());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.ParametroBusqueda, Clientenatural.Nat_Id));
            comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.ParametroNombre, Clientenatural.Nat_Nombre));
            comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.ParametroApellido, Clientenatural.Nat_Apellido));
            comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.ParametroCorreo, Clientenatural.Nat_Correo));
            comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.ParametroLugar, Clientenatural.Nat_Direccion));

           
            try
            {
                _operacionBD.Conectar();
                comando.ExecuteNonQuery();
                respuesta = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
              //  throw new ExcepcionClientesDatos(ex.Message);
            }
            catch (Exception ex)
            {
                respuesta = false;
                Console.WriteLine(ex.Message);
               // throw new ExcepcionClientesDatos(ex.Message);

            }
            finally
            {
                _operacionBD.Desconectar();
            }
           // return respuesta;


           throw new NotImplementedException();
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Eliminar un Cliente Natural
        /// </summary>
        /// <param name="clienteNatural">Información del Cliente Natural</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
        public bool EliminarClienteNatural(ClienteNatural clienteNatural)
        {
            throw new NotImplementedException();
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
        public ClienteJuridico ConsultarClienteJuridico() 
        {
            throw new NotImplementedException();            
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Consultar un Cliente Natural en específico
        /// </summary>
        /// <returns>Retorna el objeto de tipo Cliente Juridico, null si el objeto no existe</returns>
        public ClienteJuridico ConsultarClienteNatural()
        {
            throw new NotImplementedException();
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


    }
}
