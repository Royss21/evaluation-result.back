namespace Domain.Main.Autenticacion
{
    public class Rol : BaseModel<Guid>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

    }
}
