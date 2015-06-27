using Datos.Fabrica;
using Datos.IntefazDAO.Modulo3;
using ExcepcionesTotem.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoAgregarContactosInvolucrados: Comando<Dominio.Entidad, Boolean>
    {
        /// <summary>
        /// Comando para agregar un contacto como involucrado
        /// </summary>
        /// <param name="parametro">Contacto a agregar</param>
        /// <returns>true si se agrego correctamente</returns>
        public override bool Ejecutar(Dominio.Entidad parametro)
        {
            bool exito = false;
            try
            {
                Datos.IntefazDAO.Modulo3.IDaoInvolucrados daoInvolucrado;
                Datos.Fabrica.FabricaDAOSqlServer fabricaDAO = new Datos.Fabrica.FabricaDAOSqlServer();
                daoInvolucrado = fabricaDAO.ObtenerDaoInvolucrados();
                exito = daoInvolucrado.AgregarContactosInvolucrados(parametro);
            }
            catch (ListaSinInvolucradosException)
            {
                exito = true;
            }
            catch (ListaSinProyectoException)
            {
                exito = false;
            }
            return exito;
        }
}

}