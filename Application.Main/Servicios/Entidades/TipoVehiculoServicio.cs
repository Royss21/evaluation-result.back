namespace Application.Main.Servicios.Entidades
{
    using Application.Dto.Entidades.TipoVehiculo;
    using Application.Main.Servicios.Entidades.Interfaces;
    using Domain.Common.Constantes;
    using Domain.Main.Validadores.TipoVehiculoValidaciones;

    public class TipoVehiculoServicio : BaseServicio, ITipoVehiculoServicio
    {
        public TipoVehiculoServicio(IServiceProvider serviceProvider) : base(serviceProvider)
        {}

        public async Task<bool> CrearAsync(TipoVehiculoCrearDto request)
        {
            var tipoVehiculo = _mapper.Map<TipoVehiculo>(request);

            var resultadoValidador = await _unitOfWorkApp.Repositorio.TipoVehiculoRepositorio
                .AddAsync(tipoVehiculo, new TipoVehiculoCrearValidador(_unitOfWorkApp.Repositorio.TipoVehiculoRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ActualizarAsync(TipoVehiculoActualizarDto request)
        {
            var tipoVehiculo = await _unitOfWorkApp.Repositorio.TipoVehiculoRepositorio.GetAsync(request.Id);

            if (tipoVehiculo is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            tipoVehiculo.Nombre = request.Nombre;

            var resultadoValidador = await _unitOfWorkApp.Repositorio.TipoVehiculoRepositorio
                .UpdateAsync(_mapper.Map<TipoVehiculo>(request), new TipoVehiculoActualizarValidador(_unitOfWorkApp.Repositorio.TipoVehiculoRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var tipoVehiculo = await _unitOfWorkApp.Repositorio.TipoVehiculoRepositorio.GetAsync(id);

            if (tipoVehiculo is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            await _unitOfWorkApp.Repositorio.TipoVehiculoRepositorio.DeleteAsync(tipoVehiculo);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TipoVehiculoDto>> ObtenerTodoAsync()
        {
            var tipoVehiculos = await _unitOfWorkApp.Repositorio.TipoVehiculoRepositorio
                    .All()
                    .ProjectTo<TipoVehiculoDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return tipoVehiculos;
        }
        public async Task<TipoVehiculoDto> ObtenerPorIdAsync(int id)
        {
            var tipoVehiculo = await _unitOfWorkApp.Repositorio.TipoVehiculoRepositorio
                    .Find(c => c.Id == id)
                    .ProjectTo<TipoVehiculoDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

            if (tipoVehiculo is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            return tipoVehiculo;
        }

        public async Task<PaginacionResultadoDto<TipoVehiculoDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable)
        {
            var parametrosDto = PrimeNgToPaginationParametersDto<TipoVehiculoDto>.Convert(primeTable);
            var parametrosDominio = parametrosDto.ConvertToPaginationParameterDomain<TipoVehiculo, TipoVehiculoDto>(_mapper);

            // parametrosDominio.FiltroWhere = parametrosDominio.FiltroWhere.AddCondition(x => x.State == (int)StateEnum.Active);

            var paginado = await _unitOfWorkApp.Repositorio.TipoVehiculoRepositorio.FindAllPagingAsync(parametrosDominio);
            var tipoVehiculos = await paginado.Entidades.ProjectTo<TipoVehiculoDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginacionResultadoDto<TipoVehiculoDto>
            {
                Cantidad = paginado.Cantidad,
                Entidades = tipoVehiculos
            };
        }
    }
}
