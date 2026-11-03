namespace HurtowniaWebClient.Models.Produkty
{
    public class ProduktLista
    {
        public List<ProduktKoszyk>? Produkty { get; set; } = null!;
        public decimal Suma { get; set; }
    }
}
