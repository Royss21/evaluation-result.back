﻿
namespace Application.Dto.Config.HierarchyComponent
{
    using System.Text.Json.Serialization;
    public class HierarchyComponentPagingDto
    {
        public string HierarchyName { get; set; } = string.Empty;
        public List<HierarchyComponentDto> HierarchyComponents { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }

    }
}
