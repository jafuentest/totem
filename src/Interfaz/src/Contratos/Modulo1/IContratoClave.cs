namespace Contratos.Modulo1
{
    public interface IContratoClave
    {
        string Password { get; }
        string PasswordConfirmar { get; }
        void setMensaje(bool esError, string mensaje);
    }
}
