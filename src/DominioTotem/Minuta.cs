using System;
using System.Collections.Generic;

namespace DominioTotem
{
    public class Minuta
    {
        public string codigo { get; set; }
        public DateTime fecha { get; set; }
        public string motivo { get; set; }
        public IEnumerable<Punto> listaPunto { get; set; }
        public IEnumerable<Acuerdo> listaAcuerdo { get; set; }
    }
}