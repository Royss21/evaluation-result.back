namespace Domain.Main.Autenticacion
{
    public  class UsuarioToken : BaseModelActivo<Guid>
    {
        public Guid UsuarioId { get; set; }
        public string Token { get; set; } = string.Empty;
        public string RefrescarToken { get; set; } = string.Empty;
        public DateTime FechaExpiracionToken { get; set; }
        public DateTime FechaExpiracionRefrescarToken { get; set; }




        public Usuario Usuario { get; set; }
    }
}
