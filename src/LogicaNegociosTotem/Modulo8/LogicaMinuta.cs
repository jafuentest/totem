using System;
using System.Collections.Generic;
using DatosTotem.Modulo8;
using DominioTotem;

namespace LogicaNegociosTotem.Modulo8
{
    public class LogicaMinuta
    {
        private BDMinuta minutaDatos = new BDMinuta();

        public List<Minuta> ListaMinuta(Proyecto elProyecto)
        {
            
            return minutaDatos.ConsultarMinutasProyecto(int.Parse(elProyecto.Codigo));
            //return listaMinuta;
        }
    }
}
