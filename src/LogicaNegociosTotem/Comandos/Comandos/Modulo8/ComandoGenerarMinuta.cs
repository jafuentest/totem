using Dominio.Entidades.Modulo8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
namespace Comandos.Comandos.Modulo8
{
    class ComandoGenerarMinuta : Comando<Entidad, bool>
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
                System.IO.StreamReader archivoBase = new System.IO.StreamReader(RecursosComandosModulo8.Directorio+RecursosComandosModulo8.BaseMinuta);
                System.IO.StreamWriter minuta = new System.IO.StreamWriter(RecursosComandosModulo8.Directorio+RecursosComandosModulo8.Minuta);
                while ((linea = archivoBase.ReadLine()) != null)
                {
                    switch (linea)
                    {
                        case ("titulo"):
                            minuta.WriteLine("Minuta");
                            break;
                        case "fecha":
                            minuta.WriteLine(laMinuta.Fecha);
                            break;
                        case "hora":
                            minuta.WriteLine(laMinuta.Fecha);
                            break;

                        /*case "codigo":
                            ers.WriteLine(proyecto.Codigo);
                            break;

                        case "nombre":
                            ers.WriteLine(proyecto.Nombre);
                            break;

                        case "descripcion":
                            ers.WriteLine(proyecto.Descripcion);
                            break;

                        case "precio":
                            ers.WriteLine(proyecto.Costo);
                            break;
                        case "empresa":
                            ers.WriteLine("Modulo 2 Falta");
                            Console.WriteLine("\\" + "item");
                            break;
                        case "\\" + "item" + " " + "involucrados":
                            Console.WriteLine(linea);
                            foreach (Usuario u in involucrados)
                            {
                                ers.WriteLine("\\" + "item" + " " + "Nombre:" + " " + u.nombre + " " + "Cargo:" + " " + u.cargo);
                            }
                            break;
                        case "Rf":
                            ers.WriteLine("\\" + "begin{tabular}{| l | p{7cm} | r |}");
                            ers.WriteLine("\\" + "hline");
                            ers.WriteLine("\\" + "bf ID & " + "\\" + "bf Requerimiento &" + " \\" + "bf Prioridad " + "\\" + "\\");
                            ers.WriteLine("\\" + "hline");
                            foreach (Requerimiento rf in reqFuncionales)
                            {
                                ers.WriteLine("ModuloWolf" + "&" + rf.Descripcion + "&" + rf.Prioridad + " " + "\\" + "\\");
                                ers.WriteLine("\\" + "hline");
                            }
                            ers.WriteLine("\\" + "end{tabular}");
                            break;
                        case "Rnf":
                            ers.WriteLine("\\" + "begin{tabular}{| l | p{7cm} | r |}");
                            ers.WriteLine("\\" + "hline");
                            ers.WriteLine("\\" + "bf ID & " + "\\" + "bf Requerimiento &" + " \\" + "bf Prioridad " + "\\" + "\\");
                            ers.WriteLine("\\" + "hline");
                            foreach (Requerimiento rnf in reqNoFuncionales)
                            {
                                ers.WriteLine("ModuloWolf" + "&" + rnf.Descripcion + "&" + rnf.Prioridad + " " + "\\" + "\\");
                                ers.WriteLine("\\" + "hline");
                            }
                            ers.WriteLine("\\" + "end{tabular}");
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
