namespace Application.Main.Servicios.Entidades
{
    using Application.Dto.Entidades.Compania;
    using Application.Main.Servicios.Entidades.Interfaces;
    using Domain.Common.Constantes;
    using Domain.Main.Validadores.CompaniaValidaciones;

    public class CompaniaServicio : BaseServicio, ICompaniaServicio
    {
        public CompaniaServicio(IServiceProvider serviceProvider) : base(serviceProvider)
        {}

        public async Task<bool> CrearAsync(CompaniaCrearDto request)
        {
            var Compania = _mapper.Map<Compania>(request);

            var resultadoValidador = await _unitOfWorkApp.Repositorio.CompaniaRepositorio
                .AddAsync(Compania, new CompaniaCrearValidador(_unitOfWorkApp.Repositorio.CompaniaRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ActualizarAsync(CompaniaActualizarDto request)
        {
            var compania = await _unitOfWorkApp.Repositorio.CompaniaRepositorio.GetAsync(request.Id);

            if (compania is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            compania.Direccion = request.Direccion;
            compania.Correo = request.Correo;
            compania.Contenedor = request.Contenedor;
            compania.Movil = request.Movil;
            compania.Nombre = request.Nombre;
            compania.Telefono = request.Telefono;

            var resultadoValidador = await _unitOfWorkApp.Repositorio.CompaniaRepositorio
                .UpdateAsync(compania, new CompaniaActualizarValidador(_unitOfWorkApp.Repositorio.CompaniaRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EliminarAsync(Guid id)
        {
            var compania = await _unitOfWorkApp.Repositorio.CompaniaRepositorio.GetAsync(id);

            if (compania is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            await _unitOfWorkApp.Repositorio.CompaniaRepositorio.DeleteAsync(compania);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CompaniaDto>> ObtenerTodoAsync()
        {
            var companias = await _unitOfWorkApp.Repositorio.CompaniaRepositorio
                    .All()
                    .ProjectTo<CompaniaDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return companias;
        }
        public async Task<CompaniaDto> ObtenerPorIdAsync(Guid id)
        {
            var compania = await _unitOfWorkApp.Repositorio.CompaniaRepositorio
                    .Find(c => c.Id.Equals(id))
                    .ProjectTo<CompaniaDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

            if (compania is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            return compania;
        }

        public async Task<PaginacionResultadoDto<CompaniaDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable)
        {
            var parametrosDto = PrimeNgToPaginationParametersDto<CompaniaDto>.Convert(primeTable);
            var parametrosDominio = parametrosDto.ConvertToPaginationParameterDomain<Compania, CompaniaDto>(_mapper);

            // parametrosDominio.FiltroWhere = parametrosDominio.FiltroWhere.AddCondition(x => x.State == (int)StateEnum.Active);

            var paginado = await _unitOfWorkApp.Repositorio.CompaniaRepositorio.FindAllPagingAsync(parametrosDominio);
            var Companias = await paginado.Entidades.ProjectTo<CompaniaDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginacionResultadoDto<CompaniaDto>
            {
                Cantidad = paginado.Cantidad,
                Entidades = Companias
            };
        }
    }
}
