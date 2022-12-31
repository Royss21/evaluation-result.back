
namespace Domain.Main.Services.Security.Validators.EndpointValidators
{
    public class EndpointCrearValidador //: ValidadorBase<Endpoint>
    {
        //private readonly IEndpointRepositorio _endpointRepositorio;

        //public EndpointCrearValidador(IEndpointRepositorio endpointRepositorio) : base()
        //{
        //    _endpointRepositorio = endpointRepositorio;

        //    RuleFor(x => x)
        //        .MustAsync((endpoint, cancel) => EndpointValidadorCompartido.NombreRutaEndpoint(_endpointRepositorio, endpoint))
        //        .WithMessage(Mensajes.General.NombreYaRegistrado);
        //}
    }

    //public class EndpointActualizarValidador : ValidadorBase<Endpoint>
    //{
    //    private IEndpointRepositorio _endpointRepositorio;

    //    public EndpointActualizarValidador(IEndpointRepositorio endpointRepositorio) : base()
    //    {
    //        _endpointRepositorio = endpointRepositorio;

    //        RuleFor(x => x)
    //            .MustAsync((endpoint, cancel) => EndpointValidadorCompartido.NombreRutaEndpoint(_endpointRepositorio, endpoint))
    //            .WithMessage(Mensajes.General.NombreYaRegistrado);
    //    }
    //}

    //public static class EndpointValidadorCompartido
    //{
    //    public static async Task<bool> NombreRutaEndpoint(IEndpointRepositorio endpointRepositorio, Endpoint endpoint)
    //    {
    //        var predicado = PredicateBuilder.New<Endpoint>(true);

    //        if (endpoint.Id.Equals(Guid.Empty))
    //            predicado.And(p => p.Id.Equals(endpoint.Id));

    //        predicado.And(x => EF.Functions.Like(x.RutaEndpoint.Trim(), endpoint.RutaEndpoint.Trim()));

    //        var resultado = await endpointRepositorio
    //            .Find(predicado)
    //            .AsNoTracking()
    //            .FirstOrDefaultAsync();

    //        return resultado is null ;
    //    }
    //}
}
