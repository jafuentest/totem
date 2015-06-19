namespace Contratos.Modulo1
{
    public interface IContratoLogin
    {
        string Usuario { get; }
        string Clave { get; }
        string Mensaje { set; }
    }
}
