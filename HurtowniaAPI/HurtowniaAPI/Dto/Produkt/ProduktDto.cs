namespace HurtowniaAPI.Dto.Produkt
{
    public class ProduktDto
    {
        public int Id { get; set; }
        public string Nazwa { get; set; } = null!;
        public decimal Cena { get; set; }
        public int Ilość { get; set; }
    }
}
