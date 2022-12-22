namespace Application.Main.AutoMapper.EvaResult
{
    using Application.Dto.EvaResult.Evaluation;
    using Domain.Common.Constants;
    using Domain.Main.EvaResult;

    public class EvaluationProfile : Profile
    {
        public EvaluationProfile()
        {
            CreateMap<EvaluationDto, Evaluation>().ReverseMap();
            CreateMap<EvaluationCreateDto, Evaluation>().ReverseMap();

            CreateMap<Evaluation, EvaluationCurrentDto>()
               .ForMember(x => x.HasComponentCorporateObjectives, m => m.MapFrom(d => d.EvaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.CorporateObjectives)))
               .ForMember(x => x.HasComponentAreaObjectives, m => m.MapFrom(d => d.EvaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.AreaObjectives)))
               .ForMember(x => x.HasComponentCompetencies, m => m.MapFrom(d => d.EvaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.Competencies)))
               .ForMember(x => x.Name, m => m.MapFrom(d => d.Name))
               .ForMember(x => x.RangeDate, m => m.MapFrom(d => "Desde " + $"{d.StartDate.ToString("dd [P1] MMMMM, yyyy")} hasta {d.EndDate.ToString("dd [P1] MMMMM, yyyy")}".Replace("[P1]", "de")));


            CreateMap<Evaluation, EvaluationCurrentDetailDto>()
               .ForPath(x => x.EvaluationCurrent.HasComponentCorporateObjectives, m => m.MapFrom(d => d.EvaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.CorporateObjectives)))
               .ForPath(x => x.EvaluationCurrent.HasComponentAreaObjectives, m => m.MapFrom(d => d.EvaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.AreaObjectives)))
               .ForPath(x => x.EvaluationCurrent.HasComponentCompetencies, m => m.MapFrom(d => d.EvaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.Competencies)))
               .ForPath(x => x.EvaluationCurrent.Name, m => m.MapFrom(d => d.Name))
               .ForPath(x => x.EvaluationCurrent.Id, m => m.MapFrom(d => d.Id))
               .ForPath(x => x.EvaluationCurrent.RangeDate, m => m.MapFrom(d => "Desde " + $"{d.StartDate.ToString("dd [P1] MMMMM, yyyy")} hasta {d.EndDate.ToString("dd [P1] MMMMM, yyyy")}".Replace("[P1]", "de")))
               .ForMember(x => x.PeriodName, m => m.MapFrom(d => d.Period.Name))
               .ForMember(x => x.PeriodId, m => m.MapFrom(d => d.Period.Id))
               .ForMember(x => x.IsEnableImportLeaders, m => m.MapFrom(d => d.EvaluationComponents.Any(a => new[] { GeneralConstants.Component.AreaObjectives, GeneralConstants.Component.Competencies }.Contains(a.ComponentId))))
               .ForMember(x => x.StagesEvaluation, m => m.MapFrom(d => d.EvaluationComponentStages.Where(w => w.EvaluationComponentId == null).Select(ecs => new StageRangeDate
               {
                   RangeDate = "Desde " + $"{ecs.StartDate.ToString("dd [P1] MMMMM, yyyy")} hasta {ecs.EndDate.ToString("dd [P1] MMMMM, yyyy")}".Replace("[P1]", "de"),
                   StageId = ecs.StageId,
                   StageName = $"Etapa de {GeneralConstants.Stages.StagesName[ecs.StageId]}"
               }).OrderBy(o => o.StageId)))
               .ForMember(x => x.Components, m => m.MapFrom(d => d.EvaluationComponents.Select(ec => new ComponentRangeDate { 
               
                    ComponentName = GeneralConstants.Component.ComponentsName[ec.ComponentId],
                    ComponentId = ec.ComponentId,
                    RangeDate = GeneralConstants.Component.Competencies != ec.ComponentId
                        ? ec.EvaluationComponentStages
                            .Where(w => w.EvaluationComponentId == ec.Id)
                            .Select(s => "Desde " + $"{s.StartDate.ToString("dd [P1] MMMMM, yyyy")} hasta {s.EndDate.ToString("dd [P1] MMMMM, yyyy")}".Replace("[P1]", "de"))
                            .First()
                        : "",
                    Stages = GeneralConstants.Component.Competencies == ec.ComponentId
                        ? ec.EvaluationComponentStages.Select(ecs => new StageRangeDate { 
                                RangeDate = "Desde " + $"{ecs.StartDate.ToString("dd [P1] MMMMM, yyyy")} hasta {ecs.EndDate.ToString("dd [P1] MMMMM, yyyy")}".Replace("[P1]", "de"),
                                StageId = ecs.StageId,
                                StageName = $"Etapa de {GeneralConstants.Stages.StagesName[ecs.StageId]}"
                        }).OrderBy(o => o.StageId).ToList()
                        : new List<StageRangeDate>()                        
               })));


        }
    }
}
