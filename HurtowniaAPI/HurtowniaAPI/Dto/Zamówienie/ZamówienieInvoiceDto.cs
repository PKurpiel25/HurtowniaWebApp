using HurtowniaAPI.Dto.Produkt;

namespace HurtowniaAPI.Dto.Zamówienie
{
    public class ZamówienieInvoiceDto : ZamówienieDto
    {
        public List<ProduktDto> Produkty { get; set; } = null!;
        public decimal KosztPrzesyłki { get; set; }
    }

}
