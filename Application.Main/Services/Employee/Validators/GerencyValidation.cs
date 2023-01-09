namespace Application.Main.Services.Employee.Validators
{
    using Domain.Common.Constants;
    using Domain.Main.Base;
    using Domain.Main.Employee;
    using FluentValidation;
    using Infrastructure.Main.Repository.Employee.Interfaces;

    public class GerencyCreateUpdateValidation : BaseValidator<Gerency>
    {
        private readonly IGerencyRepository _gerencyRepository;

        public GerencyCreateUpdateValidation(IGerencyRepository gerencyRepository) : base()
        {
            _gerencyRepository = gerencyRepository;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x)
                .MustAsync((gerency, cancel) => GerencySharedValidator.NameExists(_gerencyRepository, gerency))
                .WithMessage(Messages.General.NameAlreadyRegistered);
        }

    }

    public static class GerencySharedValidator
    {
        public static async Task<bool> NameExists(IGerencyRepository levelRepository, Gerency gerency)
        {
            var predicate = PredicateBuilder.New<Gerency>(true);

            if (gerency.Id != 0)
                predicate.And(p => p.Id != gerency.Id);

            predicate.And(p => EF.Functions.Like(p.Name.Trim().ToLower(), gerency.Name.Trim().ToLower()));

            var result = await levelRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }
    }
}
