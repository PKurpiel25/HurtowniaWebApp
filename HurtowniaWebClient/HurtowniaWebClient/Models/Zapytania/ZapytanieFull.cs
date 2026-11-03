namespace HurtowniaWebClient.Models.Zapytania
{
    public class ZapytanieFull : Zapytanie
    {
        public string Treść { get; set; } = null!;
        public int ProduktId { get; set; }
        public string KlientId { get; set; } = null!;
    }
}
