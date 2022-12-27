namespace Application.Main.Services.Employee.Validators
{
    using Domain.Common.Constants;
    using Domain.Main.Base;
    using Domain.Main.Employee;
    using FluentValidation;
    using Infrastructure.Main.Repository.Employee.Interfaces;

    public class ChargeCreateUpdateValidation : BaseValidator<Charge>
    {
        private readonly IChargeRepository _chargeRepository;

        public ChargeCreateUpdateValidation(IChargeRepository chargeRepository)
        {
            _chargeRepository = chargeRepository;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x)
                .MustAsync((charge, cancel) => NameExists(charge))
                .WithMessage(Messages.General.NameAlreadyRegistered);

            RuleFor(x => x)
                .MustAsync((charge, cancel) => ChargeSharedValidator.AreaRequired(charge))
                .WithMessage(Messages.Charge.AreaRequired);

            RuleFor(x => x)
                .MustAsync((charge, cancel) => ChargeSharedValidator.HierarchyRequired(charge))
                .WithMessage(Messages.Charge.HierarchyRequired);
        }

        async Task<bool> NameExists(Charge charge)
        {
            var predicate = PredicateBuilder.New<Charge>(true);
            predicate.And(p => EF.Functions.Like(p.Name.Trim(), charge.Name.Trim()));
            var result = await _chargeRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }
    }

    public static class ChargeSharedValidator
    {
        public static async Task<bool> AreaRequired(Charge charge)
        {
            if (charge.AreaId <= 0)
                return false;

            return true;
        }

        public static async Task<bool> HierarchyRequired(Charge charge)
        {
            if (charge.HierarchyId <= 0)
                return false;

            return true;
        }
    }
}
