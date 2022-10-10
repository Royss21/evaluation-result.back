using System.Collections.Generic;

namespace Application.Main.PrimeNg
{
    public class PrimeTable
    {
        /// <summary>
        /// Primera fila
        /// </summary>
        public int Start { get; set; } = 1;

        /// <summary>
        /// Número de filas por página
        /// </summary>
        public int Rows { get; set; } = 10;

        /// <summary>
        /// Nombre de campo para ordenar
        /// </summary>
        public string? OrderColumn { get; set; }= "CreateDate";

        /// <summary>
        /// Tipo de ordenamiento: 1 => Asc, -1 => Desc
        /// </summary>
        public int? SortType { get; set; } = (int)SortTypeEnum.Desc;

        /// <summary>
        /// Filtra el objeto que tiene el campo como clave y el valor del filtro
        /// </summary>
        public Dictionary<string, PrimeFilter>? Filters { get; set; }

        /// <summary>
        /// Valor del filtro global si está disponible
        /// </summary>
        public string? GlobalFilter { get; set; } = string.Empty;
    }
}