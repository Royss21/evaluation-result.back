namespace Application.Main.Services.Seguridad
{
    public class UsuarioServicio //: BaseService, IUsuarioServicio
    {
        //private readonly IContraseniaFabrica _contraseniaFabrica;
        //public UsuarioServicio(IContraseniaFabrica contraseniaFabrica, IServiceProvider serviceProvider) : base(serviceProvider)
        //{
        //    _contraseniaFabrica = contraseniaFabrica;
        //}

        //public async Task<bool> CrearAsync(UsuarioCrearDto request)
        //{
        //    (int tipoHash, string contraseniaHash) = _contraseniaFabrica.Hash(request.Contrasenia);

        //    var usuario = _mapper.Map<Usuario>(request);
        //    usuario.TipoHash = tipoHash;
        //    usuario.Contrasenia = contraseniaHash;

        //    await _unitOfWorkApp.Repositorio.UsuarioRepositorio.AddAsync(usuario);
        //    await _unitOfWorkApp.SaveChangesAsync();

        //    return true;
        //}

        //public async Task<bool> CrearConCompaniaAsync(UsuarioCompaniaCrearDto request)
        //{
        //    (int tipoHash, string contraseniaHash) = _contraseniaFabrica.Hash(request.Contrasenia);

        //    var usuario = _mapper.Map<Usuario>(request);
        //    usuario.TipoHash = tipoHash;
        //    usuario.Contrasenia = contraseniaHash;

        //    await _unitOfWorkApp.Repositorio.UsuarioRepositorio.AddAsync(usuario);
        //    await _unitOfWorkApp.SaveChangesAsync();

        //    return true;
        //}


        //public async Task<IEnumerable<UsuarioDto>> ObtenerTodoAsync()
        //{
        //    var usuarios = await _unitOfWorkApp.Repositorio.UsuarioRepositorio
        //            .All()
        //            .ProjectTo<UsuarioDto>(_mapper.ConfigurationProvider)
        //            .ToListAsync();

        //    return usuarios;
        //}
    }
}
