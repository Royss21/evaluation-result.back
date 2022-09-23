namespace Application.Main.Excepciones
{
    public class ProhibidoExcepcion : Exception
    {
        public ProhibidoExcepcion(string message) : base(message)
        {
        }
    }
}
