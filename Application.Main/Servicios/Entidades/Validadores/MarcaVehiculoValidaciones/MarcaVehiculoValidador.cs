
namespace Domain.Main.Validadores.MarcaVehiculoValidaciones
{

    using Domain.Main.Validadores;
    using Domain.Common.Constantes;
    using FluentValidation;
    using Infrastructure.Main.Repositorios.Entidades.Interfaces;

    public class MarcaVehiculoCrearValidador : ValidadorBase<MarcaVehiculo>
    {
        private readonly IMarcaVehiculoRepositorio _marcaVehiculoRepositorio;

        public MarcaVehiculoCrearValidador(IMarcaVehiculoRepositorio marcaVehiculoRepositorio) : base()
        {
            _marcaVehiculoRepositorio = marcaVehiculoRepositorio;

            RuleFor(x => x)
                .MustAsync((MarcaVehiculo, cancel) => MarcaVehiculoValidadorCompartido.NombreUnico(_marcaVehiculoRepositorio, MarcaVehiculo))
                .WithMessage(Mensajes.General.NombreYaRegistrado);
        }
    }

    public class MarcaVehiculoActualizarValidador : ValidadorBase<MarcaVehiculo>
    {
        private IMarcaVehiculoRepositorio _marcaVehiculoRepositorio;

        public MarcaVehiculoActualizarValidador(IMarcaVehiculoRepositorio marcaVehiculoRepositorio) : base()
        {
            _marcaVehiculoRepositorio = marcaVehiculoRepositorio;

            RuleFor(x => x)
                .MustAsync((MarcaVehiculo, cancel) => MarcaVehiculoValidadorCompartido.NombreUnico(_marcaVehiculoRepositorio, MarcaVehiculo))
                .WithMessage(Mensajes.General.NombreYaRegistrado);
        }
    }

    public static class MarcaVehiculoValidadorCompartido
    {

        public static async Task<bool> NombreUnico(IMarcaVehiculoRepositorio marcaVehiculoRepositorio, MarcaVehiculo MarcaVehiculo)
        {
            var predicado = PredicateBuilder.New<MarcaVehiculo>(true);

            if (MarcaVehiculo.Id != 0)
                predicado.And(p => p.Id != MarcaVehiculo.Id);

            predicado.And(x => EF.Functions.Like(x.Nombre.ToLower().Trim(), MarcaVehiculo.Nombre.ToLower().Trim()));

            var resultado = await marcaVehiculoRepositorio
                .Find(predicado)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return resultado is null ;
        }
    }
}
