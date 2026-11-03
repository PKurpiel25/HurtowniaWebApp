using HurtowniaAPI.Dto.Produkt;

namespace HurtowniaAPI.Dto.Zamówienie
{
    public class ZamówienieDetailsKlientDto : ZamówienieSingleKlientDto
    {
        public List<ProduktDto> Produkty { get; set; } = null!;
        public decimal KosztPrzesyłki { get; set; }
        public string AdresUlica { get; set; } = null!;
        public string AdresMiasto { get; set; } = null!;
        public string AdresKod { get; set; } = null!;
    }
}
