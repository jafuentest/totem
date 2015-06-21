namespace Contratos.Modulo1
{
    public interface IContratoPregunta
    {
        string Pregunta { set; }
        string Respuesta { get; }
        void setMensaje(bool esError, string mensaje);
    }
}
