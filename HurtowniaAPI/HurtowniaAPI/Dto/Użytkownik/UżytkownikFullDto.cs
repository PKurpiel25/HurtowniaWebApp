namespace HurtowniaAPI.Dto.Użytkownik
{
    public class UżytkownikFullDto : UżytkownikDto
    {
        public string Hasło { get; set; } = null!;
        public string Rola { get; set; } = null!;
    }
}
