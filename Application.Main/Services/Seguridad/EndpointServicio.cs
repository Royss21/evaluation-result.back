namespace Application.Main.Servicios.Entidades
{
    public class EndpointServicio //: BaseService, IEndpointServicio
    {
        //public EndpointServicio(IServiceProvider serviceProvider) : base(serviceProvider)
        //{ }

        //public async Task<bool> CrearAsync(EndpointCrearDto request)
        //{
        //    var endpoint = _mapper.Map<Endpoint>(request);

        //    var resultadoValidador = await _unitOfWorkApp.Repositorio.EndpointRepositorio
        //        .AddAsync(endpoint, new EndpointCrearValidador(_unitOfWorkApp.Repositorio.EndpointRepositorio));

        //    if (!resultadoValidador.IsValid)
        //        throw new ValidatorException(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

        //    await _unitOfWorkApp.SaveChangesAsync();

        //    return true;
        //}
        //public async Task<bool> ActualizarAsync(EndpointActualizarDto request)
        //{
        //    var endpoint = await _unitOfWorkApp.Repositorio.EndpointRepositorio.GetAsync(request.Id);

        //    if (endpoint is null)
        //        throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

        //    endpoint.RutaEndpoint = request.RutaEndpoint;
        //    endpoint.Entidad = request.Entidad;
        //    endpoint.NombreControlador = request.NombreControlador;
        //    endpoint.NombreAccion = request.NombreAccion;
        //    endpoint.Metodo = request.Metodo;

        //    var resultadoValidador = await _unitOfWorkApp.Repositorio.EndpointRepositorio
        //        .UpdateAsync(endpoint, new EndpointActualizarValidador(_unitOfWorkApp.Repositorio.EndpointRepositorio));

        //    if (!resultadoValidador.IsValid)
        //        throw new ValidatorException(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

        //    await _unitOfWorkApp.SaveChangesAsync();

        //    return true;
        //}

        //public async Task<bool> EliminarAsync(Guid id)
        //{
        //    var endpoint = await _unitOfWorkApp.Repositorio.EndpointRepositorio.GetAsync(id);

        //    if (endpoint is null)
        //        throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

        //    await _unitOfWorkApp.Repositorio.EndpointRepositorio.DeleteAsync(endpoint);
        //    await _unitOfWorkApp.SaveChangesAsync();

        //    return true;
        //}

        //public async Task<IEnumerable<EndpointDto>> ObtenerTodoAsync()
        //{
        //    var Endpoints = await _unitOfWorkApp.Repositorio.EndpointRepositorio
        //            .All()
        //            .ProjectTo<EndpointDto>(_mapper.ConfigurationProvider)
        //            .ToListAsync();

        //    return Endpoints;
        //}
        //public async Task<EndpointDto> ObtenerPorIdAsync(Guid id)
        //{
        //    var endpoint = await _unitOfWorkApp.Repositorio.EndpointRepositorio
        //            .Find(c => c.Id.Equals(id))
        //            .ProjectTo<EndpointDto>(_mapper.ConfigurationProvider)
        //            .FirstOrDefaultAsync();

        //    if (endpoint is null)
        //        throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

        //    return endpoint;
        //}

        //public async Task<PaginacionResultadoDto<EndpointDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable)
        //{
        //    var parametrosDto = PrimeNgToPaginationParametersDto<EndpointDto>.Convert(primeTable);
        //    var parametrosDominio = parametrosDto.ConvertToPaginationParameterDomain<Endpoint, EndpointDto>(_mapper);

        //    parametrosDominio.FiltroWhere = parametrosDominio.FiltroWhere.AddCondition(x => x.State == (int)StateEnum.Active);

        //    var paginado = await _unitOfWorkApp.Repositorio.EndpointRepositorio.FindAllPagingAsync(parametrosDominio);
        //    var Endpoints = await paginado.Entidades.ProjectTo<EndpointDto>(_mapper.ConfigurationProvider).ToListAsync();

        //    return new PaginacionResultadoDto<EndpointDto>
        //    {
        //        Cantidad = paginado.Cantidad,
        //        Entidades = Endpoints
        //    };
        //}
    }
}
