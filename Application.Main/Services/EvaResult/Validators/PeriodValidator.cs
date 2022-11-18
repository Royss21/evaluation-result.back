
namespace Application.Main.Services.EvaResult.Validators
{
    using Domain.Common.Constants;
    using Domain.Main.Base;
    using Domain.Main.EvaResult;
    using FluentValidation;
    using Infrastructure.Main.Repository.EvaResult.Interfaces;

    public class PeriodCreateValidator : BaseValidator<Period>
    {
        private readonly IPeriodRepository _periodRepository;
        public PeriodCreateValidator(IPeriodRepository periodRepository) : base()
        {
            _periodRepository = periodRepository;

            RuleFor(x => x)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty)
                .MustAsync((period, cancel) => PeriodSharedValidator.NameExists( _periodRepository, period))
                .WithMessage(Messages.General.NameAlreadyRegistered)
                .MustAsync((period, cancel) => PeriodSharedValidator.DateRangeIsValid(_periodRepository, period))
                .WithMessage(Messages.General.RangeDatesIsNotValid);
        }
    }


    public static class PeriodSharedValidator
    {
        public static async Task<bool> NameExists(IPeriodRepository periodRepository, Period period)
        {
            var predicate = PredicateBuilder.New<Period>(true);

            if(period.Id != 0)
                predicate.And(p => p.Id != period.Id);

            predicate.And(p => EF.Functions.Like(p.Name.Trim().ToLower(), period.Name.Trim().ToLower()));

            var result = await periodRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }

        public static async Task<bool> DateRangeIsValid(IPeriodRepository periodRepository, Period period)
        {
            var predicate = PredicateBuilder.New<Period>(true);

            if (period.Id != 0)
                predicate.And(p => p.Id != period.Id);

            if (period.StartDate > period.EndDate)
                return false;

            predicate.And(p => (period.StartDate >= p.StartDate && period.StartDate <= p.EndDate) || (period.EndDate >= p.StartDate && period.EndDate <= p.EndDate));

            var result = await periodRepository
                   .Find(predicate)
                   .ToListAsync();

            return !result.Any();
        }
    }
}
