using HurtowniaAPI.Dto.Zdjęcie;

namespace HurtowniaAPI.Dto.Produkt
{
    public class ProduktDetailsDto : ProduktDto
    {
        public string Opis { get; set; } = null!;
        public List<ZdjęcieDto> Zdjęcia { get; set; } = null!;
    }
}
