using HurtowniaWebClient.Models.Produkty;

namespace HurtowniaWebClient.Models.Zamówienia
{
    public class ZamówienieFull : Zamówienie
    {
        public int RodzajPrzesyłkiId { get; set; }
        public int RodzajPłatnościId { get; set; }
        public string KlientId { get; set; } = null!;
        public List<ProduktKoszyk> Produkty { get; set; } = null!;
        public string Adres { get; set; } = null!;
    }
}
