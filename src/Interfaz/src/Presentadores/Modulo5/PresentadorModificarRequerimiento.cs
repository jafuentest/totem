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
            try
            {
                Dominio.Fabrica.FabricaEntidades fabricaEntidades =
                    new Dominio.Fabrica.FabricaEntidades();
                Dominio.Entidad requerimiento =
                   fabricaEntidades.ObtenerRequerimiento(vista.idRequerimiento);
                Comandos.Comando<Dominio.Entidad, bool> comandoEliminar;
                comandoEliminar = Comandos.Fabrica.FabricaComandos.CrearComandoEliminarRequerimiento();
                if (comandoEliminar.Ejecutar(requerimiento))
                {
                    HttpContext.Current.Response.Redirect(
                                RecursosPresentadorModulo5.Ventana_Listar_Requerimiento +
                                RecursosPresentadorModulo5.Codigo_Exito_Eliminar);
                }

                throw new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException(
                        RecursosPresentadorModulo5.Codigo_Error_Requerimiento_Errado,
                        RecursosPresentadorModulo5.Mensaje_Error_Requerimiento_Errado,
                        new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());
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

        /// <summary>
        /// Metodo encargado de modificar un requerimiento particular
        /// </summary>
        public void ModificarRequerimiento()
        {

             try
            {
                if (ValidarCampos())
                {
                    HttpCookie pcookie = HttpContext.Current.Request.Cookies.Get("selectedProjectCookie");
                    //elProy.Codigo =  pcookie.Values["projectCode"].ToString(); //De aqui se debe extraer el codigo del proyecto
                    Comandos.Comando<Dominio.Entidad, Boolean> comandoModificar;
                    Dominio.Entidad requerimiento;
                    Dominio.Fabrica.FabricaEntidades fabricaEntidades =
                        new Dominio.Fabrica.FabricaEntidades();
                    requerimiento = fabricaEntidades.ObtenerRequerimiento(
                        vista.idRequerimiento, vista.requerimiento, vista.funcional,
                        vista.prioridad, vista.finalizado, "TOT"); //Cableado
                    /*Dominio.Entidad requerimiento;
                    requerimiento = Dominio.Fabrica.FabricaEntidades.ObtenerRequerimiento(
                        vista.idRequerimiento, vista.requerimiento, vista.funcional,
                        vista.prioridad, vista.finalizado,pcookie.Values["projectCode"].ToString());
                     Para Cuando funcione el cookie del proyecto*/

                    comandoModificar = Comandos.Fabrica.FabricaComandos.CrearComandoModificarRequerimiento();
                    if (comandoModificar.Ejecutar(requerimiento))
                    {
                        HttpContext.Current.Response.Redirect(
                            RecursosPresentadorModulo5.Ventana_Listar_Requerimiento +
                            RecursosPresentadorModulo5.Codigo_Exito_Modificar);
                    }

                    throw new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException(
                        RecursosPresentadorModulo5.Codigo_Error_Requerimiento_Errado,
                        RecursosPresentadorModulo5.Mensaje_Error_Requerimiento_Errado,
                        new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());

                }
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

        /// <summary>
        /// Metodo que carga los datos en la interfaz de modificar
        /// </summary>
        public void CargarDatos()
        {
            try
            {
                string codigo = HttpContext.Current.Request.QueryString["id"];
                Dominio.Entidad parametro;
                Dominio.Fabrica.FabricaEntidades fabricaEntidades =
                    new Dominio.Fabrica.FabricaEntidades();
                parametro = fabricaEntidades.ObtenerRequerimiento(codigo);
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


        /// <summary>
        /// Metodo que valida todos los campos de la vista
        /// </summary>
        /// <returns>true si todos los campos son validos</returns>
        public bool ValidarCampos()
        {
            List<String> campos = ListaDeCampos();
            if (Validaciones.ValidarCamposVacios(campos))
            {
                return true;
            }

            ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                new ExcepcionesTotem.Modulo5.CamposInvalidosException(
                RecursosGeneralPresentadores.Codigo_Error_InputInvalido,
                RecursosGeneralPresentadores.Mensaje_Error_InputInvalido,
                new ExcepcionesTotem.Modulo5.CamposInvalidosException()));

            throw new ExcepcionesTotem.Modulo5.CamposInvalidosException(
                RecursosGeneralPresentadores.Codigo_Error_InputInvalido,
                RecursosGeneralPresentadores.Mensaje_Error_InputInvalido,
                new ExcepcionesTotem.Modulo5.CamposInvalidosException());
        }


        /// <summary>
        /// Metodo que agrega todos los campos en una lista de String
        /// </summary>
        /// <returns>Lista de String con todos los campos</returns>
        public List<String> ListaDeCampos()
        {
            List<String> campos = new List<string>();
            campos.Add(vista.idRequerimiento);
            campos.Add(vista.prioridad);
            campos.Add(vista.requerimiento);
            campos.Add(vista.funcional);
            campos.Add(vista.finalizado);
            return campos;
        }

    }
}
