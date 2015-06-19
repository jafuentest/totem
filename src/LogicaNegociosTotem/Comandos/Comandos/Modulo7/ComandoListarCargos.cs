using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comandos;
using DAO.Fabrica;
using DAO.IntefazDAO.Modulo7;

namespace Comandos.Comandos.Modulo7
{
    public class ComandoListarCargos: Comando<bool,List<String>>
    {
        public override List<string> Ejecutar(bool parametro)
        {
 	        //throw new NotImplementedException();

            //Respuesta de la consulta;
            List<String> listaCargos = new List<String>();

            //Instanciamos la fabrica concreta SQLServer
            FabricaAbstractaDAO fabrica = FabricaAbstractaDAO.ObtenerFabricaSqlServer();

            //Obtenemos el DAO del usuario
            IDaoUsuario daoUsuario = fabrica.ObtenerDAOUsuario();

            //Consultamos en la BD
            listaCargos = daoUsuario.ListarCargos();

            //Retornamos la respuesta
            return listaCargos;
            
        }
        
    }
}
