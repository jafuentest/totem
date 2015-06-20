﻿using DAO.Fabrica;
using DAO.IntefazDAO.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoDatosContactoID : Comando<int, Dominio.Entidad>
    {
        /// <summary>
        /// Comando que elimina un requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento a eliminar</param>
        /// <returns>true si se puede eliminar</returns>
        public override Dominio.Entidad Ejecutar(int parametro)
        {
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaDAOSqlServer.ObtenerFabricaSqlServer();
                IDaoInvolucrados daoInvolucrados = laFabrica.ObtenerDaoInvolucrados();
                return daoInvolucrados.DatosContactoID(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}