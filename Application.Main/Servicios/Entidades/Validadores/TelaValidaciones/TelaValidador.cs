
namespace Domain.Main.Validadores.TelaValidaciones
{

    using Domain.Main.Validadores;
    using Domain.Common.Constantes;
    using FluentValidation;
    using Infrastructure.Main.Repositorios.Entidades.Interfaces;

    public class TelaCrearValidador : ValidadorBase<Tela>
    {
        private readonly ITelaRepositorio _telaRepositorio;

        public TelaCrearValidador(ITelaRepositorio telaRepositorio) : base()
        {
            _telaRepositorio = telaRepositorio;

            RuleFor(x => x)
                .MustAsync((Tela, cancel) => TelaValidadorCompartido.NombreUnico(_telaRepositorio, Tela))
                .WithMessage(Mensajes.General.NombreYaRegistrado);
        }
    }

    public class TelaActualizarValidador : ValidadorBase<Tela>
    {
        private ITelaRepositorio _telaRepositorio;

        public TelaActualizarValidador(ITelaRepositorio telaRepositorio) : base()
        {
            _telaRepositorio = telaRepositorio;

            RuleFor(x => x)
                .MustAsync((Tela, cancel) => TelaValidadorCompartido.NombreUnico(_telaRepositorio, Tela))
                .WithMessage(Mensajes.General.NombreYaRegistrado);
        }
    }

    public static class TelaValidadorCompartido
    {

        public static async Task<bool> NombreUnico(ITelaRepositorio telaRepositorio, Tela tela)
        {
            var predicado = PredicateBuilder.New<Tela>(true);

            if (tela.Id != 0)
                predicado.And(p => p.Id != tela.Id);

            predicado.And(x => EF.Functions.Like(x.Nombre.ToLower().Trim(), tela.Nombre.ToLower().Trim()));

            var resultado = await telaRepositorio
                .Find(predicado)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return resultado is null ;
        }
    }
}
