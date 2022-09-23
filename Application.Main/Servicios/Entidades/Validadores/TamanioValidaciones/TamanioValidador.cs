
namespace Domain.Main.Validadores.TamanioValidaciones
{

    using Domain.Main.Validadores;
    using Domain.Common.Constantes;
    using FluentValidation;
    using Infrastructure.Main.Repositorios.Entidades.Interfaces;

    public class TamanioCrearValidador : ValidadorBase<Tamanio>
    {
        private readonly ITamanioRepositorio _tamanioRepositorio;

        public TamanioCrearValidador(ITamanioRepositorio tamanioRepositorio) : base()
        {
            _tamanioRepositorio = tamanioRepositorio;

            RuleFor(x => x)
                .MustAsync((Tamanio, cancel) => TamanioValidadorCompartido.NombreUnico(_tamanioRepositorio, Tamanio))
                .WithMessage(Mensajes.General.NombreYaRegistrado);

             RuleFor(x => x)
                .MustAsync((Tamanio, cancel) => TamanioValidadorCompartido.CodigoUnico(_tamanioRepositorio, Tamanio))
                .WithMessage(Mensajes.General.AbreviaturaYaRegistrado);
        }
    }

    public class TamanioActualizarValidador : ValidadorBase<Tamanio>
    {
        private ITamanioRepositorio _tamanioRepositorio;

        public TamanioActualizarValidador(ITamanioRepositorio tamanioRepositorio) : base()
        {
            _tamanioRepositorio = tamanioRepositorio;

            RuleFor(x => x)
                .MustAsync((Tamanio, cancel) => TamanioValidadorCompartido.NombreUnico(_tamanioRepositorio, Tamanio))
                .WithMessage(Mensajes.General.NombreYaRegistrado);

            RuleFor(x => x)
                .MustAsync((Tamanio, cancel) => TamanioValidadorCompartido.CodigoUnico(_tamanioRepositorio, Tamanio))
                .WithMessage(Mensajes.General.AbreviaturaYaRegistrado);
        }
    }

    public static class TamanioValidadorCompartido
    {

        public static async Task<bool> NombreUnico(ITamanioRepositorio TamanioRepositorio, Tamanio Tamanio)
        {
            var predicado = PredicateBuilder.New<Tamanio>(true);

            if (Tamanio.Id != 0)
                predicado.And(p => p.Id != Tamanio.Id);

            predicado.And(x => EF.Functions.Like(x.Nombre.ToLower().Trim(), Tamanio.Nombre.ToLower().Trim()));

            var resultado = await TamanioRepositorio
                .Find(predicado)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return resultado is null ;
        }

        public static async Task<bool> CodigoUnico(ITamanioRepositorio TamanioRepositorio, Tamanio Tamanio)
        {

            if (string.IsNullOrWhiteSpace(Tamanio.Codigo))
                return true;

            var predicado = PredicateBuilder.New<Tamanio>(true);

            if (Tamanio.Id != 0)
                predicado.And(p => p.Id != Tamanio.Id);

            predicado.And(x => EF.Functions.Like(x.Codigo.ToLower().Trim(), Tamanio.Codigo.ToLower().Trim()));

            var resultado = await TamanioRepositorio
                .Find(predicado)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return resultado is null;
        }
    }
}
