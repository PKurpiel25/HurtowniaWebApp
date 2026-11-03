namespace HurtowniaAPI.Dto.Produkt
{
    public class ProduktUpdateDto : ProduktFullDto
    {
        public List<string> DoUsun { get; set; } = null!;
    }
}
