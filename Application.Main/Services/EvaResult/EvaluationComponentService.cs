
namespace Application.Main.Services.EvaResult
{
    using Application.Dto.EvaResult.EvaluationComponent;
    using Application.Main.Service.Base;
    using Application.Main.Services.EvaResult.Interfaces;
    using System.Threading.Tasks;

    public class EvaluationComponentService : BaseService, IEvaluationComponentService
    {
        public EvaluationComponentService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public Task<EvaluationComponentDto> CreateAsync(EvaluationComponentCreateDto request)
        {
            throw new NotImplementedException();
        }
    }
}
