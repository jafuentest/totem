using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo7;
using DAO.DAO;
using DAO.IntefazDAO.Modulo1;
using DAO.Fabrica;

namespace Comandos.Comandos.Modulo1
{
    class ComandoValidarCorreoExistente : Comando<string, bool>
    {
        public override bool Ejecutar(string parametro)
        {

            try
            {
                FabricaAbstractaDAO fabricaDao = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoLogin idaoLogin = fabricaDao.ObtenerDaoLogin();
                return idaoLogin.ValidarCorreoExistente(parametro);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                    ex);

                throw ex;
            }
        }
    }
}
