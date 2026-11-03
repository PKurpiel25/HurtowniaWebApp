using HurtowniaAPI.Dto.Produkt;

namespace HurtowniaAPI.Dto.Zamówienie
{
    public class ZamówienieFullDto : ZamówienieDto
    {
        public int RodzajPrzesyłkiId { get; set; }
        public int RodzajPłatnościId { get; set; }
        public string KlientId { get; set; } = null!;
        public List<ProduktDto> Produkty { get; set; } = null!;
        public string Adres { get; set; } = null!;
    }
}
