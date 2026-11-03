namespace HurtowniaAPI.Dto.Użytkownik
{
    public class UżytkownikDto
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Imię { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public string NumerTel { get; set; } = null!;
        public string? Firma { get; set; }
        public string? PESEL { get; set; }
    }
}
