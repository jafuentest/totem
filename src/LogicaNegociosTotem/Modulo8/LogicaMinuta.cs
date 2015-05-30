using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DatosTotem.Modulo8;
using DominioTotem;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo8.ExcepcionesDeDatos;

namespace LogicaNegociosTotem.Modulo8
{
    public class LogicaMinuta
    {
        private BDMinuta minutaDatos = new BDMinuta();
        private BDInvolucrados involucrados = new BDInvolucrados();
        private BDPunto puntos = new BDPunto();
        private BDAcuerdo acuerdos = new BDAcuerdo();
        private Minuta minuta;

        public List<Minuta> ListaMinuta(Proyecto elProyecto)
        {
            try
            {
                return minutaDatos.ConsultarMinutasProyecto(int.Parse(elProyecto.Codigo));
            }
            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionNullReference,
                    RecursosLogicaModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionTotemConexionBD ex)
            {

                throw new ExceptionTotemConexionBD(RecursosLogicaModulo8.Codigo,
                    RecursosLogicaModulo8.Mensaje, ex);

            }
            catch (SqlException ex)
            {
                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionSql,
                    RecursosLogicaModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                throw new ParametroIncorrectoException(RecursosLogicaModulo8.Codigo_ExcepcionParametro,
                    RecursosLogicaModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                throw new AtributoIncorrectoException(RecursosLogicaModulo8.Codigo_ExcepcionAtributo,
                    RecursosLogicaModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionGeneral,
                   RecursosLogicaModulo8.Mensaje_ExcepcionGeneral, ex);

            }

        }

        public Minuta obtenerMinuta(Proyecto elProyecto, int codigoMinuta)
        {
       
            List<int> invo = new List<int>();
            List<Usuario> usuarios = new List<Usuario>();
            List<Usuario> usuarios1 = new List<Usuario>();
            List<Acuerdo> listaAcuerdos = new List<Acuerdo>();
            try
            {
                minuta = minutaDatos.ConsultarMinutaBD(codigoMinuta);
                usuarios.Clear();
                invo = involucrados.ConsultarInvolucrado(RecursosLogicaModulo8.ProcedureConsultarUsuarioMinuta
                    , RecursosLogicaModulo8.AtributoAcuerdoUsuario, RecursosLogicaModulo8.ParametroIDMinuta, int.Parse(minuta.Codigo));
                foreach (int i in invo)
                {
                    usuarios.Add(involucrados.ConsultarUsuarioMinutas(i));
                }
                minuta.ListaUsuario = usuarios;
                minuta.ListaPunto = puntos.ConsultarPuntoBD(int.Parse(minuta.Codigo));

                listaAcuerdos = acuerdos.ConsultarAcuerdoBD(int.Parse(minuta.Codigo));
                foreach (Acuerdo acu in listaAcuerdos)
                {

                    invo = involucrados.ConsultarInvolucrado(RecursosLogicaModulo8.ProcedureConsultarUsuarioAcuerdo
                        , RecursosLogicaModulo8.AtributoAcuerdoUsuario, RecursosLogicaModulo8.ParametroIDAcuerdo, acu.Codigo);
                    foreach (int i in invo)
                    {
                        usuarios1.Add(involucrados.ConsultarUsuarioMinutas(i));
                    }
                    acu.ListaUsuario = usuarios1;
                }
                minuta.ListaAcuerdo = listaAcuerdos;
                return minuta;
            }
            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionNullReference,
                    RecursosLogicaModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionTotemConexionBD ex)
            {

                throw new ExceptionTotemConexionBD(RecursosLogicaModulo8.Codigo,
                    RecursosLogicaModulo8.Mensaje, ex);

            }
            catch (SqlException ex)
            {
                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionSql,
                    RecursosLogicaModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                throw new ParametroIncorrectoException(RecursosLogicaModulo8.Codigo_ExcepcionParametro,
                    RecursosLogicaModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                throw new AtributoIncorrectoException(RecursosLogicaModulo8.Codigo_ExcepcionAtributo,
                    RecursosLogicaModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                throw new BDMinutaException(RecursosLogicaModulo8.Codigo_ExcepcionGeneral,
                   RecursosLogicaModulo8.Mensaje_ExcepcionGeneral, ex);

            }
           
        }

        public List<Usuario> ListaUsuario(Proyecto elProyecto)
        {
            List<Usuario> ListaUsuario = new List<Usuario>()
            {
                new Usuario()
                {
                    idUsuario = 1,
                    nombre = "César",
                    apellido = "Contreras",
                    cargo = "Desarrollador"
                },
                new Usuario()
                {
                    idUsuario = 2,
                    nombre = "María",
                    apellido = "Vargas",
                    cargo = "Desarrollador"
                },
                new Usuario()
                {
                    idUsuario = 3,
                    nombre = "Jonathan",
                    apellido = "González",
                    cargo = "DBA"
                }
            };

            return ListaUsuario;
        }

        public string GuardarMinuta(Proyecto elProyecto, Minuta laMinuta)
        {
            return "Completado";
        }

        public Minuta obtenerMinutaPrueba(Proyecto elProyecto, int codigoMinuta)
        {
            //Prueba Minuta Cable
            Minuta minuta = new Minuta()
            {
                Codigo = "1",
                Motivo = "Reunión Skype",
                Fecha = new DateTime(2015, 04, 25, 15, 35, 00),
                Observaciones = "nada",
                ListaUsuario = new List<Usuario>()
                {
                    new Usuario()
                    {
                        idUsuario = 1,
                        nombre = "César",
                        apellido = "Contreras",
                        cargo = "Desarrollador"
                    },
                    new Usuario()
                    {
                        idUsuario = 2,
                        nombre = "María",
                        apellido = "Vargas",
                        cargo = "Desarrollador"
                    },
                    new Usuario()
                    {
                        idUsuario = 3,
                        nombre = "Jonathan",
                        apellido = "González",
                        cargo = "DBA"
                    }
                },
                ListaPunto = new List<Punto>()
                {
                    new Punto()
                    {
                        Codigo = 1,
                        Desarrollo = "Esta es una Prueba 1",
                        Titulo = "Título Prueba 1"                    
                    },
                    new Punto()
                    {
                        Codigo = 2,
                        Desarrollo = "Esta es una Prueba 2",
                        Titulo = "Título Prueba 2"                    
                    }
                },
                ListaAcuerdo = new List<Acuerdo>()
                {
                    new Acuerdo()
                    {
                        Codigo = 1,
                        Fecha = new DateTime(2015, 04, 29),
                        Compromiso = "Compromiso Nro 1",
                        ListaUsuario = new List<Usuario>()
                        {
                            new Usuario()
                            {
                                idUsuario = 2,
                                nombre = "María",
                                apellido = "Vargas",
                                cargo = "Desarrollador"
                            },
                            new Usuario()
                            {
                                idUsuario = 3,
                                nombre = "Jonathan",
                                apellido = "González",
                                cargo = "DBA"
                            }
                        }
                    }
                }

            };
            //Fin Prueba Minuta
            return minuta;
        }
    }
}
