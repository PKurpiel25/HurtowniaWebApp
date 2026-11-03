using System.ComponentModel.DataAnnotations;

namespace HurtowniaWebClient.Models.Konto
{
    public class Hasło
    {
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = "Podaj stare hasło!")]
        [DataType(DataType.Password)]
        public string StareHasło { get; set; } = null!;

        [Required(ErrorMessage = "Podaj nowe hasło!")]
        [DataType(DataType.Password)]
        public string NoweHasło { get; set; } = null!;

        [Required]
        [Compare("NoweHasło", ErrorMessage = "Podane hasła nie zgadzają się!")]
        [DataType(DataType.Password)]
        public string PotwNowe { get; set; } = null!;

    }
}
