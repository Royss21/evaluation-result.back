
namespace Application.Main.Services.EvaResult
{
    using Application.Dto.EvaResult.ComponentCollaborator;
    using Application.Dto.EvaResult.Evaluation;
    using Application.Dto.EvaResult.EvaluationCollaborator;
    using Application.Dto.Pagination;
    using Application.Dto.Views;
    using Application.Main.Exceptions;
    using Application.Main.Pagination;
    using Application.Main.Service.Base;
    using Application.Main.Services.EvaResult.Interfaces;
    using Application.Main.Services.General.Interfaces;
    using Domain.Common.Constants;
    using Domain.Common.Enums;
    using Domain.Main.Config;
    using Domain.Main.EvaResult;
    using Hangfire;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SharedKernell.Mail;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EvaluationCollaboratorService : BaseService, IEvaluationCollaboratorService
    {
        public readonly IComponentCollaboratorService _componentCollaboratorService;
        public readonly IMailService _mailService;
        public EvaluationCollaboratorService(
            IServiceProvider serviceProvider, IComponentCollaboratorService componentCollaboratorService, IMailService mailService
        ) : base(serviceProvider)
        {
            _componentCollaboratorService = componentCollaboratorService;
            _mailService = mailService;
        }

        public async Task<EvaluationCollaboratorDto> CreateAsync(EvaluationCollaboratorCreateDto request)
        {
            var evaluationCollaboratorDeleted = (await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                    .RunSqlQuery<EvaluationCollaboratorDto>("[dbo].[uspGetLastEvaluationCollaboratorDeleted]", new { collaboratorId = request.CollaboratorId }))
                    .FirstOrDefault();

            var evaluationCollaborator = _mapper.Map<EvaluationCollaborator>(request);
            var evaluationComponentStages = await _unitOfWorkApp.Repository.EvaluationComponentStageRepository
                    .Find(f => f.EvaluationId.Equals(request.EvaluationId))
                    .ToListAsync();
            var evaluationComponents = await _unitOfWorkApp.Repository.EvaluationComponentRepository
                    .Find(f => f.EvaluationId.Equals(request.EvaluationId))
                    .Include(i => i.Component)
                    .ToListAsync();
            var componentIds = evaluationComponents.Select(ec => ec.ComponentId).ToList();
            var hierarchyComponentsOfCollaborator = await _unitOfWorkApp.Repository.HierarchyComponentRepository
                    .Find(h => h.Hierarchy.Name.Equals(request.HierarchyName))
                    .Include(hc => hc.Hierarchy)
                    .ToListAsync();
            var subcomponents = await _unitOfWorkApp.Repository.SubcomponentRepository
                   .Find(s => 
                        componentIds.Contains(s.ComponentId) && 
                        (s.Area.Name.Equals(request.AreaName) || s.AreaId == null)
                    )
                   .Include("Formula")
                   .Include("SubcomponentValues.Charge")
                   .ToListAsync();

            foreach (var evaluationComponent in evaluationComponents)
            {
                var conducts = new List<Conduct>();
                var hierarchyComponent = hierarchyComponentsOfCollaborator.First(s => s.ComponentId == evaluationComponent.ComponentId);
                var subcomponentsCompetencie = subcomponents.Where(s => s.ComponentId == evaluationComponent.ComponentId).ToList();

                if (hierarchyComponent is null)
                    throw new WarningException($"No se ha configurado el peso de las jerarquia para el componente de {GeneralConstants.Component.ComponentsName[evaluationComponent.ComponentId]}");

                if (!subcomponents.Any())
                    throw new WarningException($"No se ha configurado ningun subcomponente para el componente de {GeneralConstants.Component.ComponentsName[evaluationComponent.ComponentId]}");

                if (evaluationComponent.ComponentId == GeneralConstants.Component.Competencies)
                {
                    conducts = await _unitOfWorkApp.Repository.ConductRepository
                        .Find(c => subcomponents.Select(s => s.Id).Contains(c.SubcomponentId) && c.Level.Name.Equals(request.LevelName))
                        .Include(i => i.Level)
                        .ToListAsync();

                    if (!conducts.Any())
                        throw new WarningException($"No se ha configurado conductas para el componente de {GeneralConstants.Component.ComponentsName[evaluationComponent.ComponentId]}");
                }

                var componentCollaboratorDetails = new List<ComponentCollaboratorDetail>();

                if (evaluationComponent.ComponentId == GeneralConstants.Component.Competencies)
                {

                    var conductsOfCollaborator = conducts.Where(c => c.Level.Name.ToLower().Equals(evaluationCollaborator.LevelName.ToLower()));
                    var subcomponentsOfCollaborator = subcomponents.Where(s =>
                        conductsOfCollaborator.Select(coc => coc.SubcomponentId).Contains(s.Id)
                    ).ToList();

                    componentCollaboratorDetails = subcomponentsOfCollaborator
                            .Select(s =>
                            {
                                return new ComponentCollaboratorDetail
                                {
                                    FormulaName = "",
                                    FormulaQuery = "",
                                    SubcomponentName = s.Name,
                                    ComponentCollaboratorConducts = conductsOfCollaborator.Where(c => c.SubcomponentId.Equals(s.Id))
                                        .Select(c => new ComponentCollaboratorConduct
                                        {
                                            ConductDescription = c.Description,
                                            LevelName = c.Level.Name
                                        }).ToList()
                                };
                            }).ToList();
                }
                else
                    componentCollaboratorDetails = subcomponents
                            .Where(s => 
                                s.SubcomponentValues.Select(sv => sv.Charge.Name).Contains(request.ChargeName) &&
                                s.ComponentId == evaluationComponent.ComponentId
                            )
                            .Select(s =>
                            {
                                var subcomponentValue = s.SubcomponentValues.First(sv => sv.SubcomponentId == s.Id && sv.Charge.Name.Equals(request.ChargeName));

                                return new ComponentCollaboratorDetail
                                {
                                    SubcomponentName = s.Name,
                                    WeightRelative = subcomponentValue.RelativeWeight,
                                    MinimunPercentage = subcomponentValue.MinimunPercentage,
                                    MaximunPercentage = subcomponentValue.MaximunPercentage,
                                    FormulaName = s.Formula?.Name ?? "",
                                    FormulaQuery = s.Formula?.FormulaQuery ?? "",
                                };
                            }).ToList();

                evaluationCollaborator.ComponentsCollaborator.Add(new ComponentCollaborator
                {
                    EvaluationComponentId = evaluationComponent.Id,
                    StatusId = GeneralConstants.StatusIds.Create,
                    WeightHierarchy = hierarchyComponent.Weight,
                    HierarchyName = hierarchyComponent.Hierarchy.Name,
                    ComponentName = evaluationComponent.Component.Name,
                    ComponentCollaboratorDetails = componentCollaboratorDetails
                });
            }

            evaluationCollaborator.ComponentCollaboratorComments = evaluationComponentStages.Select(s => new ComponentCollaboratorComment{ 
                EvaluationComponentStageId = s.Id,
                StatusId = GeneralConstants.StatusIds.Create
            }).ToList();

            await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository.AddAsync(evaluationCollaborator);
            await _unitOfWorkApp.SaveChangesAsync();

            if (evaluationCollaboratorDeleted is not null)
            {
                await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                        .RunSqlQuery<EvaluationCollaboratorDto>("[dbo].[uspUpdateEvaluationCollaboratorCurrentIdInEvaluationLeader]",
                                                                new
                                                                {
                                                                    evaluationCollaboratorDeletedId = evaluationCollaboratorDeleted.Id,
                                                                    evaluationCollaboratorCurrentId = evaluationCollaborator.Id
                                                                });

                var leaderCollaborators = await _unitOfWorkApp.Repository.LeaderCollaboratorRepository
                        .Find(lc => lc.EvaluationCollaboratorId.Equals(evaluationCollaboratorDeleted.Id), false)
                        .ToListAsync();

                if (leaderCollaborators.Any())
                    leaderCollaborators.ForEach(lc => lc.EvaluationCollaboratorId = evaluationCollaborator.Id);
                
                await _unitOfWorkApp.SaveChangesAsync();
            }

            return _mapper.Map<EvaluationCollaboratorDto>(evaluationCollaborator);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var removeEvaluationCollaborator = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                    .Find(f => f.Id.Equals(id))
                    .Include("ComponentsCollaborator.ComponentCollaboratorDetails.ComponentCollaboratorConducts")
                    .Include("ComponentCollaboratorComments")
                    .Include("EvaluationLeaders.LeaderStages.LeaderCollaborators")
                    .ToListAsync();

            var leaderCollaborator = await _unitOfWorkApp.Repository.LeaderCollaboratorRepository
                    .Find(f => f.EvaluationCollaboratorId.Equals(id))
                    .ToListAsync();

            _unitOfWorkApp.Repository.EvaluationCollaboratorRepository.RemoveRange(removeEvaluationCollaborator);
            _unitOfWorkApp.Repository.LeaderCollaboratorRepository.RemoveRange(leaderCollaborator);

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<EvaluationCollaboratorResultDto> GetEvaluationResultByIdAsync(Guid evaluationId, Guid evaluationCollaboratorId)
        {
            var evaluationComponentStage = await _componentCollaboratorService.GetEvaluationComponentStageAsync(evaluationId: evaluationId);

            await _componentCollaboratorService.UpdateStatusCommentAsync(new UpdateStatusDto
            {
                EvaluationComponentStageId = evaluationComponentStage.Id,
                EvaluationCollaboratorId = evaluationCollaboratorId,
                StatusId = GeneralConstants.StatusIds.InProgress,
                IsUpdateComponent = false
            });

            var evaluationCollaboratorResult = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                    .Find(f => f.Id.Equals(evaluationCollaboratorId))
                    .ProjectTo<EvaluationCollaboratorResultDto>(_mapper.ConfigurationProvider)
                    .FirstAsync();

            if (evaluationCollaboratorResult is null)
                throw new WarningException("No se encontró datos del colaborador");


            var componentsCollaborator = await _unitOfWorkApp.Repository.ComponentCollaboratorRepository
                    .Find(f =>
                        f.EvaluationComponent.EvaluationId.Equals(evaluationId) &&
                        f.EvaluationCollaboratorId.Equals(evaluationCollaboratorId)
                    )
                    .ProjectTo<ComponentCollaboratorResultDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            if (componentsCollaborator is null || !componentsCollaborator.Any())
                throw new WarningException("No se encontró componentes del colaborador");


            var comments = await _unitOfWorkApp.Repository.ComponentCollaboratorCommentRepository
                    .Find(f =>f.EvaluationCollaboratorId.Equals(evaluationCollaboratorId))
                    .Include(i=> i.EvaluationComponentStage)
                    .ToListAsync();
            var currentComent = comments.First(c => c.EvaluationComponentStageId == evaluationComponentStage.Id);

            componentsCollaborator.ForEach(cc =>
            {
                if(cc.ComponentId == GeneralConstants.Component.Competencies)
                {
                    cc.EvaluationComment = comments.First(f => 
                        f.EvaluationComponentStage.EvaluationComponentId == cc.EvaluationComponentId &&
                        f.EvaluationComponentStage.StageId == GeneralConstants.Stages.Evaluation
                    ).Comment;

                    cc.CalibrationComment = comments.First(f =>
                        f.EvaluationComponentStage.EvaluationComponentId == cc.EvaluationComponentId &&
                        f.EvaluationComponentStage.StageId == GeneralConstants.Stages.Calibration
                    ).Comment;
                }
                else
                    cc.EvaluationComment = comments.First(f => f.EvaluationComponentStage.EvaluationComponentId == cc.EvaluationComponentId).Comment;
            });

            evaluationCollaboratorResult.ResultComponents = componentsCollaborator;
            evaluationCollaboratorResult.StageId = evaluationComponentStage.StageId;
            evaluationCollaboratorResult.EvaluationComponentStageId = evaluationComponentStage.Id;
            evaluationCollaboratorResult.StatusId = currentComent.StatusId;
            evaluationCollaboratorResult.ComponentCollaboratorCommentId = currentComent.Id;
            evaluationCollaboratorResult.ApprovalComment = comments.First(f => f.EvaluationComponentStage.StageId == GeneralConstants.Stages.Approval).Comment;
            evaluationCollaboratorResult.FeedbackComment = comments.First(f => f.EvaluationComponentStage.StageId == GeneralConstants.Stages.Feedback).Comment;

            return evaluationCollaboratorResult;
        }

        public async Task<bool> SaveCommentEvaluationStageAsync(CommentEvaluationDto request, Controller controller)
        {
            var componentCollaboratorComment = await _unitOfWorkApp.Repository.ComponentCollaboratorCommentRepository
                .Find(f => f.Id == request.ComponentCollaboratorCommentId, false)
                .FirstAsync();

            componentCollaboratorComment.Comment = request.Comment;
            componentCollaboratorComment.StatusId = GeneralConstants.StatusIds.Completed;

            await _unitOfWorkApp.SaveChangesAsync();

            var stageId = await _unitOfWorkApp.Repository.EvaluationComponentStageRepository
                    .Find(f => f.Id == componentCollaboratorComment.EvaluationComponentStageId)
                    .Select(s => s.StageId)
                    .FirstAsync();

            if (stageId == GeneralConstants.Stages.Feedback)
            {

                var collaborator = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                        .Find(f => f.Id.Equals(componentCollaboratorComment.EvaluationCollaboratorId))
                        .Select(s => new EmailNotifyCollaboratorDto
                        {
                            Email = s.Collaborator.Email,
                            EvaluationCollaboratorId = s.Id.ToString(),
                            FullName = $"{s.Collaborator.Name} {s.Collaborator.LastName}",
                            EvaluationId = s.EvaluationId
                        })
                        .FirstAsync();

                collaborator.RangeDateStageApproval = await _unitOfWorkApp.Repository.EvaluationComponentStageRepository
                        .Find(f =>
                            f.EvaluationComponent.ComponentId == GeneralConstants.Component.Competencies &&
                            f.StageId == GeneralConstants.Stages.Approval &&
                            f.EvaluationId.Equals(collaborator.EvaluationId)
                        )
                        .Select(s => "Desde el " + $"{s.StartDate.ToString("dd [P1] MMMMM, yyyy")} hasta el {s.EndDate.ToString("dd [P1] MMMMM, yyyy")}".Replace("[P1]", "de"))
                        .FirstAsync();

                var evaluationCollaborator = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                    .Find(f => f.Id.Equals(componentCollaboratorComment.EvaluationCollaboratorId))
                    .FirstAsync();

                var commentsStatus = await _unitOfWorkApp.Repository.ComponentCollaboratorCommentRepository
                    .Find(f => 
                        f.EvaluationCollaborator.EvaluationId.Equals(evaluationCollaborator.EvaluationId) &&
                        f.EvaluationComponentStage.StageId != GeneralConstants.Stages.Approval
                    )
                    .Select(s => s.StatusId)
                    .ToListAsync();

                var evaluation = await _unitOfWorkApp.Repository.EvaluationRepository
                        .Find(f => f.Id.Equals(evaluationCollaborator.EvaluationId), false)
                        .FirstAsync();

                evaluation.StatusId = commentsStatus.All(statusId => statusId == GeneralConstants.StatusIds.Completed)
                        ? GeneralConstants.StatusIds.Completed
                        : GeneralConstants.StatusIds.InProgress;

                await _unitOfWorkApp.SaveChangesAsync();

                BackgroundJob.Enqueue(() => _mailService.Send(new Mail
                {
                    Subject = "Evaluación de Desempeño - Etapa Visto bueno",
                    Mails = new List<string> { collaborator.Email },
                    Body = _mailService.UploadBodyMail<object>(MailTemplateEnum.EmailCollaboratorStageApproval, controller, collaborator)
                }));
            }

            return true;
        }

        public async Task<PaginationResultDto<EvaluationCollaboratorReviewPagingDto>> GetPagingCollaboratorReviewStageEvaluationAsync(EvaluationCollaboratorReviewFilterDto filter)
        {
            var evaluationComponentStageId = await _unitOfWorkApp.Repository.EvaluationComponentStageRepository
                .Find(f => f.EvaluationId.Equals(filter.EvaluationId) && f.StageId == filter.StageId)
                .Select(s => s.Id)
                .FirstAsync();

            var parametersDto = PrimeNgToPaginationParametersDto<EvaluationCollaboratorReviewPagingDto>.Convert(filter);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<EvaluationCollaborator, EvaluationCollaboratorReviewPagingDto>(_mapper);

            if (filter.EvaluationCollaboratorId is not null)
            {
                var currentDate = DateTime.UtcNow.GetDatePeru();
                var leaderStageIds = await _unitOfWorkApp.Repository.LeaderStageRepository
                        .Find(f =>
                            f.EvaluationLeader.EvaluationCollaboratorId.Equals(filter.EvaluationCollaboratorId) &&
                            f.EvaluationLeader.EvaluationComponent.ComponentId == GeneralConstants.Component.Competencies &&
                            f.StageId == filter.StageId
                        )
                        .Select(s => s.Id)
                        .ToListAsync();

                var collaboratorIds = await _unitOfWorkApp.Repository.LeaderCollaboratorRepository
                        .Find(f => leaderStageIds.Contains(f.LeaderStageId))
                        .Select(s => s.EvaluationCollaboratorId)
                        .ToListAsync();

                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                    .AddCondition(add => collaboratorIds.Contains(add.Id));    
            }
  
            if (!string.IsNullOrWhiteSpace(filter.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add =>
                            add.Collaborator.Name.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.Collaborator.LastName.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.Collaborator.MiddleName.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.Collaborator.DocumentNumber.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.AreaName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.ChargeName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.GerencyName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.HierarchyName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower())
                        );
            }

            var paging = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository.FindAllPagingAsync(parametersDomain);
            var evaluationCollaborators = await paging.Entities.ProjectTo<EvaluationCollaboratorReviewPagingDto>(_mapper.ConfigurationProvider).ToListAsync();

            foreach(var ec  in evaluationCollaborators)
            {
                var currentComent = await _unitOfWorkApp.Repository.ComponentCollaboratorCommentRepository
                       .Find(f => f.EvaluationCollaboratorId.Equals(ec.Id) && f.EvaluationComponentStageId == evaluationComponentStageId)
                       .FirstAsync();

                ec.StatusId = currentComent.StatusId;
            }

            return new PaginationResultDto<EvaluationCollaboratorReviewPagingDto>
            {
                Count = paging.Count,
                Entities = evaluationCollaborators
            };
        }

        public async Task<PaginationResultDto<EvaluationCollaboratorPagingDto>> GetPagingAsync(PagingFilterDto filter)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<EvaluationCollaboratorPagingDto>.Convert(filter);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<EvaluationCollaborator, EvaluationCollaboratorPagingDto>(_mapper);

            if (!string.IsNullOrWhiteSpace(filter.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add =>
                            add.Collaborator.Name.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.Collaborator.LastName.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.Collaborator.MiddleName.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.Collaborator.DocumentNumber.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.AreaName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.ChargeName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.GerencyName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.HierarchyName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower())
                        );
            }

            var paging = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository.FindAllPagingAsync(parametersDomain);
            var evaluationCollaborators = await paging.Entities.ProjectTo<EvaluationCollaboratorPagingDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<EvaluationCollaboratorPagingDto>
            {
                Count = paging.Count,
                Entities = evaluationCollaborators
            };
        }
    }
}
