using DAO.Fabrica;
using DAO.IntefazDAO.Modulo2;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo2
{
    public class ComandoConsultarTodosClienteJuridico : Comando<bool, List<Entidad>>
    {
        public override List<Entidad> Ejecutar(bool parametro)
        {
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.ConsultarTodos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
