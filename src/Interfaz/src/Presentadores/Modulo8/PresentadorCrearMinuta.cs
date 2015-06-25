using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo8;
using Comandos;
using Comandos.Fabrica;
using Comandos.Comandos.Modulo8;

namespace Presentadores.Modulo8
{
    public class PresentadorCrearMinuta
    {
        private IContratoCrearMinuta vista;
         public PresentadorCrearMinuta(IContratoCrearMinuta laVista)
        {
            vista = laVista;
        }

         public List<Dominio.Entidad> listaUsuarios(string codigoProyecto)
         {
             ComandoListaUsuario comandoListaUsuarios = (ComandoListaUsuario)FabricaComandos.CrearComandoListaUsuario();

             List<Dominio.Entidad> listaUsuario = comandoListaUsuarios.Ejecutar(codigoProyecto);

             return listaUsuario;

         }
    }
}
