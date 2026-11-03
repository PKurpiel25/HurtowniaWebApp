namespace HurtowniaAPI.Dto.Zapytanie
{
    public abstract class ZapytanieDto
    {
        public int Id { get; set; }
        public string Tytuł { get; set; } = null!;
    }
}
