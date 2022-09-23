using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class OperadoraTelefonoRepositorio : BaseRepositorio<OperadoraTelefono, int>, IOperadoraTelefonoRepositorio
    {
        public OperadoraTelefonoRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
