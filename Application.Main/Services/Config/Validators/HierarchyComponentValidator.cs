
namespace Application.Main.Services.Config.Validators
{
    using Application.Dto.Config.HierarchyComponent;
    using Application.Main.Exceptions;
    using Domain.Common.Constants;

    public static class HierarchyComponentValidator
    {

        public static void ValidateComponents(List<HierarchyComponentUpdateDto> request)
        {
            if (request.Any(s => s.Weight <= 0))
                throw new WarningException(Messages.HierarchyComponent.SomeComponentHasZeroWeight);

            if (request.Sum(s => s.Weight) > 100)
                throw new WarningException(Messages.HierarchyComponent.SumWeightIsGreater);
        }
    }
}
