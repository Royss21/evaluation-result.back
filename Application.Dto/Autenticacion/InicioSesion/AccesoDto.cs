namespace Application.Dto.Autenticacion.InicioSesion
{
    public  class AccesoDto
    {
        public string Token { get; set; } = string.Empty;
        public string? TokenRefrescar { get; set; }
        public int ExpiraEn { get; set; }
    }
}
