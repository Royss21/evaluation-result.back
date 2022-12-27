namespace Application.Main.Services.Employee.Validators
{
    using Domain.Common.Constants;
    using Domain.Main.Base;
    using Domain.Main.Employee;
    using FluentValidation;
    using Infrastructure.Main.Repository.Employee.Interfaces;
    public class HierarchyCreateUpdateValidation : BaseValidator<Hierarchy>
    {
        private readonly IHierarchyRepository _hierarchyRepository;

        public HierarchyCreateUpdateValidation(IHierarchyRepository hierarchyRepository) : base()
        {
            _hierarchyRepository = hierarchyRepository;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x)
                .MustAsync((hierarchy, cancel) => NameExists(hierarchy))
                .WithMessage(Messages.General.NameAlreadyRegistered);

            RuleFor(x => x)
                .MustAsync((hierarchy, cancel) => HierarchySharedValidation.LevelRequired(hierarchy))
                .WithMessage(Messages.Hierarchy.LevelRequired);
        }

        async Task<bool> NameExists(Hierarchy hierarchy)
        {
            var predicate = PredicateBuilder.New<Hierarchy>(true);
            predicate.And(p => EF.Functions.Like(p.Name.Trim(), hierarchy.Name.Trim()));
            var result = await _hierarchyRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }
    }

    public static class HierarchySharedValidation
    {
        public static async Task<bool> LevelRequired(Hierarchy hierarchy)
        {
            if (hierarchy.LevelId <= 0)
                return false;

            return true;
        }
    }
}
