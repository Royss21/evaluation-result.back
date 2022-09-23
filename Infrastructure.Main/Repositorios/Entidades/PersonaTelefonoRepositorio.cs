using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class PersonaTelefonoRepositorio : BaseRepositorio<PersonaTelefono, Guid>, IPersonaTelefonoRepositorio
    {
        public PersonaTelefonoRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
