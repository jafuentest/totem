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
    }
}
