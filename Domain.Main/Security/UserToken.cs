namespace Domain.Main.Security
{
    public class UserToken : BaseModelActive<Guid>
    {
        public Guid UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenExpirationDate { get; set; }
        public DateTime RefreshTokenExpirationDate { get; set; }


        public virtual User User { get; set; }
    }
}
