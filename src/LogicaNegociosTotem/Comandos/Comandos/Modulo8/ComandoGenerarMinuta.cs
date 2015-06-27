using Dominio.Entidades.Modulo8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using System.Data.SqlClient;
using ExcepcionesTotem.Modulo8.ExcepcionesDeDatos;
using Dominio.Entidades.Modulo7;
namespace Comandos.Comandos.Modulo8
{
    public class ComandoGenerarMinuta : Comando<Entidad, bool>
    {
        /// <summary>
        /// Metodo que compila un archivo .tex
        /// </summary>
        /// <param name="parametro">nombre del archivo a compilar</param>
        /// <returns>retorna verdadero luego de compilar el archivo</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {


                Minuta laMinuta = (Minuta)parametro;
                string linea;
                System.IO.StreamReader archivoBase = new System.IO.StreamReader(RecursosComandosModulo8.Directorio + "\\" + RecursosComandosModulo8.BaseMinuta);
                System.IO.StreamWriter minuta = new System.IO.StreamWriter(RecursosComandosModulo8.Directorio + "\\" + RecursosComandosModulo8.Minuta);
                while ((linea = archivoBase.ReadLine()) != null)
                {
                    switch (linea)
                    {

                        case "fecha":
                            minuta.WriteLine(laMinuta.Fecha);
                            break;
                        case "hora":
                            minuta.WriteLine(laMinuta.Fecha);
                            break;

                        case "motivo":
                            minuta.WriteLine(laMinuta.Motivo);
                            break;

                        case "participantes":
                            if (laMinuta.ListaUsuario!=null)
                            { 
                                minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.InicioTabularPuntos);
                                minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.hline);
                                minuta.WriteLine(RecursosComandosModulo8.Barras +
                                    RecursosComandosModulo8.Nombre + " " +
                                    RecursosComandosModulo8.Ampersan +
                                    RecursosComandosModulo8.Barras +
                                    RecursosComandosModulo8.Cargo + " " +
                                    RecursosComandosModulo8.Barras +
                                    RecursosComandosModulo8.Barras);
                                minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.hline);
                                foreach (Usuario usuario in laMinuta.ListaUsuario)
                                {
                                    minuta.WriteLine(usuario.Nombre + RecursosComandosModulo8.Ampersan + usuario.Cargo + " " +
                                        RecursosComandosModulo8.Barras + RecursosComandosModulo8.Barras);
                                    minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.hline);
                                }
                                minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.FinTabular);
                            
                            }
                            else 
                            {
                                minuta.WriteLine("Minuta no posee Participantes");
                            
                            }
                            
                            break;

                        case "puntos":
                            if (laMinuta.ListaPunto != null)
                            {
                                minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.InicioTabularPuntos);
                                minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.hline);
                                minuta.WriteLine(RecursosComandosModulo8.Barras +
                                    RecursosComandosModulo8.Titulo + " " +
                                    RecursosComandosModulo8.Ampersan +
                                    RecursosComandosModulo8.Barras +
                                    RecursosComandosModulo8.Desarrollo + " " +
                                    RecursosComandosModulo8.Barras +
                                    RecursosComandosModulo8.Barras);
                                minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.hline);
                                foreach (Punto punto in laMinuta.ListaPunto)
                                {
                                    minuta.WriteLine(punto.Titulo + RecursosComandosModulo8.Ampersan + punto.Desarrollo + " " +
                                        RecursosComandosModulo8.Barras + RecursosComandosModulo8.Barras);
                                    minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.hline);
                                }
                                minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.FinTabular);
                            }
                            else
                            {
                                minuta.WriteLine("Minuta no posee Puntos");

                            }
                            break;

                        case "observaciones":
                            minuta.WriteLine(laMinuta.Observaciones);
                            break;

                        case "compromisos":

                             if (laMinuta.ListaAcuerdo != null)
                            {
                                minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.InicioTabularPuntos);
                                minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.hline);
                                minuta.WriteLine(RecursosComandosModulo8.Barras +
                                    RecursosComandosModulo8.Fecha + " " +
                                    RecursosComandosModulo8.Ampersan +
                                    RecursosComandosModulo8.Barras +
                                    RecursosComandosModulo8.Compromiso + " " +
                                    RecursosComandosModulo8.Barras +
                                    RecursosComandosModulo8.Barras);
                                minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.hline);
                                foreach (Acuerdo acuerdo in laMinuta.ListaAcuerdo)
                                {
                                    minuta.WriteLine(acuerdo.Fecha + RecursosComandosModulo8.Ampersan + acuerdo.Compromiso + " " +
                                        RecursosComandosModulo8.Barras + RecursosComandosModulo8.Barras);
                                    minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.hline);
                                }
                                minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.FinTabular);
                            }
                            else
                            {
                                minuta.WriteLine("Minuta no posee Acuerdos");

                            }
                            break;

                        default:
                            minuta.WriteLine(linea);
                            break;
                    }
                }
                archivoBase.Close();
                minuta.Close();
                return true;



            }

            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ParametroIncorrectoException ex)
            {
                throw ex;
            }
            catch (AtributoIncorrectoException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
