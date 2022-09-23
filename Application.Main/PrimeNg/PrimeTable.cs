using System.Collections.Generic;

namespace Application.Main.PrimeNg
{
    public class PrimeTable
    {
        /// <summary>
        /// Primera fila
        /// </summary>
        public int Empieza { get; set; } = 1;

        /// <summary>
        /// Número de filas por página
        /// </summary>
        public int Filas { get; set; } = 10;

        /// <summary>
        /// Nombre de campo para ordenar
        /// </summary>
        public string? ColumnaOrden { get; set; }=  "FechaCrea";

        /// <summary>
        /// Tipo de ordenamiento: 1 => Asc, -1 => Desc
        /// </summary>
        public int? TipoOrden { get; set; } = (int)TipoOrdenEnum.Descendente;

        /// <summary>
        /// Filtra el objeto que tiene el campo como clave y el valor del filtro
        /// </summary>
        public Dictionary<string, PrimeFilter>? Filtros { get; set; }

        /// <summary>
        /// Valor del filtro global si está disponible
        /// </summary>
        public string? FiltroGlobal { get; set; } = string.Empty;
    }
}