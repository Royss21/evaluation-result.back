
namespace Domain.Main.Validadores.CompaniaValidaciones
{

    using Domain.Main.Validadores;
    using Domain.Common.Constantes;
    using FluentValidation;
    using Infrastructure.Main.Repositorios.Entidades.Interfaces;

    public class CompaniaCrearValidador : ValidadorBase<Compania>
    {
        private readonly ICompaniaRepositorio _CompaniaRepositorio;

        public CompaniaCrearValidador(ICompaniaRepositorio CompaniaRepositorio) : base()
        {
            _CompaniaRepositorio = CompaniaRepositorio;

            RuleFor(x => x.Nombre)
                .NotEmpty()
                .WithMessage(Mensajes.General.NombreNoVacio);

            RuleFor(x => x)
                .MustAsync((Compania, cancel) => CompaniaValidadorCompartido.TelefonoUnico(_CompaniaRepositorio, Compania))
                .WithMessage(Mensajes.General.TelefonoYaRegistrado);

             RuleFor(x => x)
                .MustAsync((Compania, cancel) => CompaniaValidadorCompartido.MovilUnico(_CompaniaRepositorio, Compania))
                .WithMessage(Mensajes.General.MovilYaRegistrado);

            RuleFor(x => x)
                .MustAsync((Compania, cancel) => CompaniaValidadorCompartido.CorreoUnico(_CompaniaRepositorio, Compania))
                .WithMessage(Mensajes.General.CorreoYaRegistrado);

            RuleFor(x => x)
               .MustAsync((Compania, cancel) => CompaniaValidadorCompartido.NombreUnico(_CompaniaRepositorio, Compania))
               .WithMessage(Mensajes.General.NombreYaRegistrado);
        }
    }

    public class CompaniaActualizarValidador : ValidadorBase<Compania>
    {
        private ICompaniaRepositorio _CompaniaRepositorio;

        public CompaniaActualizarValidador(ICompaniaRepositorio CompaniaRepositorio) : base()
        {
            _CompaniaRepositorio = CompaniaRepositorio;

            RuleFor(x => x.Nombre)
                .NotEmpty()
                .WithMessage(Mensajes.General.NombreNoVacio);

            RuleFor(x => x)
                .MustAsync((Compania, cancel) => CompaniaValidadorCompartido.TelefonoUnico(_CompaniaRepositorio, Compania))
                .WithMessage(Mensajes.General.TelefonoYaRegistrado);

            RuleFor(x => x)
               .MustAsync((Compania, cancel) => CompaniaValidadorCompartido.MovilUnico(_CompaniaRepositorio, Compania))
               .WithMessage(Mensajes.General.MovilYaRegistrado);

            RuleFor(x => x)
                .MustAsync((Compania, cancel) => CompaniaValidadorCompartido.CorreoUnico(_CompaniaRepositorio, Compania))
                .WithMessage(Mensajes.General.CorreoYaRegistrado);

            RuleFor(x => x)
               .MustAsync((Compania, cancel) => CompaniaValidadorCompartido.NombreUnico(_CompaniaRepositorio, Compania))
               .WithMessage(Mensajes.General.NombreYaRegistrado);
        }
    }

    public static class CompaniaValidadorCompartido
    {

        public static async Task<bool> CorreoUnico(ICompaniaRepositorio companiaRepositorio, Compania compania)
        {
            if (string.IsNullOrWhiteSpace(compania.Correo))
                return true;

            var predicado = PredicateBuilder.New<Compania>(true);

            if (compania.Id.Equals(Guid.Empty))
                predicado.And(p => !p.Id.Equals(compania.Id));

            predicado.And(x => EF.Functions.Like(x.Correo.ToLower().Trim(), compania.Correo.ToLower().Trim()));

            var resultado = await companiaRepositorio
                .Find(predicado)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return resultado is null ;
        }

        public static async Task<bool> TelefonoUnico(ICompaniaRepositorio companiaRepositorio, Compania compania)
        {

            if (string.IsNullOrWhiteSpace(compania.Telefono))
                return true;

            var predicado = PredicateBuilder.New<Compania>(true);

            if (compania.Id.Equals(Guid.Empty))
                predicado.And(p => !p.Id.Equals(compania.Id));

            predicado.And(x => EF.Functions.Like(x.Telefono.Trim(), compania.Telefono.Trim()));

            var resultado = await companiaRepositorio
                .Find(predicado)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return resultado is null;
        }

        public static async Task<bool> MovilUnico(ICompaniaRepositorio companiaRepositorio, Compania compania)
        {

            if (string.IsNullOrWhiteSpace(compania.Movil))
                return true;

            var predicado = PredicateBuilder.New<Compania>(true);

            if (compania.Id.Equals(Guid.Empty))
                predicado.And(p => !p.Id.Equals(compania.Id));

            predicado.And(x => EF.Functions.Like(x.Movil.Trim(), compania.Movil.Trim()));

            var resultado = await companiaRepositorio
                .Find(predicado)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return resultado is null;
        }

        public static async Task<bool> NombreUnico(ICompaniaRepositorio companiaRepositorio, Compania compania)
        {

            var predicado = PredicateBuilder.New<Compania>(true);

            if (compania.Id.Equals(Guid.Empty))
                predicado.And(p => !p.Id.Equals(compania.Id));

            predicado.And(x => EF.Functions.Like(x.Nombre.ToLower().Trim(), compania.Nombre.ToLower().Trim()));

            var resultado = await companiaRepositorio
                .Find(predicado)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return resultado is null;
        }
    }
}
