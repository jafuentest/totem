using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO.Fabrica
{
    public abstract class FabricaAbstractaDAO
    {
        public static FabricaAbstractaDAO ObtenerFabricaSqlServer()
        {
            return new FabricaDAOSqlServer();
        }

        #region Metodos Abstractos
        #endregion
    }
}
