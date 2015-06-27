using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo7;
using Datos.DAO;
using Datos.IntefazDAO.Modulo1;
using Datos.Fabrica;

namespace Comandos.Comandos.Modulo1
{
    public class ComandoValidarCorreoExistente : Comando<string, bool>
    {
        public override bool Ejecutar(string parametro)
        {

            try
            {
                FabricaDAOSqlServer fabricaDao = new FabricaDAOSqlServer();
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
