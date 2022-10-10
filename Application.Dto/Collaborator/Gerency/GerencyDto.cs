﻿
namespace Application.Dto.Employee.Gerency
{
    using System.Text.Json.Serialization;
    public class GerencyDto : BaseGerencyDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTimeOffset CreateDate { get; set; }
    }
}
