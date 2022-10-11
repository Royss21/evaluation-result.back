
namespace Application.Main.Services.Config.Validators
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
                .MustAsync((area, cancel) => NameExists(area))
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
}
