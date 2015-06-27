using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo8
{
    public class ComandoCompilarLatex : Comando<String, bool>
    {
        /// <summary>
        /// Metodo que compila un archivo .tex
        /// </summary>
        /// <param name="parametro">nombre del archivo a compilar</param>
        /// <returns>retorna verdadero luego de compilar el archivo</returns>
        public override bool Ejecutar(String parametro)
        {
            try
            {
                if (System.IO.File.Exists(RecursosComandosModulo8.Parametro))
                {

                    System.IO.File.Delete(RecursosComandosModulo8.Parametro);
                }

                Process p1 = new Process();
                p1.StartInfo.FileName = RecursosComandosModulo8.CompiladorLatex;
                string argumento = RecursosComandosModulo8.ParametroLatex + " " + RecursosComandosModulo8.Directorio;
                p1.StartInfo.Arguments = argumento+" "+parametro;
                p1.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                p1.StartInfo.RedirectStandardOutput = true;
                p1.StartInfo.UseShellExecute = false;
                p1.Start();
                System.Threading.Thread.Sleep(1000);
                p1.Dispose();
                
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

      


    }
}
