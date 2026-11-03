namespace HurtowniaWebClient.Models.Produkty
{
    public class ProduktDetails : Produkt
    {
        public string Opis { get; set; } = null!;
        public List<Zdjęcie> Zdjęcia { get; set; } = null!;
    }
}
