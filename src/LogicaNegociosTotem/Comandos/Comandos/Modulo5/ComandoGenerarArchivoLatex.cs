using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace Comandos.Comandos.Modulo5
{   
    /// <summary>
    /// Clase para generar Archivo Latex de lo requerimientos
    /// de un proyecto
    /// </summary>
    public class ComandoGenerarArchivoLatex : Comando<String,
        Boolean>
    {
        /// <summary>
        /// Metodo para generar archivo latex
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public override bool Ejecutar(string parametro)
        {

            try
            {
                DAO.IntefazDAO.Modulo5.IDaoRequerimiento daoRequerimiento;
                DAO.Fabrica.FabricaDAOSqlServer fabricaDao = new DAO.Fabrica.FabricaDAOSqlServer();
                daoRequerimiento = fabricaDao.ObtenerDAORequerimiento();
                List<Dominio.Entidad> requerimientos;
                requerimientos = daoRequerimiento.ConsultarRequerimientoDeProyecto(parametro);
                this.GenerarDocumentoFuncional(requerimientos);
                this.CompilarArchivo();
                return true;
            }
            catch (ExcepcionesTotem.Modulo5.ArchivoLatexNoGeneradoException ex) {
                throw ex;
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {

                throw ex;
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Metodo encargado de generar archivo latex con los 
        /// requerimientos funcionales y no funcionales;
        /// </summary>
        /// <param name="requerimientos"></param>
        public void GenerarDocumentoFuncional(List<Dominio.Entidad>requerimientos) {
            try
            {
                string linea;
                System.IO.StreamReader archivoBase; 
                archivoBase=new System.IO.StreamReader(RecursosMod5Comando.ArchivoBase);
                System.IO.StreamWriter reqdoc = new System.IO.StreamWriter(RecursosMod5Comando.ArchivoFinal);
                while ((linea = archivoBase.ReadLine()) != null)
                {
                    switch (linea)
                    {

                        case "fecha":
                            DateTime auxiliar = DateTime.Today;
                            string fecha = auxiliar.ToShortDateString();
                            reqdoc.WriteLine(fecha);
                            break;

                        case "Funcionales":
                            reqdoc.WriteLine("\\" + "begin{tabular}{| l | p{7cm} | r |}");
                            reqdoc.WriteLine("\\" + "hline");
                            reqdoc.WriteLine("\\" + "bf ID & " + "\\" + "bf Requerimiento &" + " \\" + "bf Prioridad " + "\\" + "\\");
                            reqdoc.WriteLine("\\" + "hline");
                            foreach (Dominio.Entidades.Modulo5.Requerimiento rf in requerimientos)
                            {
                                if (rf.Tipo.Equals("funcional"))
                                {
                                    reqdoc.WriteLine(
                                          rf.Codigo.Replace("_", "-") + "&"
                                        + rf.Descripcion + "&"
                                        + rf.Prioridad + " " + "\\" + "\\");

                                    reqdoc.WriteLine("\\" + "hline");
                                }
                            }
                            reqdoc.WriteLine("\\" + "end{tabular}");
                            break;
                        case "NFuncionales":
                            reqdoc.WriteLine("\\" + "begin{tabular}{| l | p{7cm} | r |}");
                            reqdoc.WriteLine("\\" + "hline");
                            reqdoc.WriteLine("\\" + "bf ID & " + "\\" + "bf Requerimiento &" + " \\" + "bf Prioridad " + "\\" + "\\");
                            reqdoc.WriteLine("\\" + "hline");
                            foreach (Dominio.Entidades.Modulo5.Requerimiento rf in requerimientos)
                            {
                                if (!(rf.Tipo.Equals("funcional")))
                                {
                                    reqdoc.WriteLine(
                                          rf.Codigo.Replace("_", "-") + "&"
                                        + rf.Descripcion + "&"
                                        + rf.Prioridad + " " + "\\" + "\\");

                                    reqdoc.WriteLine("\\" + "hline");
                                }
                            }
                            reqdoc.WriteLine("\\" + "end{tabular}");
                            break;
                        default:
                            reqdoc.WriteLine(linea);
                            break;
                    }
                }
                archivoBase.Close();
                reqdoc.Close();
            }
            catch (System.IO.DirectoryNotFoundException) {

                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()),
                    new ExcepcionesTotem.Modulo5.ArchivoInexistenteException());

                throw new ExcepcionesTotem.Modulo5.ArchivoInexistenteException(
                    RecursosMod5Comando.codigo_excepcion_archivo_no_encontrado,
                            RecursosMod5Comando.Mensaje_Error_Archivo_Inexistente,
                            new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());

            
            }
            catch(ExcepcionesTotem.ExceptionTotem err){
                throw err;
            }
        
        
           
        }


        public void CompilarArchivo() {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = RecursosMod5Comando.CompiladorLatex;
                string argumento = RecursosMod5Comando.ParametroLatex + " " + RecursosMod5Comando.Directorio;
                p.StartInfo.Arguments = argumento + " " + RecursosMod5Comando.ArchivoFinal;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.UseShellExecute = false;
                p.Start();
                System.Threading.Thread.Sleep(1000);
                p.Dispose();
            }
            catch (Win32Exception winerr) {
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()),
                 new ExcepcionesTotem.Modulo5.ArchivoLatexNoGeneradoException());

                throw new ExcepcionesTotem.Modulo5.ArchivoLatexNoGeneradoException(
                    RecursosMod5Comando.codigo_excepcion_archivo_latex_no_compilado,
                            RecursosMod5Comando.Mensaje_Error_Archivo_NoCompilado,
                            new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());


            }
            catch (SystemException syserr) {
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()),
                     new ExcepcionesTotem.Modulo5.ArchivoLatexNoGeneradoException());

                throw new ExcepcionesTotem.Modulo5.ArchivoLatexNoGeneradoException(
                    RecursosMod5Comando.codigo_excepcion_archivo_latex_no_compilado,
                            RecursosMod5Comando.Mensaje_Error_Archivo_NoCompilado,
                            new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());

            }


        }
    }
}
