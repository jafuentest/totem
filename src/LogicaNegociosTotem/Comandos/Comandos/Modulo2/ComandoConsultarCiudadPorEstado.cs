using DAO.Fabrica;
using DAO.IntefazDAO.Modulo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo2
{
    public class ComandoConsultarCiudadPorEstado : Comando<String,List<String>>
    {
        public override List<string> Ejecutar(string parametro)
        {
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.consultarCiudadesPorEstado(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
