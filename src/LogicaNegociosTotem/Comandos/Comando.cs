using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Comandos
{
    public abstract class Comando<Parametro, Resultado>
    {

        public abstract Resultado Ejecutar(Parametro parametro);
    }
}
