
namespace Infrastructure.Main.Repositorios.Entidades
{
    using Infrastructure.Main.Repositorios.Entidades.Interfaces;
    public class TelaColorRepositorio : BaseRepositorio<TelaColor, int>, ITelaColorRepositorio
    {
        public TelaColorRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
