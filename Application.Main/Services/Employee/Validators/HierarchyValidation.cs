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
                .MustAsync((hierarchy, cancel) => HierarchySharedValidation.NameExists(_hierarchyRepository, hierarchy))
                .WithMessage(Messages.General.NameAlreadyRegistered);

            RuleFor(x => x)
                .MustAsync((hierarchy, cancel) => HierarchySharedValidation.LevelRequired(hierarchy))
                .WithMessage(Messages.Hierarchy.LevelRequired);
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

        public static async Task<bool> NameExists(IHierarchyRepository hierarchyRepository, Hierarchy hierarchy)
        {
            var predicate = PredicateBuilder.New<Hierarchy>(true);

            if (hierarchy.Id != 0)
                predicate.And(p => p.Id != hierarchy.Id);

            predicate.And(p => EF.Functions.Like(p.Name.Trim().ToLower(), hierarchy.Name.Trim().ToLower()));

            var result = await hierarchyRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }
    }
}
