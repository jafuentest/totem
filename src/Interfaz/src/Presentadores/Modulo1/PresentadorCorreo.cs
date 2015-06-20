using System;
using Contratos.Modulo1;
using Dominio;
using Dominio.Fabrica;

namespace Presentadores.Modulo1
{
    
    public class PresentadorCorreo
    {
        private IContratoCorreo vista;

        public PresentadorCorreo(IContratoCorreo laVista)
        {
            vista = laVista;
        }

        public void ManejarEventoCorreo_Click()
        {
            string correo = vista.Correo;

            if (correo.Equals(""))
            {
                vista.Mensaje = "Debe Ingresar un Correo";
            }
            else
            {
                try
                {
                    Entidad usuario = FabricaEntidades.ObtenerUsuario(null, null, null, null, null, correo, null, null, null);
                    vista.Mensaje = "Se ha mandado un mensaje de confirmación al correo";

                }
                catch (Exception)
                {
                    vista.Mensaje = "El correo suministrado es erroneo o no se encuentra registrado";
                }

            }
        }

    }
}
