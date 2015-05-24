using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
    public interface IDocumento
    {
        void GenerarFactura(String codigo);
        void GenerarERS(String codigo);
    }
}
