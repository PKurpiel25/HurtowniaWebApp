namespace HurtowniaWebClient.Models.Produkty
{
    public class ProduktKoszyk
    {
        public int Id { get; set; }
        public string Nazwa { get; set; } = null!;
        public decimal Cena { get; set; }
        public int Ilość { get; set; }
        public int MaxIlość { get; set; }
    }
}
