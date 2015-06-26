﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Contratos.Modulo1;
using Dominio;
using Dominio.Fabrica;
using Comandos;
using Comandos.Fabrica;
using Dominio.Entidades.Modulo7;
using System.Web.UI;

namespace Presentadores.Modulo1
{
    public class PresentadorLogin
    {
        private IContratoLogin vista;
        private bool captchaActivo = false;
        private int intentos = 0;


        /// <summary>
        /// Constructor de la clase Presentador Login
        /// </summary>
        /// <param name="laVista">Vista que usa el Presentador</param>
        public PresentadorLogin(IContratoLogin laVista)
        {
            vista = laVista;
        }

        /// <summary>
        /// Método que maneja que se activa cuando el usario le da click a Iniciar Sesión
        /// 1° Valida si los campos estan correctamente llenos
        /// 2° Verfica si el Usuario existe en la base de datos 
        /// 3° Crea las credenciales
        /// </summary>
        public void ManejarEventoLogin_Click()
        {
            try
            {
                FabricaEntidades fabricaEntidades = new FabricaEntidades();
                Entidad credenciales = fabricaEntidades.ObtenerUsuario();
                if (!captchaActivo)
                {
                    List<string> usuarioLogin = new List<string>();
                    usuarioLogin.Add(vista.Usuario);
                    usuarioLogin.Add(vista.Clave);

                    if (string.IsNullOrEmpty(vista.Usuario))
                    {
                        throw new Exception(RecursosM1.Mensaje_AlertaUsername);
                    }

                    if (string.IsNullOrEmpty(vista.Clave))
                    {
                        throw new Exception(RecursosM1.Mensaje_AlertaClave);
                    }
                    Comando<List<string>, Entidad> comando = FabricaComandos.CrearComandoIniciarSesion();

                    credenciales = comando.Ejecutar(usuarioLogin);
                    if ( ((Usuario)credenciales).Correo != "" && ((Usuario)credenciales).Correo != null )
                    {
                        HttpContext.Current.Session[RecursosM1.LUsuario] =
					   (credenciales as Usuario).Username;
				    HttpContext.Current.Session[RecursosM1.LUsuarioRol] =
					   (credenciales as Usuario).Rol;

				    Comando<String, List<Dominio.Entidad>> listaProyectos;
				    listaProyectos = Comandos.Fabrica.FabricaComandos.
					   CrearComandoConsultarProyectosPorUsuario();
				    try
				    {
					   List<Dominio.Entidad> proyectos = 
						  listaProyectos.Ejecutar((credenciales as Usuario).Username.ToString());

					   HttpContext.Current.Session[RecursosM1.LProyectoCodigo] = (proyectos[0] as Dominio.Entidades.Modulo4.Proyecto).Codigo;
					   HttpContext.Current.Session[RecursosM1.LProyectoNombre] = (proyectos[0] as Dominio.Entidades.Modulo4.Proyecto).Nombre;
				    }
				    catch (ExcepcionesTotem.Modulo4.UsuarioSinProyectosException)
				    {
					   HttpContext.Current.Session[RecursosM1.LProyectoCodigo] = "Ninguno";
				    }

                        HttpContext.Current.Session[RecursosM1.Parametro_Credencial] = (Usuario)credenciales;

                        HttpContext.Current.Response.Redirect(RecursosM1.Ventana_Default);
                    }
                    else
                    {
                        vista.SetMesaje(true, RecursosM1.Mensaje_ErrorLogin);
                    }

                    intentos++;

                }

            }
            catch (ExcepcionesTotem.Modulo1.IntentosFallidosException e)
            {
                vista.SetMesaje(true, e.Message);
            }
            catch (ExcepcionesTotem.Modulo1.LoginErradoException e)
            {
                vista.SetMesaje(true, e.Message);

            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD e)
            {
                vista.SetMesaje(true, e.Message);
            }
            catch (Exception e)
            {
                vista.SetMesaje(true, e.Message);
            }

        }

    }
}
