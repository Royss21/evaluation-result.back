namespace Application.Dto.Paginacion
{
    public class PaginationReportDto
    {

        public int Primero { get; set; }
        public int Filas { get; set; }
        public string ColumnaOrden { get; set; } = string.Empty;
        public int TipoOrden { get; set; }
    }
}