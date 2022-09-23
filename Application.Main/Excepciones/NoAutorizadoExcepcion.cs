namespace Application.Main.Excepciones
{
    public class NoAutorizadoExcepcion : Exception
    {
        public NoAutorizadoExcepcion(string message) : base(message)
        {
        }
    }
}
