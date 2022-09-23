namespace Application.Dto.Autenticacion.InicioSesion
{
    public  class TokenReqDto
    {
        public string Token { get; set; } = string.Empty;
        public string TokenRefrescar { get; set; } = string.Empty;
    }
}
