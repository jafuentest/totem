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
    public class ComandoConsultarXIDClienteNatural : Comando<Entidad, Entidad>
    {
        public override Entidad Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoClienteNatural daoClienteNat = laFabrica.ObtenerDaoClienteNatural();

                return daoClienteNat.ConsultarXId(parametro);
            }
            catch (Exception Exception)
            {
                throw new Exception();
            }
        }
    }
}
