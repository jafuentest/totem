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
            List<Minuta> listaMinuta = new List<Minuta>()
            {
                new Minuta()
                {
                    Codigo = "1",
                    Motivo = "Reunión Skype",
                    Fecha = DateTime.Now,
                },
                new Minuta()
                {
                    Codigo = "2",
                    Motivo = "Levantamiento de Requerimientos",
                    Fecha = DateTime.Now,
                },
                new Minuta()
                {
                    Codigo = "3",
                    Motivo = "Alcance del Proyecto",
                    Fecha = DateTime.Now,
                }
            };


            //return minutaDatos.ConsultarMinutasProyecto(elProyecto);
            return listaMinuta;
        }
    }
}
