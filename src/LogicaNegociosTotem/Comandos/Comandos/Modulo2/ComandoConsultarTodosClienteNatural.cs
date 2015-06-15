using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Fabrica;
using DAO.DAO.Modulo2;
using DAO.IntefazDAO.Modulo2;

namespace Comandos.Comandos.Modulo2
{
    public class ComandoConsultarTodosClienteNatural : Comando<bool, List<Entidad>>
    {

        public override List<Entidad> Ejecutar(bool parametro)
        {
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoClienteNatural daoClienteNat = laFabrica.ObtenerDaoClienteNatural();

                return daoClienteNat.ConsultarTodos();
            }
            catch (Exception Exception)
            {
                throw new Exception();
            }
        }
    }
}
