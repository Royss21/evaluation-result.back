
namespace Domain.Main.Administrador
{
    public class Menu: BaseModeloActivo<Guid>
    {

        public Guid? MenuPadreId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Icono { get; set; } = string.Empty;
        public int Orden { get; set; }

        public Menu MenuPadre { get; set; }
    }
}