namespace HurtowniaWebClient.Models.Zamówienia
{
    public class ZamówienieSingleKlient : Zamówienie
    {
        public string RodzajPrzesyłkiNazwa { get; set; } = null!;
        public string RodzajPłatnościNazwa { get; set; } = null!;
    }
}
