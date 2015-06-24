namespace Contratos.Modulo1
{
    /// <summary>
    /// Firma de los métodos de la vista Login
    /// </summary>
    public interface IContratoLogin
    {
        string Usuario { get; }
        string Clave { get; }
        void SetMesaje(bool esError, string mensaje);
    }
}
