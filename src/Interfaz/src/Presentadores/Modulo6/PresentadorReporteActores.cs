using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo6;
using Dominio.Entidades.Modulo6;
using Dominio.Entidades.Modulo4;
using Dominio.Fabrica;
using Dominio;
using Comandos.Comandos;
using Comandos.Fabrica;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo6.ExcepcionesPresentador;
using ExcepcionesTotem.Modulo6.ExcepcionesComando;

namespace Presentadores.Modulo6
{
   public class PresentadorReporteActores
    {
       private IContratoReporteActores vista;


       public PresentadorReporteActores(IContratoReporteActores vista) 
       {
           this.vista = vista;        
       }


       /// <summary>
       /// Método que despliega en un ComboBox una lista de actores 
       /// a ser seleccionados para luego mostrarse en una tabla con 
       /// la información de los casos de uso en el que participa. 
       /// </summary>
       public void CargarActores() 
       {
       
       }


    }
}
