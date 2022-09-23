
namespace Domain.Main.Validadores.TipoVehiculoValidaciones
{

    using Domain.Main.Validadores;
    using Domain.Common.Constantes;
    using FluentValidation;
    using Infrastructure.Main.Repositorios.Entidades.Interfaces;

    public class TipoVehiculoCrearValidador : ValidadorBase<TipoVehiculo>
    {
        private readonly ITipoVehiculoRepositorio _tipoVehiculoRepositorio;

        public TipoVehiculoCrearValidador(ITipoVehiculoRepositorio TipoVehiculoRepositorio) : base()
        {
            _tipoVehiculoRepositorio = TipoVehiculoRepositorio;

            RuleFor(x => x)
                .MustAsync((TipoVehiculo, cancel) => TipoVehiculoValidadorCompartido.NombreUnico(_tipoVehiculoRepositorio, TipoVehiculo))
                .WithMessage(Mensajes.General.NombreYaRegistrado);
        }
    }

    public class TipoVehiculoActualizarValidador : ValidadorBase<TipoVehiculo>
    {
        private ITipoVehiculoRepositorio _tipoVehiculoRepositorio;

        public TipoVehiculoActualizarValidador(ITipoVehiculoRepositorio TipoVehiculoRepositorio) : base()
        {
            _tipoVehiculoRepositorio = TipoVehiculoRepositorio;

            RuleFor(x => x)
                .MustAsync((TipoVehiculo, cancel) => TipoVehiculoValidadorCompartido.NombreUnico(_tipoVehiculoRepositorio, TipoVehiculo))
                .WithMessage(Mensajes.General.NombreYaRegistrado);
        }
    }

    public static class TipoVehiculoValidadorCompartido
    {

        public static async Task<bool> NombreUnico(ITipoVehiculoRepositorio TipoVehiculoRepositorio, TipoVehiculo TipoVehiculo)
        {
            var predicado = PredicateBuilder.New<TipoVehiculo>(true);

            if (TipoVehiculo.Id != 0)
                predicado.And(p => p.Id != TipoVehiculo.Id);

            predicado.And(x => EF.Functions.Like(x.Nombre.ToLower().Trim(), TipoVehiculo.Nombre.ToLower().Trim()));

            var resultado = await TipoVehiculoRepositorio
                .Find(predicado)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return resultado is null ;
        }
    }
}
