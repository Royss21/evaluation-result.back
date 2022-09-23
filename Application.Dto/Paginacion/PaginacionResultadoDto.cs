using System.Collections.Generic;

namespace Application.Dto.Paginacion
{
    public class PaginacionResultadoDto<T> where T : class
    {
        public int Cantidad { get; set; }

        public IEnumerable<T> Entidades { get; set; }
    }
}