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
                   Comandos.Comando<Dominio.Entidad, Boolean> comandoModificar;
                    Dominio.Entidad requerimiento;
                    Dominio.Fabrica.FabricaEntidades fabricaEntidades =
                        new Dominio.Fabrica.FabricaEntidades();
                    requerimiento = fabricaEntidades.ObtenerRequerimiento(vista.idRequerimientoBD,
                        vista.idRequerimiento, vista.requerimiento, vista.funcional,
                        vista.prioridad, vista.finalizado,
                        pcookie.Values["projectCode"].ToString()); 

                    comandoModificar = Comandos.Fabrica.FabricaComandos.CrearComandoModificarRequerimiento();
                    if (comandoModificar.Ejecutar(requerimiento))
                    {

                       string paginaOrigen = HttpContext.Current.Request.QueryString["list"];
                       if (paginaOrigen.Equals("true"))
                       {
                           HttpContext.Current.Response.Redirect(
                               RecursosPresentadorModulo5.Ventana_Listar_Requerimiento +
                               RecursosPresentadorModulo5.Codigo_Exito_Modificar);
                       }
                       else {
                          HttpContext.Current.Response.Redirect(
                          RecursosPresentadorModulo5.Ventana_Reporte_Requerimiento +
                          RecursosPresentadorModulo5.Codigo_Exito_Modificar);
                       
                       
                       }
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
                vista.idRequerimientoBD = requerimiento.Id; //aqui se asigna bien
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

        /// <summary>
        /// Metodo que obtiene el codigo del requerimiento
        /// </summary>
        public void ObtenerCodigoRequerimiento()
        {
            try
            {
                HttpCookie pcookie = HttpContext.Current.Request.Cookies.Get("selectedProjectCookie");
                Comandos.Comando<String, List<String>> comandoBuscar;
                List<String> codigos = new List<string>();
                comandoBuscar = Comandos.Fabrica.FabricaComandos.CrearComandoBuscarCodigoRequerimiento();
                codigos = comandoBuscar.Ejecutar(pcookie.Values["projectCode"].ToString());
                if (vista.funcional.Equals("funcional", StringComparison.CurrentCultureIgnoreCase))
                {
                    vista.idRequerimiento = DesglosarCodigo(codigos[0]);
                }
                else
                {
                    vista.idRequerimiento = DesglosarCodigo(codigos[1]);
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
        /// Metodo para desglosar el codigo del requerimiento 
        /// y sumar en uno
        /// </summary>
        /// <param name="codigo">codigo del requerimiento</param>
        public String DesglosarCodigo(String codigo)
        {
            int ultimo = (int)Char.GetNumericValue(codigo[codigo.Length - 1]);
            codigo = codigo.Remove(codigo.Length - 1);
            return codigo = codigo + Convert.ToString(ultimo + 1);

        }
    }
}
