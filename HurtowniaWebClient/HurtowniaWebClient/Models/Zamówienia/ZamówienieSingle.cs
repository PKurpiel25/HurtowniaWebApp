namespace HurtowniaWebClient.Models.Zamówienia
{
    public class ZamówienieSingle : Zamówienie
    {
        public string RodzajPrzesyłkiNazwa { get; set; } = null!;
        public string RodzajPłatnościNazwa { get; set; } = null!;
        public string KlientEmail { get; set; } = null!;
    }
}
