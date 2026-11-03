namespace HurtowniaAPI.Dto.Użytkownik
{
    public class TokenDto
    {
        public string? JwToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
        public string Rola { get; set; } = null!;
    }
}
