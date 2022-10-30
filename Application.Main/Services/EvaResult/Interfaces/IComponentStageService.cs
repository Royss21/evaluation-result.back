namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.ComponentStage;

    public interface IComponentStageService
    {

        Task<ComponentStageDto> CreateAsync(ComponentStageCreateDto request);

    }
}
