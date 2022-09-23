using System;

namespace Application.Security.Entidades
{
    public class UsuarioTokenApp
    {
        public string Token { get; set; } = string.Empty;
        public string? TokenRefrescar { get; set; } = string.Empty;
        public double ExpiraEn { get; set; }
        public DateTime Expiracion { get; set; }
        public DateTime? ExpiracionTokenRefrescar { get; set; }
    }
}