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
        public static bool CrearProyectoClienteJuridico(DominioTotem.Proyecto proyecto, String id)
        {

            try
            {
                return DatosTotem.Modulo4.BDProyecto.CrearProyectoClienteJuridico(proyecto, id);
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
        public static bool CrearProyectoClienteNatural(DominioTotem.Proyecto proyecto, String id)
        {

            try
            {
                return DatosTotem.Modulo4.BDProyecto.CrearProyectoClieteNatural(proyecto, id);
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
                return null;
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


        static void CompilarArchivoLatex(string path)
        {
            Process p1 = new Process();
            p1.StartInfo.FileName = "pdflatex.exe";
            p1.StartInfo.Arguments = path;
            p1.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p1.StartInfo.RedirectStandardOutput = true;
            p1.StartInfo.UseShellExecute = false;
            try
            {
                p1.Start();
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

        static void BaseErs()
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

        static void BaseFactura()
        {
            try
            {
                EliminarArchivo(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\GUI\Modulo4\docs\BaseFactura.tex");
                EliminarArchivo("BaseFactura.pdf");
                System.IO.StreamWriter factura = new System.IO.StreamWriter(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\GUI\Modulo4\docs\BaseFactura.tex");
                factura.WriteLine("\\" + "documentclass{article}");
                factura.WriteLine("\\" + "usepackage[utf8]{inputenc}");
                factura.WriteLine("\\" + "usepackage{anysize}");
                factura.WriteLine("\\" + "marginsize{1cm}{1cm}{1cm}{1cm}");
                factura.WriteLine("\\" + "begin{document}");
                factura.WriteLine(" ");
                factura.WriteLine("\\" + "begin{flushright}");
                factura.WriteLine("\\" + "Large Fecha de emisión:");
                factura.WriteLine("\\" + "bf");
                factura.WriteLine("fecha");
                factura.WriteLine("\\" + "end{flushright}");
                factura.WriteLine(" ");
                factura.WriteLine("\\" + "begin{flushleft}");
                factura.WriteLine(" ");
                factura.WriteLine("\\" + "begin{tabular}{|p{19 cm}|}");
                factura.WriteLine(" ");
                factura.WriteLine("\\" + "hline");
                factura.WriteLine(" ");
                factura.WriteLine("\\" + "begin{center}");
                factura.WriteLine("\\" + "Large" + "\\" + "bf Datos Cliente");
                factura.WriteLine("\\" + "end{center}");
                factura.WriteLine(" ");
                factura.WriteLine("\\" + "begin{flushleft}");
                factura.WriteLine("\\" + "Large  Razon Social: ");
                factura.WriteLine("razon");
                factura.WriteLine("\\" + "\\");
                factura.WriteLine("\\" + "Large  ID: ");
                factura.WriteLine("id");
                factura.WriteLine("\\" + "\\");
                factura.WriteLine("\\" + "Large Direccion:");
                factura.WriteLine("direccion");
                factura.WriteLine("\\" + "\\");
                factura.WriteLine("\\" + "Large Telefono: ");
                factura.WriteLine("telefono");
                factura.WriteLine("\\" + "\\");
                factura.WriteLine("\\" + "end{flushleft}");
                factura.WriteLine("\\" + "\\");
                factura.WriteLine("\\" + "hline");
                factura.WriteLine(" ");
                factura.WriteLine(" ");
                factura.WriteLine("\\" + "end{tabular}");
                factura.WriteLine("\\" + "linebreak[5]");
                factura.WriteLine("\\" + "newline");
                factura.WriteLine(" ");
                factura.WriteLine(" ");
                factura.WriteLine("\\" + "begin{tabular}{|p{14 cm}|p{4.6 cm}|}");
                factura.WriteLine(" ");
                factura.WriteLine("\\" + "hline");
                factura.WriteLine(" ");
                factura.WriteLine("\\" + "Large" + "\\" + "bf" + " " + "Requerimiento" + " " + "&" + " " + "\\" + "Large" + "\\" + "bf Precio" + "\\" + "\\");
                factura.WriteLine("\\" + "hline");
                factura.WriteLine("requerimiento & monto");
                factura.WriteLine("\\" + "\\");
                factura.WriteLine("\\" + "hline");
                factura.WriteLine("\\" + "end{tabular}");
                factura.WriteLine(" ");
                factura.WriteLine(" ");
                factura.WriteLine("\\" + "begin{tabbing}");
                factura.WriteLine("\\" + "hspace*{9cm}" + "\\" + "=" + "\\" + "hspace*{5cm}" + "\\" + "=" + "\\" + "hspace*{6cm}" + "\\" + "kill");
                factura.WriteLine("\\" + "Large" + "\\" + "bf Subtotal:");
                factura.WriteLine("subtotal");
                factura.WriteLine("\\" + ">" + "\\" + "Large" + "\\" + "bf Iva:");
                factura.WriteLine("iva");
                factura.WriteLine("\\" + ">" + "\\" + "Large" + "\\" + "bf Total: ");
                factura.WriteLine("total");
                factura.WriteLine("\\" + "\\");
                factura.WriteLine("\\" + "end{tabbing}");
                factura.WriteLine(" ");
                factura.WriteLine("\\" + "begin{tabbing}");
                factura.WriteLine("\\" + "newline");
                factura.WriteLine("\\" + "hspace*{13cm}" + "\\" + "=" + "\\" + "hspace*{1cm}" + "\\" + "kill");
                factura.WriteLine("\\" + "Large" + " " + "\\" + "bf Firma Receptor");
                factura.WriteLine("\\" + ">" + "\\" + "Large " + "\\" + "bf Firma Presidente");
                factura.WriteLine("\\" + "end{tabbing}");
                factura.WriteLine("\\" + "end{flushleft}");
                factura.WriteLine("\\" + "end{document}");

                factura.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void EnsambleFactura(List<Requerimiento> reqs, double costoRequerimiento, double total, double subtotal, double iva)
        {
            try
            {
                string linea;
                System.IO.StreamReader archivoBase = new System.IO.StreamReader(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\GUI\Modulo4\docs\BaseFactura.tex");
                System.IO.StreamWriter factura = new System.IO.StreamWriter(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\GUI\Modulo4\docs\factura.tex");
                while ((linea = archivoBase.ReadLine()) != null)
                {
                    switch (linea)
                    {
                        case "fecha":
                            DateTime auxiliar = DateTime.Today;
                            string fecha = auxiliar.ToShortDateString();
                            factura.WriteLine(fecha);
                            break;
                        case "requerimiento & monto":
                            foreach (Requerimiento rf in reqs)
                            {
                                factura.WriteLine(rf.Descripcion + "&" + costoRequerimiento + " " + "\\" + "\\");
                                factura.WriteLine("\\" + "hline");
                            }
                            break;
                        case "subtotal":
                            factura.WriteLine(subtotal);
                            break;
                        case "iva":
                            factura.WriteLine(iva);
                            break;
                        case "total":
                            factura.WriteLine(total);
                            break;
                        default:
                            factura.WriteLine(linea);
                            break;
                    }
                    
                }
                archivoBase.Close();
                factura.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
  
            
        }

        public static void EnsambleErs(Proyecto proyecto, List<Usuario> involucrados, List<Requerimiento> reqFuncionales, List<Requerimiento> reqNoFuncionales, List<CasoDeUso> casosDeUso)
        {
            try
            {
            string linea;
            System.IO.StreamReader archivoBase = new System.IO.StreamReader(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\GUI\Modulo4\docs\BaseErs.tex");
                System.IO.StreamWriter ers = new System.IO.StreamWriter(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\GUI\Modulo4\docs\ers.tex");
                while ((linea = archivoBase.ReadLine()) != null)
                {
                    switch (linea)
                    {
                        case ("titulo"):
                            ers.WriteLine("Especificacion de Requerimientos De Software");
                            break;
                        case "fecha":
                            DateTime auxiliar = DateTime.Today;
                            string fecha = auxiliar.ToShortDateString();
                            ers.WriteLine(fecha);
                            break;
                        case "autor":
                            ers.WriteLine("Autor");
                            break;

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
                            break;
                        case "casosDeUso":
                            foreach (CasoDeUso c in casosDeUso)
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
        /// 

        public static void GenFactura(String codigo)
        {

            EliminarArchivo(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\GUI\Modulo4\docs\factura.tex");
            EliminarArchivo(@"C:\Program Files (x86)\IIS Express\factura.pdf");
            try
            {
                int[] progreso = CalcularProgreso(codigo);
                Proyecto proyecto = LogicaNegociosTotem.Modulo4.LogicaProyecto.ConsultarProyecto(codigo);
                int costo = proyecto.Costo;
                int totalRequerimientos = progreso[0];
                int totalFinalizados = progreso[1];
                double precioRequerimiento = costo / totalRequerimientos;
                double subtotal = precioRequerimiento * totalFinalizados;
                double iva = ((0.12 * subtotal));
                double total = subtotal + iva;

                List<Requerimiento> rF = DatosTotem.Modulo5.BDRequerimiento.ConsultarRequerimientosPorProyecto(1);
                LogicaNegociosTotem.Modulo4.LogicaProyecto.EnsambleFactura(rF, precioRequerimiento, total, subtotal, iva);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }

        public static void GenErs(String codigo)
        {
            
            EliminarArchivo(@"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\GUI\Modulo4\docs\ers.tex");
            EliminarArchivo(@"C:\Program Files (x86)\IIS Express\ers.pdf");
            try
            {
                Proyecto proyecto = LogicaNegociosTotem.Modulo4.LogicaProyecto.ConsultarProyecto(codigo);
                ListaInvolucradoUsuario involucrados = new ListaInvolucradoUsuario();
                LogicaNegociosTotem.Modulo3.LogicaInvolucrados logInv = new LogicaNegociosTotem.Modulo3.LogicaInvolucrados(proyecto);
                involucrados = logInv.obtenerUsuariosInvolucradosProyecto(proyecto);
                LogicaNegociosTotem.Modulo6.LogicaCasoUso cu = new Modulo6.LogicaCasoUso();
                List<Requerimiento> rF = DatosTotem.Modulo5.BDRequerimiento.ConsultarRequerimientosPorProyecto(1);
                List<Requerimiento> rNF= DatosTotem.Modulo5.BDRequerimiento.ConsultarRequerimientosPorProyecto(1);
                //Cable por Fuentes
				List<CasoDeUso> listaCU = cu.ListarCasosDeUso(1);
				//Fin del cable
                LogicaNegociosTotem.Modulo4.LogicaProyecto.EnsambleErs(proyecto, involucrados.Lista, rF, rNF, listaCU);
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
            string path = @"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\GUI\Modulo4\docs\ers.tex";
            BaseErs();
            GenErs(codigo);

            CompilarArchivoLatex(path);
            CompilarArchivoLatex(path);
            CompilarArchivoLatex(path);

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
            string path = @"C:\Users\MiguelAngel\Documents\GitHub\totem\src\Interfaz\src\GUI\Modulo4\docs\factura.tex"; 
            BaseFactura();
            GenFactura(codigo);
            CompilarArchivoLatex(path);

        }
        #endregion

        #region Contrar Requerimientos
        public static int ContarRequerimientos(String codigo)
        {
            try
            {
                return DatosTotem.Modulo4.BDProyecto.ContarRequerimientosProyecto(codigo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int ContarRequerimientosFinalizados(String codigo)
        {
            try
            {
                return DatosTotem.Modulo4.BDProyecto.ContarRequerimientosFinalizadosProyecto(codigo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int[] CalcularProgreso(String codigo)
        {
            try
            {
                int requrimientosTotales = ContarRequerimientos(codigo);
                int requerimientosFinalizados = ContarRequerimientosFinalizados(codigo);
                int progreso = (requerimientosFinalizados * 100) / requrimientosTotales;
                int[] progresoTotal = new int[3];
                progresoTotal[0] = requrimientosTotales;
                progresoTotal[1] = requerimientosFinalizados;
                progresoTotal[2] = progreso;
                return progresoTotal;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
        #endregion

        #region Buscar Proyectos
        public static DataTable BuscarProyectos(String busqueda)
        {
            try
            {
                return DatosTotem.Modulo4.BDProyecto.BuscarProyectos(busqueda);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static DataTable BuscarProyectosActivos(String busqueda)
        {
            try
            {
                return DatosTotem.Modulo4.BDProyecto.BuscarProyectosActivos(busqueda);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static DataTable BuscarProyectosInactivos(String busqueda)
        {
            try
            {
                return DatosTotem.Modulo4.BDProyecto.BuscarProyectosInactivos(busqueda);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #endregion

        #region Buscar Clientes

        public static DataTable BuscarClientesNaturales()
        {
            try
            {
                return DatosTotem.Modulo4.BDProyecto.ConsultarTodoslosClienteNaturales();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static DataTable BuscarClientesJuridicos()
        {
            try
            {
                return DatosTotem.Modulo4.BDProyecto.ConsultarTodoslosClienteJuridicos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int ObtenerIDClienteNatural(string cedula)
        {
            try
            {
                return DatosTotem.Modulo4.BDProyecto.ObtenerIdClienteNatural(cedula);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int ObtenerIDClienteJuridico(string rif)
        {
            try
            {
                return DatosTotem.Modulo4.BDProyecto.ObtenerIdClienteJuridico(rif);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #endregion
    }
}
