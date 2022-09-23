namespace Application.Main.Servicios.Entidades
{
    using Application.Dto.Entidades.MarcaVehiculo;
    using Application.Main.Servicios.Entidades.Interfaces;
    using Domain.Common.Constantes;
    using Domain.Main.Validadores.MarcaVehiculoValidaciones;

    public class MarcaVehiculoServicio : BaseServicio, IMarcaVehiculoServicio
    {
        public MarcaVehiculoServicio(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<bool> CrearAsync(MarcaVehiculoCrearDto request)
        {
            var marcaVehiculo = _mapper.Map<MarcaVehiculo>(request);

            var resultadoValidador = await _unitOfWorkApp.Repositorio.MarcaVehiculoRepositorio
                .AddAsync(marcaVehiculo, new MarcaVehiculoCrearValidador(_unitOfWorkApp.Repositorio.MarcaVehiculoRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ActualizarAsync(MarcaVehiculoActualizarDto request)
        {
            var marcaVehiculo = await _unitOfWorkApp.Repositorio.MarcaVehiculoRepositorio.GetAsync(request.Id);

            if (marcaVehiculo is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            marcaVehiculo.Nombre = request.Nombre;

            var resultadoValidador = await _unitOfWorkApp.Repositorio.MarcaVehiculoRepositorio
                .UpdateAsync(marcaVehiculo, new MarcaVehiculoActualizarValidador(_unitOfWorkApp.Repositorio.MarcaVehiculoRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var marcaVehiculo = await _unitOfWorkApp.Repositorio.MarcaVehiculoRepositorio.GetAsync(id);

            if (marcaVehiculo is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            await _unitOfWorkApp.Repositorio.MarcaVehiculoRepositorio.DeleteAsync(marcaVehiculo);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<MarcaVehiculoDto>> ObtenerTodoAsync()
        {
            return await _unitOfWorkApp.Repositorio.MarcaVehiculoRepositorio
                    .All()
                    .ProjectTo<MarcaVehiculoDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }
        public async Task<MarcaVehiculoDto> ObtenerPorIdAsync(int id)
        {
            var marcaVehiculo = await _unitOfWorkApp.Repositorio.MarcaVehiculoRepositorio
                    .Find(c => c.Id == id)
                    .ProjectTo<MarcaVehiculoDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

            if (marcaVehiculo is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            return marcaVehiculo;
        }

        public async Task<PaginacionResultadoDto<MarcaVehiculoDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable)
        {
            var parametrosDto = PrimeNgToPaginationParametersDto<MarcaVehiculoDto>.Convert(primeTable);
            var parametrosDominio = parametrosDto.ConvertToPaginationParameterDomain<MarcaVehiculo, MarcaVehiculoDto>(_mapper);

            // parametrosDominio.FiltroWhere = parametrosDominio.FiltroWhere.AddCondition(x => x.State == (int)StateEnum.Active);

            var paginado = await _unitOfWorkApp.Repositorio.MarcaVehiculoRepositorio.FindAllPagingAsync(parametrosDominio);
            var marcaVehiculos = await paginado.Entidades.ProjectTo<MarcaVehiculoDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginacionResultadoDto<MarcaVehiculoDto>
            {
                Cantidad = paginado.Cantidad,
                Entidades = marcaVehiculos
            };
        }
    }
}
