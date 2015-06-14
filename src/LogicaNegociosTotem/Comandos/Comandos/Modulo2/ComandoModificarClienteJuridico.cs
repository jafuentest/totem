using DAO.Fabrica;
using DAO.IntefazDAO.Modulo2;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo2
{
    public class ComandoModificarClienteJuridico : Comando<Entidad, bool>
    {
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.Modificar(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
