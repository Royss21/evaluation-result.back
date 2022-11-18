
namespace Application.Main.Services.Config.Validators
{
    using Domain.Common.Constants;
    using Domain.Main.Base;
    using Domain.Main.Config;
    using FluentValidation;
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class ConductCreateUpdateValidator : BaseValidator<Conduct>
    {
        private readonly IConductRepository _conductRepository;
        public ConductCreateUpdateValidator(IConductRepository conductRepository) : base()
        {
            _conductRepository = conductRepository;

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x)
                .MustAsync((Conduct, cancel) => ConductSharedValidator.DescriptionExists(_conductRepository, Conduct))
                .WithMessage(Messages.General.DescriptionAlreadyRegistered);
        }
    }

    public static class ConductSharedValidator
    {
        public static async Task<bool> DescriptionExists(IConductRepository conductRepository, Conduct conduct)
        {
            var predicate = PredicateBuilder.New<Conduct>(true);

            if(!conduct.Id.Equals(Guid.Empty))
                predicate.And(p => !p.Id.Equals(conduct.Id));

            predicate.And(p => EF.Functions.Like(p.Description.Trim().ToLower(), conduct.Description.Trim().ToLower()));

            var result = await conductRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }
    }
}
