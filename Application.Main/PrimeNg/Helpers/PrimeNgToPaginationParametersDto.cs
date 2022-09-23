

namespace Application.Main.PrimeNg.Helpers
{
    public class PrimeNgToPaginationParametersDto<TDto> where TDto : class
    {
        public static PaginacionParametrosDto<TDto> Convert(PrimeTable primeTable)
        {
            var filter = new List<ColumnsFilter>();

            if (primeTable.Filtros != null)
            {
                filter = primeTable.Filtros
                    .Where(p => !string.IsNullOrWhiteSpace(p.Value.Value) && p.Key != "global")
                    .Select(p => new ColumnsFilter
                    {
                        Field = p.Key,
                        Value = p.Value.Value.Trim(),
                        Operator = p.Value.MatchMode
                    }).ToList();
            }

            var filterParameterDto = new PaginacionParametrosDto<TDto>
            {
                Empieza = primeTable.Empieza,
                CantidadFilas = primeTable.Filas,
                ColumnaOrden = primeTable.ColumnaOrden,
                TipoOrden = (TipoOrdenEnum)primeTable.TipoOrden,
                FiltroWhere = filter.Any() ? LambdaManager.ConvertToLambda<TDto>(filter) : null
            };

            return filterParameterDto;
        }
    }
}