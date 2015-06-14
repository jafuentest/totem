using DAO.Fabrica;
using DAO.IntefazDAO.Modulo2;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo2
{
    public class ComandoConsultarClienteJurXID : Comando<Entidad, Entidad>
    {
        public override Entidad Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.ConsultarXId(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
