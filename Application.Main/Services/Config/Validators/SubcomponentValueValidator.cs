
namespace Application.Main.Services.Config.Validators
{
    using Domain.Common.Constants;
    using Domain.Main.Base;
    using Domain.Main.Config;
    using FluentValidation;

    public class SubcomponentValueCreateUpdateValidator : BaseValidator<SubcomponentValue>
    {
        public SubcomponentValueCreateUpdateValidator() : base()
        {

            RuleFor(x => x)
                .MustAsync((subcomponentValue, cancel) => SubcomponentValueSharedValidator.RelativeWeightValidate(subcomponentValue))
                .WithMessage(Messages.SubcomponentValue.RelativeWeightOutRange)
                .MustAsync((subcomponentValue, cancel) => SubcomponentValueSharedValidator.PercentageMinimumValidate(subcomponentValue))
                .WithMessage(Messages.SubcomponentValue.PercentageMinimumOutRange)
                .MustAsync((subcomponentValue, cancel) => SubcomponentValueSharedValidator.PercentageMaximumValidate(subcomponentValue))
                .WithMessage(Messages.SubcomponentValue.PercentageMinimumOutRange)
                .MustAsync((subcomponentValue, cancel) => SubcomponentValueSharedValidator.PercentageValidate(subcomponentValue))
                .WithMessage(Messages.SubcomponentValue.PercentageValidate);
        }
    }

    public static class SubcomponentValueSharedValidator
    {
        public static async Task<bool> RelativeWeightValidate(SubcomponentValue subcomponentValue)
        {
            if (subcomponentValue.RelativeWeight <= 0 || subcomponentValue.RelativeWeight > 100)
                return false;

            return true;
        }

        public static async Task<bool> PercentageMinimumValidate(SubcomponentValue subcomponentValue)
        {
            if (subcomponentValue.MinimunPercentage <= 0)
                return false;

            return true;
        }

        public static async Task<bool> PercentageMaximumValidate(SubcomponentValue subcomponentValue)
        {
            if (subcomponentValue.MaximunPercentage <= 0)
                return false;

            return true;
        }

        public static async Task<bool> PercentageValidate(SubcomponentValue subcomponentValue)
        {
            if (subcomponentValue.MinimunPercentage >= subcomponentValue.MaximunPercentage)
                return false;

            return true;
        }
    }
}
