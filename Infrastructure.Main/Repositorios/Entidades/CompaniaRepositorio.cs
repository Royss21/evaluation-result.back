using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class CompaniaRepositorio : BaseRepositorio<Compania, Guid>, ICompaniaRepositorio
    {
        public CompaniaRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
