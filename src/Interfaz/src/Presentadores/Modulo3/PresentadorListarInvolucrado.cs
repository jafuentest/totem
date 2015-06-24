using Contratos.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentadores.Modulo3
{
    public class PresentadorListarInvolucrado
    {
        private IContratoListarInvolucrado vista;
        public PresentadorListarInvolucrado(IContratoListarInvolucrado laVista)
        {
            vista = laVista;
        }
        public void MostrarModal(String alert){
            if (alert == "true")
            {
                vista.alertClase = RecursosInterfazM3.Alerta_Clase_Exito;
                vista.alertRol = RecursosInterfazM3.Alerta_Rol;
                vista.alert = RecursosInterfazM3.Alerta_Html +
                 RecursosInterfazM3.Alerta_Usuario_Agregado +
                 RecursosInterfazM3.Alerta_Html_Final;
            }
        }
    }
    }
