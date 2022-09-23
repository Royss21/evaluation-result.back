namespace Application.Main.Servicios.Entidades
{
    using Application.Dto.Entidades.Color;
    using Application.Main.Servicios.Entidades.Interfaces;
    using Domain.Common.Constantes;
    using Domain.Main.Validadores.ColorValidaciones;

    public class ColorServicio : BaseServicio, IColorServicio
    {
        public ColorServicio(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<bool> CrearAsync(ColorCrearDto request)
        {
            var Color = _mapper.Map<Color>(request);

            var resultadoValidador = await _unitOfWorkApp.Repositorio.ColorRepositorio
                .AddAsync(Color, new ColorCrearValidador(_unitOfWorkApp.Repositorio.ColorRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ActualizarAsync(ColorActualizarDto request)
        {
            var color = await _unitOfWorkApp.Repositorio.ColorRepositorio.GetAsync(request.Id);

            if (color is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            color.Nombre = request.Nombre;

            var resultadoValidador = await _unitOfWorkApp.Repositorio.ColorRepositorio
                .UpdateAsync(color, new ColorActualizarValidador(_unitOfWorkApp.Repositorio.ColorRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var color = await _unitOfWorkApp.Repositorio.ColorRepositorio.GetAsync(id);

            if (color is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            await _unitOfWorkApp.Repositorio.ColorRepositorio.DeleteAsync(color);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ColorDto>> ObtenerTodoAsync()
        {
            var Colors = await _unitOfWorkApp.Repositorio.ColorRepositorio
                    .All()
                    .ProjectTo<ColorDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return Colors;
        }
        public async Task<ColorDto> ObtenerPorIdAsync(int id)
        {
            var color = await _unitOfWorkApp.Repositorio.ColorRepositorio
                    .Find(c => c.Id == id)
                    .ProjectTo<ColorDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

            if (color is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            return color;
        }

        public async Task<PaginacionResultadoDto<ColorDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable)
        {
            var parametrosDto = PrimeNgToPaginationParametersDto<ColorDto>.Convert(primeTable);
            var parametrosDominio = parametrosDto.ConvertToPaginationParameterDomain<Color, ColorDto>(_mapper);

            // parametrosDominio.FiltroWhere = parametrosDominio.FiltroWhere.AddCondition(x => x.State == (int)StateEnum.Active);

            var paginado = await _unitOfWorkApp.Repositorio.ColorRepositorio.FindAllPagingAsync(parametrosDominio);
            var Colors = await paginado.Entidades.ProjectTo<ColorDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginacionResultadoDto<ColorDto>
            {
                Cantidad = paginado.Cantidad,
                Entidades = Colors
            };
        }
    }
}
