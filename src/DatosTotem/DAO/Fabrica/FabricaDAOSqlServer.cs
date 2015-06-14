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
        public override IntefazDAO.Modulo2.IDaoClienteJuridico ObtenerDaoClienteJuridico()
        {
            return new DAO.Modulo2.DaoClienteJuridico();
        }
        public override IntefazDAO.Modulo2.IDaoClienteNatural ObtenerDaoClienteNatural()
        {
            return new DAO.Modulo2.DaoClienteNatural();
        }
        #endregion

        #region Modulo 3
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
        public override IntefazDAO.Modulo5.IDaoRequerimiento ObtenerDAORequerimiento()
        {
            return new DAO.Modulo5.DAORequerimiento();
        }
        #endregion

        #region Modulo 6
        public override IntefazDAO.Modulo6.IDaoActor ObtenerDAOActor() 
        {
            return new DAO.Modulo6.DAOActor(); 
        }

        public override IntefazDAO.Modulo6.IDaoCasoDeUso ObtenerDAOCasoDeUso()
        {
            return new DAO.Modulo6.DAOCasoDeUso(); 
        }

        #endregion

        #region Modulo 7
        #endregion

        #region Modulo 8
        #endregion

        
    }
}
