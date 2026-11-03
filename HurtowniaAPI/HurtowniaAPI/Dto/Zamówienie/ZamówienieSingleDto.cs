namespace HurtowniaAPI.Dto.Zamówienie
{
    public class ZamówienieSingleDto : ZamówienieDto
    {
        public string RodzajPrzesyłkiNazwa { get; set; } = null!;
        public string RodzajPłatnościNazwa { get; set; } = null!;
        public string KlientEmail { get; set; } = null!;
    }
}
