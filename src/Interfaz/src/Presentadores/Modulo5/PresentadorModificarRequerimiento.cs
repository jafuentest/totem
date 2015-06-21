using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Presentadores.Modulo5
{
    public class PresentadorModificarRequerimiento
    {
        private Contratos.Modulo5.IContratoModificarRequerimiento vista;

        public PresentadorModificarRequerimiento(Contratos.Modulo5.IContratoModificarRequerimiento vista)
        {
            this.vista = vista;
        }


        /// <summary>
        /// Metodo encargado de eliminar un requerimiento particular
        /// </summary>
        public void EliminarRequerimiento()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado de modificar un requerimiento particular
        /// </summary>
        public void ModificarRequerimiento()
        {

            throw new NotImplementedException();

        }

        /// <summary>
        /// Metodo que carga los datos en la interfaz de modificar
        /// </summary>
        public void CargarDatos()
        {
            try
            {
                string codigo = HttpContext.Current.Request.QueryString["id"];
                Dominio.Entidad parametro;
                parametro = Dominio.Fabrica.FabricaEntidades.ObtenerRequerimiento(codigo);
                Comandos.Comando<Dominio.Entidad, Dominio.Entidad> comandoConsultar;
                comandoConsultar =
                    Comandos.Fabrica.FabricaComandos.CrearComandoConsultarRequerimiento();
                parametro = comandoConsultar.Ejecutar(parametro);
                Dominio.Entidades.Modulo5.Requerimiento requerimiento = 
                    (Dominio.Entidades.Modulo5.Requerimiento)parametro;
                vista.idRequerimiento = requerimiento.Codigo;
                vista.funcional = requerimiento.Tipo;
                vista.prioridad = requerimiento.Prioridad;
                vista.requerimiento = requerimiento.Descripcion;
                vista.finalizado = requerimiento.Estatus;
            }
            #region Capturar Excepcion
            catch (ExcepcionesTotem.Modulo5.CamposInvalidosException ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosGeneralPresentadores.Mensaje_Error_InputInvalido +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosGeneralPresentadores.Mensaje_Error_BaseDatos +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Requerimiento_Invalido +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Error_General +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (Exception e)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Error_General +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            #endregion
        }
    }
}
