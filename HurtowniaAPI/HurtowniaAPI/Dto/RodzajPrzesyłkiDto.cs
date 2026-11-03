namespace HurtowniaAPI.Dto
{
    public class RodzajPrzesyłkiDto
    {
        public int Id { get; set; }
        public string Nazwa { get; set; } = null!;
        public decimal Koszt { get; set; }
    }
}
