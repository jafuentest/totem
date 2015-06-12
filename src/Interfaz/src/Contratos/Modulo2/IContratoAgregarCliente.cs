using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo2
{
    public interface IContratoAgregarCliente
    {
        string nombreNatural{ get; set; }
        string apellidoNatural{ get; set; }
        string comboRSocial{ get; set; }
        string cedulaNatural{ get; set; }
        string comboPais{ get; set; }
        string comboEstado{ get; set; }
        string comboCiudad{ get; set; }
        string direccionCliente{ get; set; }
        string codigoPostalCliente{ get; set; }
        string correoCliente{ get; set; }
        string codTelefono{ get; set; }
        string telefonoCliente{ get; set; }

    }
}
