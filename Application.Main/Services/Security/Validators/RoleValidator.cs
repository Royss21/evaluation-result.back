namespace Application.Main.Services.Security.Validators
{
    using Domain.Main.Base;
    using FluentValidation;
    using Domain.Main.Security;
    using Domain.Common.Constants;
    using Infrastructure.Main.Repository.Security.Interfaces;

    public class RoleValidator : BaseValidator<Role>
    {
        private readonly IRoleRepository _roleRepository;

        public RoleValidator(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x.Description)
                .MaximumLength(400)
                .WithMessage(Messages.General.FieldMaxLength);

        }
    }
}
