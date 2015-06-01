using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;
using DatosTotem.Modulo2;
using ExcepcionesTotem.Modulo2;

namespace LogicaNegociosTotem.Modulo2
{
   public class LogicaLugar
    {

       private BDLugar baseDeDatosLugar;
       private List<Lugar> lugares; 
       /// <summary>
       /// Constructor de la Clase LogicaCliente
       /// </summary>
       public LogicaLugar() 
       {
           baseDeDatosLugar = new BDLugar(); 
       }

       /// <summary>
       /// Método que llama a acceso a Datos de Lugar
       /// para llenar los países registrados
       /// </summary>
       /// <returns>Lista de Países Disponibles</returns>
       public List<Lugar> LlenarComboPaises() 
       {
           try
           {
               lugares = baseDeDatosLugar.LlenarCBPaisesBD();
               return lugares; 
           }
           catch (Exception e) 
           {
               throw new ClienteLogicaException("C_2_001","Error en acceso a datos",e); 
           }
       }

       /// <summary>
       /// Método que llama a acceso a Datos de Lugar
       /// para llenar los estados según el id de un país
       /// </summary>
       /// <param name="idPais">Id del país al que
       /// pertenecen</param>
       /// <returns>Retorna una Lista de Estados</returns>
       public List<Lugar> LlenarComboEstados(int idPais) 
       {
           try
           {
               lugares = baseDeDatosLugar.LlenarCBEstadosBD(idPais);
               return lugares; 
           }
           catch (Exception e) 
           {
               throw new ClienteLogicaException("C_2_001", "Error en acceso a datos", e);
           }
       }

       /// <summary>
       /// Método que llama a acceso a Datos de Lugar
       /// para llenar las ciudades según el id de un estado
       /// </summary>
       /// <param name="idPais">Id del país al que
       /// pertenecen</param>
       /// <returns>Retorna una Lista de Estados</returns>
       public List<Lugar> LlenarComboCiudades(int idEstado) 
       {
           try
           {
               lugares = baseDeDatosLugar.LlenarCBCiudadesBD(idEstado);
               return lugares;
           }
           catch (Exception e)
           {
               throw new ClienteLogicaException("C_2_001", "Error en acceso a datos", e);
           }
       }
       /// <summary>
       /// Método de la capa lógica que llama a base de datos
       /// para pedirle la lista de ids tanto los de pais, estado
       /// asociado a ese país, y las ciudades a ese estado y
       /// la dirección asociada a dicha ciudad.
       /// </summary>
       /// <param name="direccion">Id de la dirección</param>
       /// <returns>
       /// Id del país al que pertenece la dirección
       /// Id del Estado al que pertenece la dirección
       /// Id de la Ciudad a la que pertenece la dirección
       /// </returns>
       public List<int> ConsultarDireccionCompleta(int direccion) 
       {
           try
           {
               List<int> ids = baseDeDatosLugar.ConsultarDireccionCompletaBD(direccion);
               return baseDeDatosLugar.ConsultarDireccionCompletaBD(direccion);
           }
           catch (Exception e)
           {
               throw new ClienteLogicaException("C_2_001", "Error en acceso a datos", e);
           }
       }
       /// <summary>
       /// Método que obtiene de la lógica de negocios
       /// la dirección completa de una empresa o cliente 
       /// para ser cargada.
       /// </summary>
       /// <param name="direccion">id de la dirección</param>
       /// <returns>Dirección detallada</returns>
       public string ObtenerDireccionCompleta(int direccion) 
       {
           try
           {
               string laDireccion = string.Empty;
               laDireccion = baseDeDatosLugar.ObtenerDireccionConcatenadaBD(direccion);
               return laDireccion;
           }

           catch (Exception e)
           {
               throw new ClienteLogicaException("C_2_001", "Error al cargar direccion", e);
           }
       }

       /// <summary>
       /// Método que le pide a acceso a datos 
       /// el código postal de una ciudad pasándole 
       /// como parámetro el id de una ciudad
       /// </summary>
       /// <param name="ciudad">Nombre de la ciudad</param>
       /// <returns>El número de código postal</returns>
       public int ObtenerCodigoPostal(int ciudad) 
       {
           int laCiudad = 0;
           laCiudad = baseDeDatosLugar.CargarCodigoPostal(ciudad);
           return laCiudad; 
       }

    }
}
