namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.LeaderCollaborator;
    using Domain.Main.EvaResult;

    public class LeaderCollaboratorProfile : Profile
    {
        public LeaderCollaboratorProfile()
        {
            CreateMap<LeaderCollaborator, LeaderCollaboratorExistingDto>().ReverseMap();
        }
    }
}
