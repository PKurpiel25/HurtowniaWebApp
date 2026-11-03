namespace HurtowniaAPI.Dto.Zamówienie
{
    public class ZamówienieSingleKlientDto : ZamówienieDto
    {
        public string RodzajPrzesyłkiNazwa { get; set; } = null!;
        public string RodzajPłatnościNazwa { get; set; } = null!;
    }
}
