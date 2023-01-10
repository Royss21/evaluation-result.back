namespace Application.Main.Services.Security.Validators
{
    using Domain.Main.Base;
    using FluentValidation;
    using Domain.Main.Security;
    using Domain.Common.Constants;
    using Infrastructure.Main.Repository.Security.Interfaces;
    public class UserUpdateValidator : BaseValidator<User>
    {
        private readonly IUserRepository _userRepository;

        public UserUpdateValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.Names)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x.MiddleName)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x)
                .MustAsync((user, cancel) => UserSharedValidator.EmailExists(_userRepository, user))
                .WithMessage(Messages.General.EmailAlreadyRegistered);


            RuleFor(x => x)
                .MustAsync((user, cancel) => UserSharedValidator.UsernameExists(_userRepository, user))
                .WithMessage(Messages.User.UsernameAlreadyRegistered);
        }
    }
}
