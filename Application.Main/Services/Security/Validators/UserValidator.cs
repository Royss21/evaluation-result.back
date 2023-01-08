namespace Application.Main.Services.Security.Validators
{
    using Domain.Main.Base;
    using FluentValidation;
    using Domain.Main.Security;
    using Domain.Common.Constants;
    using Infrastructure.Main.Repository.Security.Interfaces;

    public class UserValidator : BaseValidator<User>
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
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

            RuleFor(x => x.Password)
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

    public static class UserSharedValidator
    {
        public static async Task<bool> UsernameExists(IUserRepository userRepository, User user)
        {
            var predicate = PredicateBuilder.New<User>(true);

            if (!user.Id.Equals(Guid.Empty))
                predicate.And(p => !p.Id.Equals(user.Id));

            predicate.And(p => EF.Functions.Like(p.Email.Trim().ToLower(), user.Email.Trim().ToLower()));

            var result = await userRepository
                    .Find(predicate)
                    .FirstOrDefaultAsync();

            return result is null;
        }

        public static async Task<bool> EmailExists(IUserRepository userRepository, User user)
        {
            var predicate = PredicateBuilder.New<User>(true);

            if (!user.Id.Equals(Guid.Empty))
                predicate.And(p => !p.Id.Equals(user.Id));

            predicate.And(p => EF.Functions.Like(p.Email.Trim().ToLower(), user.Email.Trim().ToLower()));

            var result = await userRepository
                    .Find(predicate)
                    .FirstOrDefaultAsync();

            return result is null;
        }
    }
}