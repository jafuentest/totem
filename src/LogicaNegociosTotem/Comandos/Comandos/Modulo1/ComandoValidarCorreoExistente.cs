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
    public class ComandoValidarCorreoExistente : Comando<string, bool>
    {
        public override bool Ejecutar(string parametro)
        {

                FabricaAbstractaDAO fabricaDao = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoLogin idaoLogin = fabricaDao.ObtenerDaoLogin();
                return idaoLogin.ValidarCorreoExistente(parametro);
        }
    }
}
