
namespace Domain.Main.Validadores.OperadoraTelefonoValidaciones
{

    using Domain.Main.Validadores;
    using Domain.Common.Constantes;
    using FluentValidation;
    using Infrastructure.Main.Repositorios.Entidades.Interfaces;

    public class OperadoraTelefonoCrearValidador : ValidadorBase<OperadoraTelefono>
    {
        private readonly IOperadoraTelefonoRepositorio _operadoraTelefonoRepositorio;

        public OperadoraTelefonoCrearValidador(IOperadoraTelefonoRepositorio operadoraTelefonoRepositorio) : base()
        {
            _operadoraTelefonoRepositorio = operadoraTelefonoRepositorio;

            RuleFor(x => x)
                .MustAsync((OperadoraTelefono, cancel) => OperadoraTelefonoValidadorCompartido.NombreUnico(_operadoraTelefonoRepositorio, OperadoraTelefono))
                .WithMessage(Mensajes.General.NombreYaRegistrado);
        }
    }

    public class OperadoraTelefonoActualizarValidador : ValidadorBase<OperadoraTelefono>
    {
        private IOperadoraTelefonoRepositorio _operadoraTelefonoRepositorio;

        public OperadoraTelefonoActualizarValidador(IOperadoraTelefonoRepositorio operadoraTelefonoRepositorio) : base()
        {
            _operadoraTelefonoRepositorio = operadoraTelefonoRepositorio;

            RuleFor(x => x)
                .MustAsync((OperadoraTelefono, cancel) => OperadoraTelefonoValidadorCompartido.NombreUnico(_operadoraTelefonoRepositorio, OperadoraTelefono))
                .WithMessage(Mensajes.General.NombreYaRegistrado);
        }
    }

    public static class OperadoraTelefonoValidadorCompartido
    {

        public static async Task<bool> NombreUnico(IOperadoraTelefonoRepositorio OperadoraTelefonoRepositorio, OperadoraTelefono operadoraTelefono)
        {
            var predicado = PredicateBuilder.New<OperadoraTelefono>(true);

            if (operadoraTelefono.Id != 0)
                predicado.And(p => p.Id != operadoraTelefono.Id);

            predicado.And(x => EF.Functions.Like(x.Nombre.ToLower().Trim(), operadoraTelefono.Nombre.ToLower().Trim()));

            var resultado = await OperadoraTelefonoRepositorio
                .Find(predicado)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return resultado is null ;
        }
    }
}
