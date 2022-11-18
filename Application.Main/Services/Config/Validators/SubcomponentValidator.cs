
namespace Application.Main.Services.Config.Validators
{
    using Domain.Common.Constants;
    using Domain.Main.Base;
    using Domain.Main.Config;
    using FluentValidation;
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class SubcomponentCreateUpdateValidator : BaseValidator<Subcomponent>
    {
        private readonly ISubcomponentRepository _subcomponentRepository;
        public SubcomponentCreateUpdateValidator(ISubcomponentRepository subcomponentRepository) : base()
        {
            _subcomponentRepository = subcomponentRepository;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x)
                .MustAsync((subcomponent, cancel) => SubcomponentSharedValidator.NameExists(_subcomponentRepository, subcomponent))
                .WithMessage(Messages.General.NameAlreadyRegistered)
                .MustAsync((subcomponent, cancel) => SubcomponentSharedValidator.AreaRequired(subcomponent))
                .WithMessage(Messages.Subcomponent.AreaRequired)
                .MustAsync((subcomponent, cancel) => SubcomponentSharedValidator.FormulaRequired(subcomponent))
                .WithMessage(Messages.Subcomponent.FormulaRequired);
        }
    }

    public static class SubcomponentSharedValidator
    {
        public static async Task<bool> NameExists(ISubcomponentRepository subcomponentRepository, Subcomponent subcomponent)
        {
            var predicate = PredicateBuilder.New<Subcomponent>(true);

            if(!subcomponent.Id.Equals(Guid.Empty))
                predicate.And(p => !p.Id.Equals(subcomponent.Id));

            predicate.And(p => EF.Functions.Like(p.Name.Trim().ToLower(), subcomponent.Name.Trim().ToLower()));

            var result = await subcomponentRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }

        public static async Task<bool> AreaRequired(Subcomponent subcomponent)
        {
            if (new[] { GeneralConstants.Component.CorporateObjectives, GeneralConstants.Component.AreaObjectives }.Contains(subcomponent.ComponentId) &&
                subcomponent.AreaId is null
                )
                return false;

            return true;
        }

        public static async Task<bool> FormulaRequired(Subcomponent subcomponent)
        {
            if (new[] { GeneralConstants.Component.CorporateObjectives }.Contains(subcomponent.ComponentId) &&
                subcomponent.FormulaId is null
                )
                return false;

            return true;
        }
    }
}
