
namespace Application.Main.AutoMapper.Report
{
    using Application.Dto.Report;
    using Domain.Common.Constants;
    using Domain.Main.EvaResult;
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<EvaluationCollaborator, EvaluationCollaboratorFinalResultDto>()
                .ForMember(x => x.CollaboratorName, m => m.MapFrom(d => $"{d.Collaborator.Name} {d.Collaborator.LastName} {d.Collaborator.MiddleName}"))
                .ForMember(x => x.DocumentNumber, m => m.MapFrom(d => d.Collaborator.DocumentNumber))
                .ForMember(x => x.AreaName, m => m.MapFrom(d => d.Collaborator.Charge.Area.Name))
                .ForMember(x => x.ChargeName, m => m.MapFrom(d => d.Collaborator.Charge.Name))
                .ForMember(x => x.GerencyName, m => m.MapFrom(d => d.Collaborator.Charge.Area.Gerency.Name))
                .ForMember(x => x.HierarchyName, m => m.MapFrom(d => d.Collaborator.Charge.Hierarchy.Name))
                .ForMember(x => x.LevelName, m => m.MapFrom(d => d.Collaborator.Charge.Hierarchy.Level.Name))
                .ForMember(x => x.EvaluationId, m => m.MapFrom(d => d.EvaluationId))
                .ForMember(x => x.FinalResult, m => m.MapFrom(d => d.ComponentsCollaborator.Sum( s=> GeneralConstants.Component.Competencies == s.EvaluationComponent.ComponentId ? s.TotalCalibrated : s.Total)));



            CreateMap<EvaluationCollaborator, EvaluationCollaboratorarFollowResultDto>()
                .ForMember(x => x.CollaboratorName, m => m.MapFrom(d => $"{d.Collaborator.Name} {d.Collaborator.LastName} {d.Collaborator.MiddleName}"))
                .ForMember(x => x.DocumentNumber, m => m.MapFrom(d => d.Collaborator.DocumentNumber))
                .ForMember(x => x.AreaName, m => m.MapFrom(d => d.Collaborator.Charge.Area.Name))
                .ForMember(x => x.EvaluationCollaboratorId, m => m.MapFrom(d => d.Id))
                .ForMember(x => x.ChargeName, m => m.MapFrom(d => d.Collaborator.Charge.Name))
                .ForMember(x => x.GerencyName, m => m.MapFrom(d => d.Collaborator.Charge.Area.Gerency.Name))
                .ForMember(x => x.HierarchyName, m => m.MapFrom(d => d.Collaborator.Charge.Hierarchy.Name))
                .ForMember(x => x.LevelName, m => m.MapFrom(d => d.Collaborator.Charge.Hierarchy.Level.Name))
                .ForMember(x => x.EvaluationId, m => m.MapFrom(d => d.EvaluationId));
        }
    }
}
