
namespace Application.Main.Services.Employee.Validators
{
    using Domain.Main.Base;
    using FluentValidation;
    using Domain.Main.Employee;
    using Domain.Common.Constants;
    using Infrastructure.Main.Repository.Employee.Interfaces;

    public class CollaboratorCreateUpdateValidation : BaseValidator<Collaborator>
    {
        private readonly ICollaboratorRepository _collaboratorNotInRepository;

        public CollaboratorCreateUpdateValidation(ICollaboratorRepository collaboratorNotInRepository) : base()
        {
            _collaboratorNotInRepository = collaboratorNotInRepository;

            RuleFor(x => x.Name)
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

            RuleFor(x => x.DocumentNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x.DateAdmission)
                .NotNull()
                .NotEmpty()
                .WithMessage(Messages.General.FieldNonEmpty);

            RuleFor(x => x)
                .MustAsync((collaborator, cancel) => CollaboratorSharedValidator.EmailExists(_collaboratorNotInRepository, collaborator))
                .WithMessage(Messages.General.EmailAlreadyRegistered);

            RuleFor(x => x)
                .MustAsync((collaborator, cancel) => CollaboratorSharedValidator.ChargeRequired(collaborator))
                .WithMessage(Messages.Collaborator.ChargeRequired);

        }
    }

    public static class CollaboratorSharedValidator
    {
        public static async Task<bool> EmailExists(ICollaboratorRepository collaboratorNotInRepository, Collaborator collaborator)
        {
            var predicate = PredicateBuilder.New<Collaborator>(true);

            if (!collaborator.Id.Equals(Guid.Empty))
                predicate.And(p => !p.Id.Equals(collaborator.Id));

            predicate.And(p => EF.Functions.Like(p.Email.Trim().ToLower(), collaborator.Email.Trim().ToLower()));

            var result = await collaboratorNotInRepository
                    .Find(predicate)
                    .FirstOrDefaultAsync();

            return result is null;
        }

        public static async Task<bool> DocumentNumberExists(ICollaboratorRepository collaboratorNotInRepository, Collaborator collaborator)
        {
            var predicate = PredicateBuilder.New<Collaborator>(true);

            if (!collaborator.Id.Equals(Guid.Empty))
                predicate.And(p => !p.Id.Equals(collaborator.Id));

            predicate.And(p => EF.Functions.Like(p.DocumentNumber.Trim().ToLower(), collaborator.DocumentNumber.Trim().ToLower()));

            var result = await collaboratorNotInRepository
                    .Find(predicate)
                    .FirstOrDefaultAsync();

            return result is null;
        }

        public static async Task<bool> ChargeRequired(Collaborator collaborator)
        {
            if (collaborator.ChargeId <= 0)
                return false;

            return true;
        }
    }

}
