using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO.Fabrica
{
    public class FabricaDAOSqlServer :FabricaAbstractaDAO
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        public override IntefazDAO.Modulo_2.IDaoClienteJuridico ObtenerDaoClienteJuridico()
        {
            return new DAO.Modulo_2.DaoClienteJuridico();
        }
        #endregion

        #region Modulo 3
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
        public override IntefazDAO.Modulo5.IDaoRequerimiento ObtenerDAORequerimiento()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Modulo 6
        #endregion

        #region Modulo 7
        #endregion

        #region Modulo 8
        #endregion

        
    }
}
