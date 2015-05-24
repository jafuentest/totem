using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
    interface IDocumento
    {
        public void GenerarFactura(String codigo);
        public void GenerarERS(String codigo);
    }
}
