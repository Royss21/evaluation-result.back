namespace Application.Main.Services.Employee.Validators
{
    using FluentValidation;
    using Domain.Main.Base;
    using Domain.Main.Employee;
    using Domain.Common.Constants;
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
                .MustAsync((charge, cancel) => ChargeSharedValidator.NameExists(_chargeRepository, charge))
                .WithMessage(Messages.General.NameAlreadyRegistered);

            RuleFor(x => x)
                .MustAsync((charge, cancel) => ChargeSharedValidator.AreaRequired(charge))
                .WithMessage(Messages.Charge.AreaRequired);

            RuleFor(x => x)
                .MustAsync((charge, cancel) => ChargeSharedValidator.HierarchyRequired(charge))
                .WithMessage(Messages.Charge.HierarchyRequired);
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

        public static async Task<bool> NameExists(IChargeRepository chargeRepository, Charge charge)
        {
            var predicate = PredicateBuilder.New<Charge>(true);

            if (charge.Id != 0)
                predicate.And(p => p.Id != charge.Id);

            predicate.And(p => EF.Functions.Like(p.Name.Trim().ToLower(), charge.Name.Trim().ToLower()));

            var result = await chargeRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }
    }
}
