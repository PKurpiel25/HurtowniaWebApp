namespace HurtowniaAPI.Entities
{
    public class ProduktZamówienie
    {
        public int ProduktId { get; set; }
        public virtual Produkt? Produkt { get; set; }
        public int ZamówienieId { get; set; }
        public virtual Zamówienie? Zamówienie { get; set; }
        public int Ilość { get; set; }
    }
}
