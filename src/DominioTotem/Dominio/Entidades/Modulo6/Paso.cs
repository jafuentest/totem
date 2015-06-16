using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Entidades.Modulo6
{
    public class Paso:Entidad
    {
        #region Atributos
        private int numeroPaso;
        private string pasoDescripcion;
        private List<Extension> extensiones;

        
        #endregion

        #region Propiedades
        public int NumeroPaso
        {
            get { return numeroPaso; }
            set { numeroPaso = value; }
        }
      
        public string PasoDescripcion
        {
            get { return pasoDescripcion; }
            set { pasoDescripcion = value; }
        }

        public List<Extension> Extensiones
        {
            get { return extensiones; }
            set { extensiones = value; }
        } 


        #endregion

        #region Constructores

        public Paso() 
        :base(0)
        {
            NumeroPaso = 0;
            PasoDescripcion = string.Empty;
            Extensiones = null; 
        }

        public Paso(int numeroPaso, string elPaso, List<Extension> lasExtensiones) 
        :base(0)
        {
            NumeroPaso = numeroPaso;
            PasoDescripcion = elPaso;
            Extensiones = lasExtensiones; 
        }

        #endregion

        #region Método Equals
        /// <summary>
        /// Implementación del método Equals
        /// heredado de Object para la clase Paso
        /// </summary>
        /// <param name="obj">Objeto </param>
        /// <returns>True si es igual, false
        /// si no lo es</returns>
        public override bool Equals(object obj)
        {
            bool esIgual = false;

            try
            {
                if (obj == null)
                    esIgual = false;
                else
                {
                    esIgual = base.Equals(obj);
                    Paso aux = obj as Paso;
                    esIgual &= aux.PasoDescripcion.Equals(PasoDescripcion);
                    esIgual &= aux.NumeroPaso.Equals(NumeroPaso);
                    esIgual &= aux.Extensiones.Equals(Extensiones); 
                    esIgual &= aux.Id == Id;
                }

            }
            catch (Exception)
            {
                throw;
            }

            return esIgual;
        }
        #endregion
    }
}
