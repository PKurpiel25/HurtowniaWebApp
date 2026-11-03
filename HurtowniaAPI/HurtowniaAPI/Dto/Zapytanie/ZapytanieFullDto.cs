namespace HurtowniaAPI.Dto.Zapytanie
{
    public class ZapytanieFullDto : ZapytanieDto
    {
        public string Treść { get; set; } = null!;
        public int ProduktId { get; set; }
        public string KlientId { get; set; } = null!;
    }
}
