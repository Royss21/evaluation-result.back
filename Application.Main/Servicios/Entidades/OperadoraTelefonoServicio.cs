namespace Application.Main.Servicios.Entidades
{
    using Application.Dto.Entidades.OperadoraTelefono;
    using Application.Main.Servicios.Entidades.Interfaces;
    using Domain.Common.Constantes;
    using Domain.Main.Validadores.OperadoraTelefonoValidaciones;

    public class OperadoraTelefonoServicio : BaseServicio, IOperadoraTelefonoServicio
    {
        public OperadoraTelefonoServicio(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<bool> CrearAsync(OperadoraTelefonoCrearDto request)
        {
            var operadoraTelefono = _mapper.Map<OperadoraTelefono>(request);

            var resultadoValidador = await _unitOfWorkApp.Repositorio.OperadoraTelefonoRepositorio
                .AddAsync(operadoraTelefono, new OperadoraTelefonoCrearValidador(_unitOfWorkApp.Repositorio.OperadoraTelefonoRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ActualizarAsync(OperadoraTelefonoActualizarDto request)
        {
            var operadora = await _unitOfWorkApp.Repositorio.OperadoraTelefonoRepositorio.GetAsync(request.Id);

            if (operadora is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);


            operadora.Nombre = request.Nombre;

            var resultadoValidador = await _unitOfWorkApp.Repositorio.OperadoraTelefonoRepositorio
                .UpdateAsync(operadora, new OperadoraTelefonoActualizarValidador(_unitOfWorkApp.Repositorio.OperadoraTelefonoRepositorio));

            if (!resultadoValidador.IsValid)
                throw new ValidadorExcepcion(string.Join(",", resultadoValidador.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var operadora = await _unitOfWorkApp.Repositorio.OperadoraTelefonoRepositorio.GetAsync(id);

            if (operadora is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);


            await _unitOfWorkApp.Repositorio.OperadoraTelefonoRepositorio.DeleteAsync(operadora);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<OperadoraTelefonoDto>> ObtenerTodoAsync()
        {
            return await _unitOfWorkApp.Repositorio.OperadoraTelefonoRepositorio
                    .All()
                    .ProjectTo<OperadoraTelefonoDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }
        public async Task<OperadoraTelefonoDto> ObtenerPorIdAsync(int id)
        {
            var operadora = await _unitOfWorkApp.Repositorio.OperadoraTelefonoRepositorio
                    .Find(c => c.Id == id)
                    .ProjectTo<OperadoraTelefonoDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

            if (operadora is null)
                throw new AdvertenciaExcepcion(Mensajes.General.RecursoNoEncontrado);

            return operadora;
        }

        public async Task<PaginacionResultadoDto<OperadoraTelefonoDto>> ObtenerTodoPaginadoAsync(PrimeTable primeTable)
        {
            var parametrosDto = PrimeNgToPaginationParametersDto<OperadoraTelefonoDto>.Convert(primeTable);
            var parametrosDominio = parametrosDto.ConvertToPaginationParameterDomain<OperadoraTelefono, OperadoraTelefonoDto>(_mapper);

            // parametrosDominio.FiltroWhere = parametrosDominio.FiltroWhere.AddCondition(x => x.State == (int)StateEnum.Active);

            var paginado = await _unitOfWorkApp.Repositorio.OperadoraTelefonoRepositorio.FindAllPagingAsync(parametrosDominio);
            var operadoraTelefonos = await paginado.Entidades.ProjectTo<OperadoraTelefonoDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginacionResultadoDto<OperadoraTelefonoDto>
            {
                Cantidad = paginado.Cantidad,
                Entidades = operadoraTelefonos
            };
        }
    }
}
