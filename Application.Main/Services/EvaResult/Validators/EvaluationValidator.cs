
namespace Application.Main.Services.EvaResult.Validators
{
    using Domain.Common.Constants;
    using Domain.Main.Base;
    using Domain.Main.EvaResult;
    using FluentValidation;
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class EvaluationCreateValidator : BaseValidator<Evaluation>
    {
        private readonly IEvaluationRepository _evaluationRepository;
        public EvaluationCreateValidator(IEvaluationRepository evaluationRepository) : base()
        {
            _evaluationRepository = evaluationRepository;

            RuleFor(x => x)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty)
                .MustAsync((evaluation, cancel) => EvaluationSharedValidator.NameExists( _evaluationRepository, evaluation))
                .WithMessage(Messages.General.NameAlreadyRegistered)
                .MustAsync((evaluation, cancel) => EvaluationSharedValidator.DateRangeIsValid(_evaluationRepository, evaluation))
                .WithMessage(Messages.General.RangeDatesIsNotValid)
                .MustAsync((evaluation, cancel) => EvaluationSharedValidator.DateRangeBetweenIsValid(_evaluationRepository, evaluation))
                .WithMessage("Existen evaluaciones que se encuentran dentro del rango de fechas ingresadas");
        }
    }


    public static class EvaluationSharedValidator
    {
        public static async Task<bool> NameExists(IEvaluationRepository EvaluationRepository, Evaluation evaluation)
        {
            var predicate = PredicateBuilder.New<Evaluation>(true);

            if(!evaluation.Id.Equals(Guid.Empty))
                predicate.And(p => p.Id != evaluation.Id);

            predicate.And(p => EF.Functions.Like(p.Name.Trim().ToLower(), evaluation.Name.Trim().ToLower()));

            var result = await EvaluationRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }

        public static async Task<bool> DateRangeIsValid(IEvaluationRepository EvaluationRepository, Evaluation evaluation)
        {
            var predicate = PredicateBuilder.New<Evaluation>(true);

            if (!evaluation.Id.Equals(Guid.Empty))
                predicate.And(p => p.Id != evaluation.Id);

            if (evaluation.StartDate > evaluation.EndDate)
                return false;

            predicate.And(p => (evaluation.StartDate >= p.StartDate && evaluation.StartDate <= p.EndDate) || (evaluation.EndDate >= p.StartDate && evaluation.EndDate <= p.EndDate));

            var result = await EvaluationRepository
                   .Find(predicate)
                   .ToListAsync();

            return !result.Any();
        }

        public static async Task<bool> DateRangeBetweenIsValid(IEvaluationRepository EvaluationRepository, Evaluation evaluation)
        {
            var predicate = PredicateBuilder.New<Evaluation>(true);

            if (!evaluation.Id.Equals(Guid.Empty))
                predicate.And(p => p.Id != evaluation.Id);

            if (evaluation.StartDate > evaluation.EndDate)
                return false;

            predicate.And(p => (p.StartDate >= evaluation.StartDate && p.StartDate <= evaluation.EndDate) || (p.EndDate >= evaluation.StartDate && p.EndDate <= evaluation.EndDate));

            var result = await EvaluationRepository
                   .Find(predicate)
                   .ToListAsync();

            return !result.Any();
        }
    }
}
