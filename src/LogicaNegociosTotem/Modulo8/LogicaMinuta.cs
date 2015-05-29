using System;
using System.Collections.Generic;
using DatosTotem.Modulo8;
using DominioTotem;

namespace LogicaNegociosTotem.Modulo8
{
    public class LogicaMinuta
    {
        private BDMinuta minutaDatos = new BDMinuta();
        private BDInvolucrados involucrados = new BDInvolucrados();
        private BDPunto puntos = new BDPunto();
        private BDAcuerdo acuerdos = new BDAcuerdo();
        private Minuta minuta;

        public List<Minuta> ListaMinuta(Proyecto elProyecto)
        {
            
            return minutaDatos.ConsultarMinutasProyecto(int.Parse(elProyecto.Codigo));
            //return listaMinuta;
        }

        public Minuta obtenerMinuta(Proyecto elProyecto, int codigoMinuta)
        {
       
            minuta = minutaDatos.ConsultarMinutaBD(codigoMinuta);
            List<int> invo = new List<int>();
            List<Usuario> usuarios = new List<Usuario>();
            List<Usuario> usuarios1 = new List<Usuario>();
            List<Acuerdo> listaAcuerdos = new List<Acuerdo>();

            usuarios.Clear();
            invo = involucrados.ConsultarInvolucrado(RecursosLogicaModulo8.ProcedureConsultarUsuarioMinuta
                , RecursosLogicaModulo8.AtributoAcuerdoUsuario, RecursosLogicaModulo8.ParametroIDMinuta,int.Parse(minuta.Codigo));           
            foreach (int i in invo)
            {
                usuarios.Add(involucrados.ConsultarUsuarioMinutas(i));
            }
            minuta.ListaUsuario = usuarios;
            minuta.ListaPunto = puntos.ConsultarPuntoBD(int.Parse(minuta.Codigo));

            listaAcuerdos = acuerdos.ConsultarAcuerdoBD(int.Parse(minuta.Codigo));
            foreach (Acuerdo acu  in listaAcuerdos)
            {
               
            invo = involucrados.ConsultarInvolucrado(RecursosLogicaModulo8.ProcedureConsultarUsuarioAcuerdo
                , RecursosLogicaModulo8.AtributoAcuerdoUsuario, RecursosLogicaModulo8.ParametroIDAcuerdo, acu.Codigo);
            foreach (int i in invo)
            {
                usuarios1.Add(involucrados.ConsultarUsuarioMinutas(i));
            }
            acu.ListaUsuario = usuarios1;
            }
            minuta.ListaAcuerdo = listaAcuerdos;
            return minuta;
           
        }

        public List<Usuario> ListaUsuario(Proyecto elProyecto)
        {
            List<Usuario> ListaUsuario = new List<Usuario>()
            {
                new Usuario()
                {
                    idUsuario = 1,
                    nombre = "César",
                    apellido = "Contreras",
                    cargo = "Desarrollador"
                },
                new Usuario()
                {
                    idUsuario = 2,
                    nombre = "María",
                    apellido = "Vargas",
                    cargo = "Desarrollador"
                },
                new Usuario()
                {
                    idUsuario = 3,
                    nombre = "Jonathan",
                    apellido = "González",
                    cargo = "DBA"
                }
            };

            return ListaUsuario;
        }
    }
}
