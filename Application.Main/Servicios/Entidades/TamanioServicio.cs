namespace Application.Main.Servicios.Entidades
{
    using Application.Dto.Entidades.Tamanio;
    using Application.Main.Servicios.Entidades.Interfaces;
    using Domain.Common.Constantes;
    using Domain.Main.Validadores.TamanioValidaciones;

    public class TamanioServicio : BaseServicio, ITamanioServicio
    {
        public TamanioServicio(IServiceProvider serviceProvider) : base(serviceProvider)
        {}

        public async Task<bool> CrearAsync(TamanioCrearDto request)
        {
            var tamanio = _mapper.Map<Tamanio>(request);

            var resultadoValidador = await _unitOfWorkApp.Repositorio.TamanioRepositorio
                .AddAsync(tamanio, new TamanioCrearValidador(_unitOfWorkApp.Repositorio.TamanioRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ActualizarAsync(TamanioActualizarDto request)
        {
            var tamanio = await _unitOfWorkApp.Repositorio.TamanioRepositorio.GetAsync(request.Id);

            if (tamanio is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            tamanio.Nombre = request.Nombre;
            tamanio.Codigo = request.Codigo;

            var resultadoValidador = await _unitOfWorkApp.Repositorio.TamanioRepositorio
                .UpdateAsync(tamanio, new TamanioActualizarValidador(_unitOfWorkApp.Repositorio.TamanioRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var tamanio = await _unitOfWorkApp.Repositorio.TamanioRepositorio.GetAsync(id);

            if (tamanio is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            await _unitOfWorkApp.Repositorio.TamanioRepositorio.DeleteAsync(tamanio);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TamanioDto>> ObtenerTodoAsync()
        {
            var Tamanios = await _unitOfWorkApp.Repositorio.TamanioRepositorio
                    .All()
                    .ProjectTo<TamanioDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return Tamanios;
        }
        public async Task<TamanioDto> ObtenerPorIdAsync(int id)
        {
            var tamanio = await _unitOfWorkApp.Repositorio.TamanioRepositorio
                    .Find(c => c.Id == id)
                    .ProjectTo<TamanioDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

            if (tamanio is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            return tamanio;
        }

        public async Task<PaginacionResultadoDto<TamanioDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable)
        {
            var parametrosDto = PrimeNgToPaginationParametersDto<TamanioDto>.Convert(primeTable);
            var parametrosDominio = parametrosDto.ConvertToPaginationParameterDomain<Tamanio, TamanioDto>(_mapper);

            // parametrosDominio.FiltroWhere = parametrosDominio.FiltroWhere.AddCondition(x => x.State == (int)StateEnum.Active);

            var paginado = await _unitOfWorkApp.Repositorio.TamanioRepositorio.FindAllPagingAsync(parametrosDominio);
            var Tamanios = await paginado.Entidades.ProjectTo<TamanioDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginacionResultadoDto<TamanioDto>
            {
                Cantidad = paginado.Cantidad,
                Entidades = Tamanios
            };
        }
    }
}
