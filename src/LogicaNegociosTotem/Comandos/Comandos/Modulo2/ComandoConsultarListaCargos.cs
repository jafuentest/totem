using Dominio;
using DAO;
using DAO.IntefazDAO.Modulo2;
using DAO.Fabrica;
using DAO.DAO.Modulo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo2
{
    public class ComandoConsultarListaCargos : Comando<bool, List<String>>
    {
        public override List<string> Ejecutar(bool parametro)
        {
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.consultarListaCargos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
