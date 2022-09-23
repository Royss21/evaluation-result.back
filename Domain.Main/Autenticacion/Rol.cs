namespace Domain.Main.Autenticacion
{
    public class Rol : BaseModelo<Guid>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

    }
}
