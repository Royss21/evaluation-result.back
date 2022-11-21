
namespace Application.Main.Services.Config.Validators
{
    using Domain.Common.Constants;
    using Domain.Main.Base;
    using Domain.Main.Config;
    using FluentValidation;
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class ParameterValueCreateUpdateValidator : BaseValidator<ParameterValue>
    {
        private readonly IParameterValueRepository _parameterValueRepository;
        public ParameterValueCreateUpdateValidator(IParameterValueRepository parameterValueRepository) : base()
        {
            _parameterValueRepository = parameterValueRepository;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x)
                .MustAsync((parameterValue, cancel) => ParameterValueSharedValidator.NameExists(_parameterValueRepository, parameterValue))
                .WithMessage(Messages.General.NameAlreadyRegistered);
        }
    }

    public static class ParameterValueSharedValidator
    {
        public static async Task<bool> NameExists(IParameterValueRepository parameterValueRepository, ParameterValue parameterValue)
        {
            var predicate = PredicateBuilder.New<ParameterValue>(true);

            if(parameterValue.Id != 0)
                predicate.And(p => p.Id != parameterValue.Id);

            predicate.And(p => EF.Functions.Like(p.Name.Trim().ToLower(), parameterValue.Name.Trim().ToLower()));

            var result = await parameterValueRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }
    }
}
