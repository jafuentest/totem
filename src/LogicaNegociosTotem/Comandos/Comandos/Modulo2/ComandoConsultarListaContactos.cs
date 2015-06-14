using DAO.Fabrica;
using DAO.IntefazDAO.Modulo2;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo2
{
    public class ComandoConsultarListaContactos : Comando<Entidad,List<Entidad>>
    {
        public override List<Entidad> Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.consultarListaDeContactosJuridico(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }
    }
}
