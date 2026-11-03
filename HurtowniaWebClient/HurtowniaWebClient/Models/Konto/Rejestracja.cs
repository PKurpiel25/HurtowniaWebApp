using System.ComponentModel.DataAnnotations;

namespace HurtowniaWebClient.Models.Konto
{
    public class Rejestracja
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Podaj login!")]
        public string Login { get; set; } = null!;

        [Required(ErrorMessage = "Podaj poprawny email!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Podaj hasło!")]
        [DataType(DataType.Password)]
        public string Hasło { get; set; } = null!;

        [Required(ErrorMessage = "Podane hasła nie zgadzają się!")]
        [Compare("Hasło", ErrorMessage = "Podane hasła nie zgadzają się!")]
        [DataType(DataType.Password)]
        public string PotwHasło { get; set; } = null!;

        [Required(ErrorMessage = "Podaj numer telefonu!")]
        [DataType(DataType.PhoneNumber)]
        public string NumerTel { get; set; } = null!;

        [Required(ErrorMessage = "Podaj nazwę firmy!")]
        public string Firma { get; set; } = null!;

        [Required(ErrorMessage = "Podaj imię!")]
        public string Imię { get; set; } = null!;

        [Required(ErrorMessage = "Podaj nazwisko!")]
        public string Nazwisko { get; set; } = null!;

        [Required(ErrorMessage = "Podaj PESEL!")]
        [StringLength(11, MinimumLength = 11)]
        public string PESEL { get; set; } = null!;

        public bool Polityka { get; set; }

    }
}
