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
    public class ComandoAgregarClienteJuridico : Comando<Entidad, bool>
    {
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.Agregar(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
