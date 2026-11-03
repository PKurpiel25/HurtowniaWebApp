namespace HurtowniaAPI.Dto.Użytkownik
{
    public class LoginDto
    {
        public string UserName { get; set; } = null!;
        public string Hasło { get; set; } = null!;
        public bool Pamiętaj { get; set; }
    }
}
