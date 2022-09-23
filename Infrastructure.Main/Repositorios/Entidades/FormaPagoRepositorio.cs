using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class FormaPagoRepositorio : BaseRepositorio<FormaPago, Guid>, IFormaPagoRepositorio
    {
        public FormaPagoRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
