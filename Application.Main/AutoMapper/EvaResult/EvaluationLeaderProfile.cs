namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.EvaluationLeader;
    using Application.Dto.EvaResult.LeaderCollaborator;
    using Application.Dto.EvaResult.LeaderStage;
    using Domain.Main.EvaResult;

    public class EvaluationLeaderProfile : Profile
    {
        public EvaluationLeaderProfile()
        {
            CreateMap<EvaluationLeader, EvaluationLeaderExistingDto>()
                .ForMember(x => x.CollaboratorId, m => m.MapFrom(d => d.EvaluationCollaborator.CollaboratorId))
                .ForMember(x => x.DocumentNumber, m => m.MapFrom(d => d.EvaluationCollaborator.Collaborator.DocumentNumber))
                .ForMember(x => x.LeaderStagesExistingDto, m => m.MapFrom(d => d.LeaderStages.Select(ls => new LeaderStageExistingDto
                {
                    StageId = ls.StageId,
                    EvaluationLeaderId = ls.EvaluationLeaderId,
                    LeaderCollaboratorsExistingDto = ls.LeaderCollaborators.Select(lc => new LeaderCollaboratorExistingDto
                    {
                        DocumentNumber = lc.EvaluationCollaborator.Collaborator.DocumentNumber,
                        EvaluationCollaboratorId = lc.EvaluationCollaboratorId,
                        LeaderStageId = lc.LeaderStageId
                    }).ToList()
                })));
        }
    }
}
