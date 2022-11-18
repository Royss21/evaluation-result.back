
namespace Application.Main.Services.Config.Validators
{
    using Domain.Common.Constants;
    using Domain.Main.Base;
    using Domain.Main.Config;
    using FluentValidation;
    using Infrastructure.Main.Repository.Config.Interfaces;

    public class LevelCreateUpdateValidator : BaseValidator<Level>
    {
        private readonly ILevelRepository _levelRepository;
        public LevelCreateUpdateValidator(ILevelRepository levelRepository) : base()
        {
            _levelRepository = levelRepository;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x)
                .MustAsync((level, cancel) => LevelSharedValidator.NameExists(_levelRepository, level))
                .WithMessage(Messages.General.NameAlreadyRegistered);
        }
    }

    public static class LevelSharedValidator
    {
        public static async Task<bool> NameExists(ILevelRepository levelRepository, Level level)
        {
            var predicate = PredicateBuilder.New<Level>(true);

            if(level.Id != 0)
                predicate.And(p => p.Id != level.Id);

            predicate.And(p => EF.Functions.Like(p.Name.Trim().ToLower(), level.Name.Trim().ToLower()));

            var result = await levelRepository
                   .Find(predicate)
                   .FirstOrDefaultAsync();

            return result is null;
        }
    }
}
