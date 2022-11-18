
namespace Application.Main.Services.Config.Validators
{
    using Domain.Common.Constants;
    using Domain.Main.Base;
    using Domain.Main.Config;
    using FluentValidation;
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class FormulaCreateUpdateValidator : BaseValidator<Formula>
    {
        private readonly IFormulaRepository _formulaRepository;
        public FormulaCreateUpdateValidator(IFormulaRepository formulaRepository) : base()
        {
            _formulaRepository = formulaRepository;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x.FormulaReal)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x)
                .MustAsync((formula, cancel) => FormulaSharedValidator.NameExists(_formulaRepository, formula))
                .WithMessage(Messages.General.NameAlreadyRegistered)
                .MustAsync((formula, cancel) => FormulaSharedValidator.FormulaExists(_formulaRepository, formula))
                .WithMessage(Messages.Level.FormulaAlreadyRegistered);
        }
    }

    public static class FormulaSharedValidator
    {
        public static async Task<bool> NameExists(IFormulaRepository formulaRepository, Formula formula)
        {
            var predicate = PredicateBuilder.New<Formula>(true);

            if(!formula.Id.Equals(Guid.Empty))
                predicate.And(p => !p.Id.Equals(formula.Id));

            predicate.And(p => EF.Functions.Like(p.Name.Trim().ToLower(), formula.Name.Trim().ToLower()));

            var result = await formulaRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }

        public static async Task<bool> FormulaExists(IFormulaRepository formulaRepository, Formula formula)
        {
            var predicate = PredicateBuilder.New<Formula>(true);

            if (!formula.Id.Equals(Guid.Empty))
                predicate.And(p => !p.Id.Equals(formula.Id));

            predicate.And(p => EF.Functions.Like(p.FormulaReal.Trim().ToLower(), formula.FormulaReal.Trim().ToLower()));

            var result = await formulaRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }
    }
}
