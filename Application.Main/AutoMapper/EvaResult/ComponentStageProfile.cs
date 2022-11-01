namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.ComponentStage;
    using Domain.Main.EvaResult;

    public class ComponentStageProfile : Profile
    {
        public ComponentStageProfile()
        {
            CreateMap<ComponentStageDto, ComponentStage>().ReverseMap();
            CreateMap<ComponentStageCreateDto, ComponentStage>().ReverseMap();
        }
    }
}
