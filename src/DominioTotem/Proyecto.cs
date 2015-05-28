using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTotem
{
    public class Proyecto
    {
        
        #region Atributos

        /// <summary>
        /// Clase proyecto
        /// <attr name="codigo">Codigo unico indentificador del proyecto</attr>
        /// <attr name="nombre">Nombre del proyecto</attr>
        /// <attr name="estado">Estado en el que se encuentra el proyecto {Activo, Inactivo}</attr>
        /// <attr name="descripcion">Descripcion completa sobre el proyecto</attr>
        /// <attr name="moneda">Moneda base en la que se esta cobrando por la realizacion del proyecto</attr>
        /// <attr name="costo">Costo de realizacion del 100% del proyecto</attr>
        /// </summary>
        
        private String codigo;
        private String nombre;
        private bool estado = true;
        private String descripcion;
        private String moneda;
        private int costo;

        #endregion

        #region Constructor

        /// <summary>
        /// Contructor publico sin parametros de la clase proyecto
        /// </summary>
        public Proyecto()
        {
        }

        /// <summary>
        /// Contructor publico de la clase proyecto
        /// <param name="codigo">Codigo unico indentificador del proyecto</param>
        /// <param name="nombre">Nombre del proyecto</param>
        /// <param name="estado">Estado en el que se encuentra el proyecto {Activo, Inactivo}</param>
        /// <param name="descripcion">Descripcion completa sobre el proyecto</param>
        /// <param name="moneda">Moneda base en la que se esta cobrando por la realizacion del proyecto</param>
        /// <param name="costo">Costo de realizacion del 100% del proyecto</param>
        /// </summary>
        public Proyecto(String codigo, String nombre, bool estado, String descripcion, String moneda, int costo)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.estado = estado;
            this.descripcion = descripcion;
            this.moneda = moneda;
            this.costo = costo;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Getters y Setters de la clase Proyecto
        /// Propiedades:
        ///     + Codigo {get,set}
        ///     + Nombre {get,set}
        ///     + Estado {get,set}
        ///     + Descripcion {get,set}
        ///     + Moneda {get,set}
        ///     + Costo {get,set}
        /// </summary>
        
        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public String Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }

        public int Costo
        {
            get { return costo; }
            set { costo = value; }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo para retornar la informacion detallada dado el codigo de un proyecto
        /// Excepciones posibles: 
        /// Ninguna
        /// </summary>
        /// <param name="codigo">Codigo asociado al proyecto al cual se solicita la información</param>
        /// <returns>Retorna el objeto Proyecto al codigo asociado recibido, si existe</returns>
        public Proyecto DetalleProyecto(String codigo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para cambiar el estado del proyecto a activo o inactivo dependiendo del caso
        /// Excepciones posibles: 
        /// Ninguna
        /// </summary>
        /// <param name="codigo">Codigo asociado al proyecto al cual se solicita la información</param>
        /// <param name="estado">Estado actual del proyecto</param>
        /// <returns>Retorna true o false dependiendo si se pudo cambiar el estado del proyecto o no</returns>
        public bool CambiarEstado (String codigo, bool estado)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para modificar la informacion general de un proyecto
        /// Excepciones posibles: 
        /// CodigoRepetidoException()
        /// </summary>
        /// <param name="codigo">Nuevo codigo del proyecto</param>
        /// <param name="nombre">Nuevo nombre del proyecto</param>
        /// <param name="estado">Nuevo estado del proyecto</param>
        /// <param name="descripcion">Nueva descripcion del proyecto</param>
        /// <param name="moneda">Nueva moneda del proyecto</param>
        /// <param name="costo">Nuevo costo del proyecto</param>
        /// <returns>Retorna el objeto Proyecto con la informacion modificada</returns>
        public Proyecto ModificarProyecto(String codigo, String nombre, bool estado, String descripcion, String moneda, float costo)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}