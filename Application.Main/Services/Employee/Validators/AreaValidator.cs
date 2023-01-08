
namespace Application.Main.Services.Employee.Validators
{
    using Domain.Common.Constants;
    using Domain.Main.Base;
    using Domain.Main.Employee;
    using FluentValidation;
    using Infrastructure.Main.Repository.Employee.Interfaces;

    public class AreaCreateValidator : BaseValidator<Area>
    {
        private readonly IAreaRepository _areaRepository;
        public AreaCreateValidator(IAreaRepository areaRepository) : base()
        {
            _areaRepository = areaRepository;

            RuleFor(x => x)
                .MustAsync((area, cancel) => AreaSharedValidator.NameExists(_areaRepository, area))
                .WithMessage(Messages.General.NameAlreadyRegistered);
        }

        async Task<bool> NameExists(Area area)
        {
            var predicate = PredicateBuilder.New<Area>(true);
            predicate.And(p=> EF.Functions.Like(p.Name.Trim(), area.Name.Trim()));
            var result = await _areaRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }
    }

    public static class AreaSharedValidator
    {
        public static async Task<bool> NameExists(IAreaRepository areaRepository, Area area)
        {
            var predicate = PredicateBuilder.New<Area>(true);

            if (area.Id != 0)
                predicate.And(p => p.Id != area.Id);

            predicate.And(p => EF.Functions.Like(p.Name.Trim().ToLower(), area.Name.Trim().ToLower()));

            var result = await areaRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }
    }
}
