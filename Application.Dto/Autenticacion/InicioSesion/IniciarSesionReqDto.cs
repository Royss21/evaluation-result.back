namespace Application.Dto.Autenticacion.InicioSesion
{
    public  class IniciarSesionReqDto
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string RolId { get; set; }= string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
    }
}
