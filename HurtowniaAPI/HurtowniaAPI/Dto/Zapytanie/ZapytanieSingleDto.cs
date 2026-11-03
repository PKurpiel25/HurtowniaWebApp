namespace HurtowniaAPI.Dto.Zapytanie
{
    public class ZapytanieSingleDto : ZapytanieDto
    {
        public string KlientEmail { get; set; } = null!;
        public string ProduktNazwa { get; set; } = null!;
    }
}
