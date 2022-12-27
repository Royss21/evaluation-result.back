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
                .MustAsync((gerency, cancel) => NameExists(gerency))
                .WithMessage(Messages.General.NameAlreadyRegistered);
        }

        async Task<bool> NameExists(Gerency gerency)
        {
            var predicate = PredicateBuilder.New<Gerency>(true);
            predicate.And(p => EF.Functions.Like(p.Name.Trim(), gerency.Name.Trim()));
            var result = await _gerencyRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }
    }
}
