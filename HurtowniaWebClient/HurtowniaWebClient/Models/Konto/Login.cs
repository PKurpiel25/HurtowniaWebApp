using System.ComponentModel.DataAnnotations;

namespace HurtowniaWebClient.Models.Konto
{
    public class Login
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Hasło { get; set; } = null!;

        public bool Pamiętaj { get; set; }

    }
}
