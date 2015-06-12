using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Fabrica
{
    public class FabricaComandos
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        #endregion

        #region Modulo 3
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
        public static Comando<Dominio.Entidad, Boolean> CrearComandoAgregarRequerimiento()
        {
            return new Comandos.Modulo5.ComandoAgregarRequerimiento();
        }
        public static Comando<Dominio.Entidad, Boolean> CrearComandoEliminarRequerimiento()
        {
            return new Comandos.Modulo5.ComandoEliminarRequerimiento();
        }
        public static Comando<Dominio.Entidad, Dominio.Entidad> 
            CrearComandoConsultarRequerimiento()
        {
            return new Comandos.Modulo5.ComandoConsultarRequerimiento();
        }
        public static Comando<String,
        List<Dominio.Entidad>> CrearComandoConsultarRequerimientosProyecto()
        {
            return new Comandos.Modulo5.ComandoConsultarRequerimientosProyecto();
        }
        public static Comando<Dominio.Entidad, Boolean> CrearComandoModificarRequerimiento()
        {
            return new Comandos.Modulo5.ComandoModificarRequerimiento();
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
