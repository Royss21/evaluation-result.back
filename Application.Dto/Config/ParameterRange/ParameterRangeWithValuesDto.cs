﻿
namespace Application.Dto.Config.ParameterRange
{
    using Application.Dto.Config.ParameterValue;
    public class ParameterRangeWithValuesDto : BaseParameterRangeDto
    {
        public Guid Id { get; set; }
        public List<ParameterValueDto> ParametersValue { get; set; }
    }
}
