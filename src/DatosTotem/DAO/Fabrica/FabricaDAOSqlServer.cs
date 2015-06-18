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
        public override IntefazDAO.Modulo3.IDaoInvolucrados ObtenerDaoInvolucrados()
        {
            return new DAO.Modulo3.DAOInvolucrados();
        }
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
        /// <summary>
        /// Metodo sobreescrito de la Fabrica Abstracta para crear el objeto concreto DAOUsuario
        /// </summary>
        /// <returns>El objeto concreto DAOUsuario</returns>
        public override IntefazDAO.Modulo7.IDaoUsuario ObtenerDAOUsuario()
        {
            return new DAO.Modulo7.DAOUsuario();
        }
        #endregion

        #region Modulo 8
            public override IntefazDAO.Modulo8.IDaoAcuerdo ObtenerDAOAcuerto()
            {
                return new DAO.Modulo8.DaoAcuerdo();
            }
            public override IntefazDAO.Modulo8.IDaoMinuta ObtenerDAOMinuta()
            {
                return new DAO.Modulo8.DaoMinuta();
            }
            public override IntefazDAO.Modulo8.IDaoPunto ObtenerDAOPunto()
            {
                return new DAO.Modulo8.DaoPunto();
            }
        #endregion

    }
}
