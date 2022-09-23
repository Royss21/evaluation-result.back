
namespace Domain.Main.Validadores.ColorValidaciones
{

    using Domain.Main.Validadores;
    using Domain.Common.Constantes;
    using FluentValidation;
    using Infrastructure.Main.Repositorios.Entidades.Interfaces;

    public class ColorCrearValidador : ValidadorBase<Color>
    {
        private readonly IColorRepositorio _ColorRepositorio;

        public ColorCrearValidador(IColorRepositorio ColorRepositorio) : base()
        {
            _ColorRepositorio = ColorRepositorio;

            RuleFor(x => x)
                .MustAsync((Color, cancel) => ColorValidadorCompartido.NombreUnico(_ColorRepositorio, Color))
                .WithMessage(Mensajes.General.NombreYaRegistrado);
        }
    }

    public class ColorActualizarValidador : ValidadorBase<Color>
    {
        private IColorRepositorio _ColorRepositorio;

        public ColorActualizarValidador(IColorRepositorio ColorRepositorio) : base()
        {
            _ColorRepositorio = ColorRepositorio;

            RuleFor(x => x)
                .MustAsync((Color, cancel) => ColorValidadorCompartido.NombreUnico(_ColorRepositorio, Color))
                .WithMessage(Mensajes.General.NombreYaRegistrado);
        }
    }

    public static class ColorValidadorCompartido
    {

        public static async Task<bool> NombreUnico(IColorRepositorio ColorRepositorio, Color Color)
        {
            var predicado = PredicateBuilder.New<Color>(true);

            if (Color.Id != 0)
                predicado.And(p => p.Id != Color.Id);

            predicado.And(x => EF.Functions.Like(x.Nombre.ToLower().Trim(), Color.Nombre.ToLower().Trim()));

            var resultado = await ColorRepositorio
                .Find(predicado)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return resultado is null ;
        }
    }
}
