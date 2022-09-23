
namespace Application.Dto.Entidades.Tela
{
    using Application.Dto.Entidades.TelaColor;
    public class TelaCrearDto : BaseTela
    {
        public List<TelaColorCrearDto> TelaColores { get; set; }
    }
}
