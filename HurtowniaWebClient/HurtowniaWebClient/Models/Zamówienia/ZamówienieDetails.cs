using HurtowniaWebClient.Models.Produkty;

namespace HurtowniaWebClient.Models.Zamówienia
{
    public class ZamówienieDetails : ZamówienieSingle
    {
        public List<ProduktKoszyk> Produkty { get; set; } = null!;
        public decimal KosztPrzesyłki { get; set; }
        public string AdresUlica { get; set; } = null!;
        public string AdresMiasto { get; set; } = null!;
        public string AdresKod { get; set; } = null!;
    }
}
