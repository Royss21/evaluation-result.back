
namespace Application.Main.Services.Config.Validators
{
    using Domain.Common.Constants;
    using Domain.Main.Base;
    using Domain.Main.Config;
    using FluentValidation;
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class ParameterRangeCreateUpdateValidator : BaseValidator<ParameterRange>
    {
        private readonly IParameterRangeRepository _parameterRangeRepository;
        public ParameterRangeCreateUpdateValidator(IParameterRangeRepository parameterRangeRepository) : base()
        {
            _parameterRangeRepository = parameterRangeRepository;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x)
                .MustAsync((ParameterRange, cancel) => ParameterRangeSharedValidator.NameExists(_parameterRangeRepository, ParameterRange))
                .WithMessage(Messages.General.NameAlreadyRegistered);
        }
    }

    public static class ParameterRangeSharedValidator
    {
        public static async Task<bool> NameExists(IParameterRangeRepository parameterRangeRepository, ParameterRange parameterRange)
        {
            var predicate = PredicateBuilder.New<ParameterRange>(true);

            if(!parameterRange.Id.Equals(Guid.Empty))
                predicate.And(p => !p.Id.Equals(parameterRange.Id));

            predicate.And(p => EF.Functions.Like(p.Name.Trim().ToLower(), parameterRange.Name.Trim().ToLower()));

            var result = await parameterRangeRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }
    }
}
