namespace HurtowniaWebClient.Models.Zamówienia
{
    public class ZamówienieDetailsExtra : ZamówienieDetailsKlient
    {
        public List<RodzajPrzesyłki> RodzajePrzesyłki { get; set; } = null!;
        public List<RodzajPłatności> RodzajePłatności { get; set; } = null!;
        public int RodzajPrzesyłkiId { get; set; }
        public int RodzajPłatnościId { get; set; }
    }
}
