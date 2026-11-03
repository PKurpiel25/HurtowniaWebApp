using HurtowniaWebClient.Models.Produkty;

namespace HurtowniaWebClient.Models.Zamówienia
{
    public class ZamówienieInvoice : Zamówienie
    {
        public List<ProduktKoszyk> Produkty { get; set; } = null!;
        public decimal KosztPrzesyłki { get; set; }
    }
}
