using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Comandos
{
    public abstract class Comando
    {
        private Entidad entrada;
        private Entidad salida;



        public Entidad Entrada
        {
            get { return entrada; }
            set { entrada = value; }
        }

        public Entidad Salida
        {
            get { return salida; }
            set { salida = value; }
        }


        public abstract void Ejecutar();
    }
}
