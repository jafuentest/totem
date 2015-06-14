using DAO.Fabrica;
using DAO.IntefazDAO.Modulo2;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Comandos.Comandos.Modulo2
{
    public class ComandoConsultarListaPaises : Comando<Boolean,List<String>>
    {

        public override List<string> Ejecutar(bool parametro)
        {
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.consultarPaises();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
