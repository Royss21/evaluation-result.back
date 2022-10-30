
namespace Application.Main.Services.EvaResult
{
    using Application.Dto.EvaResult.ComponentStage;
    using Application.Main.Service.Base;
    using Application.Main.Services.EvaResult.Interfaces;
    using System.Threading.Tasks;

    public class ComponentStageService : BaseService, IComponentStageService
    {
        public ComponentStageService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public Task<ComponentStageDto> CreateAsync(ComponentStageCreateDto request)
        {
            throw new NotImplementedException();
        }
    }
}