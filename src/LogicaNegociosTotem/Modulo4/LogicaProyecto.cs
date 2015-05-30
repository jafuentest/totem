using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using DominioTotem;
using System.IO;

namespace LogicaNegociosTotem.Modulo4
{
    /// <summary>
    /// Clase que maneja la logica de los proyectos
    /// </summary>
    public static class LogicaProyecto
    {

        #region Crear


        /// <summary>
        /// Metodo para Agregar un proyecto en BD
        /// </summary>
        /// <param name="proyecto">proyecto a crear
        /// <returns>Retorna True si se crea, de lo contrario genera
        /// una exception(CodigoRepetido)</returns>
        public static bool CrearProyecto(DominioTotem.Proyecto proyecto)
        {

            try
            {
                return DatosTotem.Modulo4.BDProyecto.CrearProyecto(proyecto);
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Metodo para Agregar un proyecto en BD
        /// </summary>
        /// <param name="proyecto">proyecto a crear
        /// <param name="clienteJuridico">Cliente juridico del proyecto</param>
        /// <returns>Retorna True si se crea, de lo contrario genera
        /// una exception(CodigoRepetido)</returns>
        public static bool CrearProyecto(DominioTotem.Proyecto proyecto, DominioTotem.ClienteJuridico clienteJuridico)
        {

            try
            {
                return DatosTotem.Modulo4.BDProyecto.CrearProyecto(proyecto,clienteJuridico);
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metodo para Agregar un proyecto en BD
        /// </summary>
        /// <param name="proyecto">proyecto a crear
        /// <param name="clienteNatural">Cliente natural del proyecto</param>
        /// <returns>Retorna True si se crea, de lo contrario genera
        /// una exception(CodigoRepetido)</returns>
        public static bool CrearProyecto(DominioTotem.Proyecto proyecto, DominioTotem.ClienteNatural clienteNatural)
        {

            try
            {
                return DatosTotem.Modulo4.BDProyecto.CrearProyecto(proyecto, clienteNatural);
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException e)
            {
                throw e;
            }
        }

        #endregion

        #region Consultar
        /// <summary>
        /// Metodo para consultar un proyecto en BD
        /// </summary>
        /// <param name="codigo">codigo del proyecto a consultar
        /// <returns>Devuelve como resultado un proyecto en caso 
        /// contrario devuelve null</returns>
        /// 
        public static DominioTotem.Proyecto ConsultarProyecto(String codigo)
        {
            return DatosTotem.Modulo4.BDProyecto.ConsultarProyecto(codigo);
        }

        /// <summary>
        /// Metodo para consultar los proyecto de un usuario BD
        /// </summary>
        /// <param name="username">usuario para obtener sus proyectos
        /// <returns>Devuelve como resultado un DataTableen caso 
        /// contrario devuelve null</returns>
        /// 
        public static DataTable ConsultarTodosLosProyectos(String username)
        {
            try
            {
                return DatosTotem.Modulo4.BDProyecto.ConsultarProyectosUsuario(username);
            }
            catch(ExcepcionesTotem.Modulo4.InvolucradosInexistentesException e)
            {
                throw e;
            }
        }

        #endregion

        #region Modificar
        /// <summary>
        /// Metodo para Modificar un proyecto en BD
        /// </summary>
        /// <param name="proyecto">proyecto a crear
        /// <returns>Devuelve True si lo modifica, de lo contrario devuelve false</returns>
        public static bool ModificarProyecto(DominioTotem.Proyecto proyecto, String codigoAnterior)
        {
            try
            {
                return DatosTotem.Modulo4.BDProyecto.ModificarProyecto(proyecto, codigoAnterior);
            }
            catch (ExcepcionesTotem.Modulo4.CodigoRepetidoException)
            {
                return false;
            }
        }
        #endregion

        #region Generar Documentos

        /// <summary>
        /// Metodo para compilar el documento .tex 
        /// Excepciones posibles: 
        ///
        /// </summary>

        static void CompilarArchivoLatex()
        {
            Process p1 = new Process();
            p1.StartInfo.FileName = @"C:/Program Files (x86)/MiKTeX 2.9/miktex/bin/pdflatex.exe";
            string a = Path.GetFullPath(@"ers.tex");
            p1.StartInfo.Arguments = @"ers.tex";
            p1.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p1.StartInfo.RedirectStandardOutput = true;
            p1.StartInfo.UseShellExecute = false;
            try
            {
                p1.Start();

                //p1.WaitForExit();
                p1.Dispose();
                


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Metodo para eliminar archivo existente 
        /// Excepciones posibles: 
        /// IOException
        /// </summary>


        static void EliminarArchivo(string path)
        {
            if (System.IO.File.Exists(path))
            {
                try
                {
                    System.IO.File.Delete(path);
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static void ArchivoBase()
        {
            try
            {
                EliminarArchivo(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\GUI\Modulo4\docs\BaseErs.tex");
                System.IO.StreamWriter ers = new System.IO.StreamWriter(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\GUI\Modulo4\docs\BaseErs.tex");
                ers.WriteLine("\\" + "documentclass{article}");
                ers.WriteLine("\\" + "usepackage{graphicx}");
                ers.WriteLine("\\" + "title");
                ers.WriteLine("{");
                ers.WriteLine("titulo");
                ers.WriteLine("}");
                ers.WriteLine("\\" + "date");
                ers.WriteLine("{");
                ers.WriteLine("fecha");
                ers.WriteLine("}");
                ers.WriteLine("\\" + "author");
                ers.WriteLine("{");
                ers.WriteLine("autor");
                ers.WriteLine("}");
                ers.WriteLine("\\" + "begin{document}");
                ers.WriteLine("\\" + "maketitle % Creates the titlepage");
                ers.WriteLine("\\" + "pagenumbering{gobble} % Turns off page numbering");
                ers.WriteLine("\\" + "newpage % Starts a new page");
                ers.WriteLine("\\" + "pagenumbering{arabic} % Turns on page numbering");
                ers.WriteLine("\\" + "begin{center}");
                ers.WriteLine("\\" + "section{Datos del Proyecto}");
                ers.WriteLine("\\" + "end{center}");
                ers.WriteLine("\\" + "subsection{Codigo del Proyecto}");
                ers.WriteLine("codigo");
                ers.WriteLine("\\" + "subsection{Nombre del Proyecto}");
                ers.WriteLine("nombre");
                ers.WriteLine("\\" + "subsection{Descripcion}");
                ers.WriteLine("descripcion");
                ers.WriteLine("\\" + "subsection{Precio en BS}");
                ers.WriteLine("precio");
                ers.WriteLine("\\" + "subsection{Empresa desarrolladora}");
                ers.WriteLine("empresa");
                ers.WriteLine("\\" + "subsection{Involucrados}");
                ers.WriteLine("\\" + "begin{itemize}");
                ers.WriteLine("\\" + "item involucrados");
                ers.WriteLine("\\" + "end{itemize}");
                ers.WriteLine("\\" + "newpage ");
                ers.WriteLine("\\" + "begin{center}");
                ers.WriteLine("\\" + "section{Requerimientos}");
                ers.WriteLine("\\" + "end{center}");
                ers.WriteLine("\\" + "subsection{Requerimientos Funcionales}");
                ers.WriteLine("Rf");
                ers.WriteLine("\\" + "newpage %Nueva Pagina");
                ers.WriteLine("\\" + "subsection{Requerimientos No Funcionales}");
                ers.WriteLine("Rnf");
                ers.WriteLine("\\" + "newpage");
                ers.WriteLine("\\" + "begin{center}");
                ers.WriteLine("\\" + "section{Casos de Uso}");
                ers.WriteLine("\\" + "end{center}");
                ers.WriteLine("casosDeUso");
                ers.WriteLine("\\" + "end{document}");
                ers.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }



        /// <summary>
        /// Metodo para generar el documento ERS del un proyecto (archivo .pdf descargable).
        /// Excepciones posibles: 
        /// CasosDeUsoInexistentesException()
        /// RequerimientosInexistentesException()
        /// InvolucradosInexistentesException()
        /// </summary>
        /// <param name="codigo">Codigo del proyecto al que se le generara el ERS</param>
        public static void GenErs(String codigo)
        {
            string linea;
            EliminarArchivo(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\GUI\Modulo4\docs\ers.tex");
            try
            {
                Proyecto proyecto = LogicaNegociosTotem.Modulo4.LogicaProyecto.ConsultarProyecto(codigo);
                ListaInvolucradoUsuario involucrados = new ListaInvolucradoUsuario();
                LogicaNegociosTotem.Modulo3.LogicaInvolucrados logInv = new LogicaNegociosTotem.Modulo3.LogicaInvolucrados(proyecto);
                involucrados = logInv.obtenerUsuariosInvolucradosProyecto(proyecto);
                LogicaNegociosTotem.Modulo6.LogicaCasoUso cu = new Modulo6.LogicaCasoUso();
                List<CasoDeUso> listaCU = cu.ListarCasosDeUso();
                System.IO.StreamReader archivoBase = new System.IO.StreamReader(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\GUI\Modulo4\docs\BaseErs.tex");
                System.IO.StreamWriter ers = new System.IO.StreamWriter("ers.tex");
                while ((linea = archivoBase.ReadLine()) != null)
                {
                    switch (linea)
                    {
                        case ("titulo"):
                            ers.WriteLine("Especificacion de Requerimientos de Software");
                            break;
                        case "fecha":
                            DateTime auxiliar = DateTime.Today;
                            string fecha = auxiliar.ToShortDateString();
                            ers.WriteLine(fecha);
                            break;
                        /*case "autor":
                            ers.WriteLine("Nombre Empresa Desarrolladora");
                            break;*/

                        case "codigo":
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
                            foreach (Usuario u in involucrados.Lista)
                            {
                                ers.WriteLine("\\" + "item" + " " + "Nombre:" + " " + u.nombre + " " + "Cargo:" + " " + u.cargo);
                            }
                            break;
                        case "Rf":
                            ers.WriteLine("\\" + "begin{tabular}{| l | p{7cm} | r |}");
                            ers.WriteLine("\\" + "hline");
                            ers.WriteLine("\\" + "bf ID & " + "\\" + "bf Requerimiento &" + " \\" + "bf Prioridad " + "\\" + "\\");
                            ers.WriteLine("\\" + "hline");
                            for (int i = 0; i <= 5; i++)
                            {
                                ers.WriteLine("ModuloWolf" + "&" + "ModuloWolf" + "&" + "ModuloWolf" + " " + "\\" + "\\");
                                ers.WriteLine("\\" + "hline");
                            }
                            ers.WriteLine("\\" + "end{tabular}");
                            break;
                        case "Rnf":
                            ers.WriteLine("\\" + "begin{tabular}{| l | p{7cm} | r |}");
                            ers.WriteLine("\\" + "hline");
                            ers.WriteLine("\\" + "bf ID & " + "\\" + "bf Requerimiento &" + " \\" + "bf Prioridad " + "\\" + "\\");
                            ers.WriteLine("\\" + "hline");
                            for (int i = 0; i <= 5; i++)
                            {
                                ers.WriteLine("ModuloWolf" + "&" + "ModuloWolf" + "&" + "ModuloWolf" + " " + "\\" + "\\");
                                ers.WriteLine("\\" + "hline");
                            }
                            ers.WriteLine("\\" + "end{tabular}");
                            break;
                        case "casosDeUso":
                            foreach (CasoDeUso c in listaCU)
                            {
                                ers.WriteLine("\\" + "begin{tabular}{|p{3cm}| p{10cm} |}");
                                ers.WriteLine("\\" + "hline");
                                ers.WriteLine("\\" + "bf" + " " + "Caso de Uso" + " " + "&" + " " + c.IdentificadorCasoUso + " " + c.TituloCasoUso + "\\" + "\\");
                                ers.WriteLine("\\" + "hline");
                                ers.WriteLine("\\" + "bf" + " " + "Precondicion" + " " + "&");
                                foreach (String precondicion in c.PrecondicionesCasoUso)
                                {
                                    ers.WriteLine(precondicion);
                                }
                                ers.WriteLine("\\" + "\\");
                                ers.WriteLine("\\" + "hline");
                                ers.WriteLine("\\" + "bf" + " " + "Condicion Final de Exito" + " " + "&" + " " + c.CondicionExito + "\\" + "\\");
                                ers.WriteLine("\\" + "hline");
                                ers.WriteLine("\\" + "bf" + " " + "Condicion Final de Fallo" + " " + "&" + " " + c.CondicionFallo + "\\" + "\\");
                                ers.WriteLine("\\" + "hline");
                                ers.WriteLine("\\" + "bf" + " " + "Actor Primario" + "&" + " " + "Administrador" + "\\" + "\\");
                                ers.WriteLine("\\" + "hline");
                                ers.WriteLine("\\" + "bf" + " " + "Disparador" + " " + "&" + " " + c.DisparadorCasoUso + "\\" + "\\");
                                ers.WriteLine("\\" + "hline");
                                ers.WriteLine("\\" + "bf Escenario Principal de Exito &");
                                ers.WriteLine("\\" + "begin{itemize}");
                                for (int j = 0; j <= 2; j++)
                                {
                                    ers.WriteLine("\\" + "item" + " " + j + " " + "El Administrador selecciona la opción Gestión de Proyectos");
                                }
                                ers.WriteLine("\\" + "end{itemize}");
                                ers.WriteLine("\\" + "\\");
                                ers.WriteLine("\\" + "hline");
                                ers.WriteLine("\\" + "bf Extensiones &");
                                ers.WriteLine("NombreExcepcion");
                                ers.WriteLine("\\" + "begin{itemize}");
                                for (int j = 0; j <= 2; j++)
                                {
                                    ers.WriteLine("\\" + "item" + " " + j + " " + "El Administrador selecciona la opción Gestión de Proyectos");
                                }
                                ers.WriteLine("\\" + "end{itemize}");
                                ers.WriteLine("\\" + "\\");
                                ers.WriteLine("\\" + "hline");
                                ers.WriteLine("\\" + "end{tabular}");
                                ers.WriteLine("\\" + "newpage");
                            }
                            break;
                        default:
                            ers.WriteLine(linea);
                            break;
                    }
                }
                archivoBase.Close();
                ers.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Metodo para generar el documento ERS del un proyecto (archivo .pdf descargable).
        /// Excepciones posibles: 
        /// CasosDeUsoInexistentesException()
        /// RequerimientosInexistentesException()
        /// InvolucradosInexistentesException()
        /// </summary>
        /// <param name="codigo">Codigo del proyecto al que se le generara el ERS</param>
        public static void GenerarERS(String codigo)
        {
            ArchivoBase();
            GenErs(codigo);

            CompilarArchivoLatex();
        }

        /// <summary>
        /// Metodo para generar la factura del un proyecto (archivo .pdf descargable).
        /// Excepciones posibles:
        /// RequerimientosInexistentesException()
        /// InvolucradosInexistentesException()
        /// </summary>
        /// <param name="codigo">Codigo del proyecto al que se le generara la factura</param>
        public static void GenerarFactura(String codigo)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
