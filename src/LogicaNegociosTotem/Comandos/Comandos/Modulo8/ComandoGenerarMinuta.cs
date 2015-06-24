using Dominio.Entidades.Modulo8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
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
                System.IO.StreamReader archivoBase = new System.IO.StreamReader(RecursosComandosModulo8.Directorio+"\\"+RecursosComandosModulo8.BaseMinuta);
                System.IO.StreamWriter minuta = new System.IO.StreamWriter(RecursosComandosModulo8.Directorio+"\\"+RecursosComandosModulo8.Minuta);
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

                        /*case "puntos":
                            minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.InicioTabularPuntos);
                            minuta.WriteLine(RecursosComandosModulo8.Barras + RecursosComandosModulo8.hline);
                            minuta.WriteLine(RecursosComandosModulo8.Barras + 
                                RecursosComandosModulo8.Titulo +" "+
                                RecursosComandosModulo8.Ampersan+ 
                                RecursosComandosModulo8.Barras + 
                                RecursosComandosModulo8.Desarrollo+" "+ 
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
                            break;*/

                        case "observaciones":
                            minuta.WriteLine(laMinuta.Observaciones);
                            break;

                        /*case "compromisos":

                            /*minuta.WriteLine("\\" + "begin{tabular}{| p{7cm} | p{7cm} |}");
                            minuta.WriteLine("\\" + "hline");
                            minuta.WriteLine("\\" + "bf Titulo & " + "\\" + "bf Desarrollo " + " \\" + "\\");
                            minuta.WriteLine("\\" + "hline");
                            foreach (Acuerdo a in laMinuta.ListaAcuerdo)
                            {
                                a.
                                minuta.WriteLine(punto.Titulo + "&" + punto.Desarrollo + " " + "\\" + "\\");
                                minuta.WriteLine("\\" + "hline");
                            }
                            minuta.WriteLine("\\" + "end{tabular}");
                            break;*/
                       
                        default:
                            minuta.WriteLine(linea);
                            break;
                    }
                }
                archivoBase.Close();
                minuta.Close();
                return true;



            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
