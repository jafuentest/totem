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

            #region Modulo 1
            #endregion

            #region Modulo 2
            public abstract IntefazDAO.Modulo2.IDaoClienteJuridico ObtenerDaoClienteJuridico();
            public abstract IntefazDAO.Modulo2.IDaoClienteNatural ObtenerDaoClienteNatural();
            #endregion

            #region Modulo 3
            public abstract IntefazDAO.Modulo3.IDaoInvolucrados ObtenerDaoInvolucrados();
            #endregion

            #region Modulo 4
            #endregion

            #region Modulo 5
                public abstract IntefazDAO.Modulo5.IDaoRequerimiento ObtenerDAORequerimiento();
            #endregion

            #region Modulo 6

                public abstract IntefazDAO.Modulo6.IDaoActor ObtenerDAOActor();
                public abstract IntefazDAO.Modulo6.IDaoCasoDeUso ObtenerDAOCasoDeUso();
            
            #endregion

            #region Modulo 7
            /// <summary>
            /// Metodo abstracto para la Fabrica contreta FabricaDaoSqlServer que crea la interfaz IDaoUsuario
            /// </summary>
            /// <returns>La creacion de la interfaz IdaoUsuario</returns>
            public abstract IntefazDAO.Modulo7.IDaoUsuario ObtenerDAOUsuario();
            #endregion

            #region Modulo 8
                public abstract IntefazDAO.Modulo8.IDaoAcuerdo ObtenerDAOAcuerto();
                public abstract IntefazDAO.Modulo8.IDaoMinuta ObtenerDAOMinuta();
                public abstract IntefazDAO.Modulo8.IDaoPunto ObtenerDAOPunto();
            #endregion

        #endregion
    }
}
