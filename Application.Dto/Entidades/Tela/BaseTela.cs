namespace Application.Dto.Entidades.Tela
{
    public abstract class BaseTela
    {
        public string Nombre { get; set; } = string.Empty;
        public bool EsTematica { get; set; }
    }
}
