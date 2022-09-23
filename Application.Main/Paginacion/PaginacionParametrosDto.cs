
namespace Application.Main.Paginacion
{
    public class PaginacionParametrosDto<T> where T : class
    {
        public string ColumnaOrden { get; set; }
        public TipoOrdenEnum TipoOrden { get; set; }
        public int Empieza { get; set; }
        public int CantidadFilas { get; set; }
        public Expression<Func<T, bool>> FiltroWhere { get; set; }
    }
}