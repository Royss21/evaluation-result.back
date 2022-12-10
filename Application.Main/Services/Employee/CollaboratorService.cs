namespace Application.Main.Services.Employee
{
    using Application.Dto.Employee.Collaborator;
    using Application.Main.Service.Base;
    using Application.Main.Services.Employee.Interfaces;

    public class CollaboratorService : BaseService, ICollaboratorService
    {
        public CollaboratorService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<IEnumerable<CollaboratorNotInEvaluationDto>> GetAllCollaboratorNotInEvaluationAsync(Guid evaluationId)
        {
            var collaboratorIdsInEvaluation = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                    .Find(f => f.EvaluationId.Equals(evaluationId))
                    .Select(s => s.CollaboratorId)
                    .ToListAsync();

            return await _unitOfWorkApp.Repository.CollaboratorRepository
                    .Find(f => !collaboratorIdsInEvaluation.Contains(f.Id))
                    .ProjectTo<CollaboratorNotInEvaluationDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }
    }
}
