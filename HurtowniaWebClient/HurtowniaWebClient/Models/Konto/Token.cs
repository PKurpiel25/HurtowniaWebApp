namespace HurtowniaWebClient.Models.Konto
{
    public class Token
    {
        public string JwToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
        public string Rola { get; set; } = null!;
    }
}
