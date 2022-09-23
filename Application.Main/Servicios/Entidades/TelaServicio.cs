namespace Application.Main.Servicios.Entidades
{
    using Application.Dto.Entidades.Tela;
    using Application.Main.Servicios.Entidades.Interfaces;
    using Domain.Common.Constantes;
    using Domain.Main.Validadores.TelaValidaciones;

    public class TelaServicio : BaseServicio, ITelaServicio
    {
        public TelaServicio(IServiceProvider serviceProvider) : base(serviceProvider)
        {}

        public async Task<bool> CrearAsync(TelaCrearDto request)
        {
            var tela = _mapper.Map<Tela>(request);

            var resultadoValidador = await _unitOfWorkApp.Repositorio.TelaRepositorio
                .AddAsync(tela, new TelaCrearValidador(_unitOfWorkApp.Repositorio.TelaRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

            var telaColores =  _mapper.Map<List<TelaColor>>(request.TelaColores);
            telaColores.ForEach(tc => tc.TelaId = tela.Id);

            await _unitOfWorkApp.Repositorio.TelaColorRepositorio.AddRangeAsync(telaColores);

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ActualizarAsync(TelaActualizarDto request)
        {
            var tela = await _unitOfWorkApp.Repositorio.TelaRepositorio.GetAsync(request.Id);

            if (tela is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            tela.Nombre = request.Nombre;
            tela.EsTematica = request.EsTematica;

            var resultadoValidador = await _unitOfWorkApp.Repositorio.TelaRepositorio
                .UpdateAsync(tela, new TelaActualizarValidador(_unitOfWorkApp.Repositorio.TelaRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));


            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var tela = await _unitOfWorkApp.Repositorio.TelaRepositorio.GetAsync(id);

            if (tela is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            await _unitOfWorkApp.Repositorio.TelaRepositorio.DeleteAsync(tela);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TelaDto>> ObtenerTodoAsync()
        {
            var telas = await _unitOfWorkApp.Repositorio.TelaRepositorio
                    .All()
                    .ProjectTo<TelaDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return telas;
        }
        public async Task<TelaDto> ObtenerPorIdAsync(int id)
        {
            var tela = await _unitOfWorkApp.Repositorio.TelaRepositorio
                    .Find(c => c.Id == id)
                    .ProjectTo<TelaDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

            if (tela is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            return tela;
        }

        public async Task<PaginacionResultadoDto<TelaPaginadoDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable)
        {
            var parametrosDto = PrimeNgToPaginationParametersDto<TelaDto>.Convert(primeTable);
            var parametrosDominio = parametrosDto.ConvertToPaginationParameterDomain<Tela, TelaDto>(_mapper);

            // parametrosDominio.FiltroWhere = parametrosDominio.FiltroWhere.AddCondition(x => x.State == (int)StateEnum.Active);

            var paginado = await _unitOfWorkApp.Repositorio.TelaRepositorio.FindAllPagingAsync(parametrosDominio);
            var telas = await paginado.Entidades.ProjectTo<TelaPaginadoDto>(_mapper.ConfigurationProvider).ToListAsync();

            foreach (var tela in telas)
            {
                tela.CantidadColores = await _unitOfWorkApp.Repositorio.TelaColorRepositorio.CountAsync(tc => tc.TelaId == tela.Id);
            }

            return new PaginacionResultadoDto<TelaPaginadoDto>
            {
                Cantidad = paginado.Cantidad,
                Entidades = telas
            };
        }
    }
}
