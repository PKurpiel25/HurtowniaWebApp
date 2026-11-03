namespace HurtowniaWebClient.Models.Zapytania
{
    public abstract class Zapytanie
    {
        public int Id { get; set; }
        public string Tytuł { get; set; } = null!;
    }
}