using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class DocumentoIdentidadRepositorio : BaseRepositorio<DocumentoIdentidad, int>, IDocumentoIdentidadRepositorio
    {
        public DocumentoIdentidadRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
