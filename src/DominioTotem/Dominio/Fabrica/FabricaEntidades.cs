using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades.Modulo6; 
using Dominio.Entidades;

namespace Dominio.Fabrica
{
    public class FabricaEntidades
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        public Entidad ObtenerClienteJuridico()
        {
            return new Entidades.Modulo2.ClienteJuridico();
        }
        public Entidad ObtenerClienteNatural()
        {
            return new Entidades.Modulo2.ClienteNatural();
        }
        public Entidad ObtenerContacto()
        {
            return new Entidades.Modulo2.Contacto();
        }
        public Entidad ObtenerDireccion()
        {
            return new Entidades.Modulo2.Direccion();
        }
        public Entidad ObtenerTelefono()
        {
            return new Entidades.Modulo2.Telefono();
        }
        
        #endregion

        #region Modulo 3
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
        public Entidades.Modulo5.Requerimiento ObtenerRequerimiento()
        {
            return new Entidades.Modulo5.Requerimiento();
        }

        public Entidades.Modulo5.Requerimiento
            ObtenerRequerimiento(string codigo, string descripcion, string tipo,
            string prioridad, string estatus)
        {
            return new Entidades.Modulo5.Requerimiento(
                codigo, descripcion, tipo, prioridad, estatus);
        }

        #endregion

        #region Modulo 6

        public Actor ObtenerActor() 
        {
            return new Actor(); 
        }

        public CasoDeUso ObtenerCasoDeUso() 
        {
            return new CasoDeUso(); 
        }

        #endregion

        #region Modulo 7
        #endregion

        #region Modulo 8
        #endregion
    }
}
