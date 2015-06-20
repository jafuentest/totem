using Contratos.Modulo1;

namespace Presentadores.Modulo1
{
    public class PresentadorPregunta
    {
        private IContratoPregunta vista;

        public PresentadorPregunta(IContratoPregunta laVista)
        {
            vista = laVista;
        }


    }
}
