namespace Application.Main.Excepciones
{
    public class ValidadorExcepcion : Exception
    {
        public ValidadorExcepcion(string message) : base(message)
        {
        }
    }
}
