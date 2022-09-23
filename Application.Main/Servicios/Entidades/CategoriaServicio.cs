namespace Application.Main.Servicios.Entidades
{
    using Application.Dto.Entidades.Categoria;
    using Application.Main.Servicios.Entidades.Interfaces;
    using Domain.Common.Constantes;
    using Domain.Main.Validadores.CategoriaValidaciones;

    public class CategoriaServicio : BaseServicio, ICategoriaServicio
    {
        public CategoriaServicio(IServiceProvider serviceProvider) : base(serviceProvider)
        {}

        public async Task<bool> CrearAsync(CategoriaCrearDto request)
        {
            var categoria = _mapper.Map<Categoria>(request);

            var resultadoValidador = await _unitOfWorkApp.Repositorio.CategoriaRepositorio
                .AddAsync(categoria, new CategoriaCrearValidador(_unitOfWorkApp.Repositorio.CategoriaRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ActualizarAsync(CategoriaActualizarDto request)
        {
            var categoria = await _unitOfWorkApp.Repositorio.CategoriaRepositorio.GetAsync(request.Id);
            if (categoria is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            categoria.Nombre = request.Nombre;
            categoria.Codigo = request.Codigo;

            var resultadoValidador = await _unitOfWorkApp.Repositorio.CategoriaRepositorio
                .UpdateAsync(categoria, new CategoriaActualizarValidador(_unitOfWorkApp.Repositorio.CategoriaRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var categoria = await _unitOfWorkApp.Repositorio.CategoriaRepositorio.GetAsync(id);

            if (categoria is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            await _unitOfWorkApp.Repositorio.CategoriaRepositorio.DeleteAsync(categoria);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CategoriaDto>> ObtenerTodoAsync()
        {
            var categorias = await _unitOfWorkApp.Repositorio.CategoriaRepositorio
                    .All()
                    .ProjectTo<CategoriaDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return categorias;
        }
        public async Task<CategoriaDto> ObtenerPorIdAsync(int id)
        {
            var categoria = await _unitOfWorkApp.Repositorio.CategoriaRepositorio
                    .Find(c => c.Id == id)
                    .ProjectTo<CategoriaDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

            if (categoria is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            return categoria;
        }

        public async Task<PaginacionResultadoDto<CategoriaDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable)
        {
            var parametrosDto = PrimeNgToPaginationParametersDto<CategoriaDto>.Convert(primeTable);
            var parametrosDominio = parametrosDto.ConvertToPaginationParameterDomain<Categoria, CategoriaDto>(_mapper);

            //parametrosDominio.FiltroWhere = parametrosDominio.FiltroWhere.AddCondition(x => x.State == (int)StateEnum.Active);

            if (!string.IsNullOrWhiteSpace(primeTable.FiltroGlobal))
            {
                parametrosDominio.FiltroWhere = parametrosDominio.FiltroWhere
                        .AddCondition(add => add.Codigo.ToLower().Contains(primeTable.FiltroGlobal.ToLower()) ||
                                            add.Nombre.ToLower().Contains(primeTable.FiltroGlobal.ToLower()) ||
                                            add.Id.ToString().ToLower().Contains(primeTable.FiltroGlobal.ToLower()));
            }

            var paginado = await _unitOfWorkApp.Repositorio.CategoriaRepositorio.FindAllPagingAsync(parametrosDominio);
            var categorias = await paginado.Entidades.ProjectTo<CategoriaDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginacionResultadoDto<CategoriaDto>
            {
                Cantidad = paginado.Cantidad,
                Entidades = categorias
            };
        }
    }
}
