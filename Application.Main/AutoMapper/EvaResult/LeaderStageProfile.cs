namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.LeaderStage;
    using Domain.Main.EvaResult;

    public class LeaderStageProfile : Profile
    {
        public LeaderStageProfile()
        {
            CreateMap<LeaderStage, LeaderStageExistingDto>().ReverseMap();
        }
    }
}
