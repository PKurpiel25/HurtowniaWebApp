using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HurtowniaAPI.Entities
{
    public class Zapytanie
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(45)]
        public string Tytuł { get; set; } = null!;

        [Column(TypeName = "ntext")]
        public string Treść { get; set; } = null!;

        public string UżytkownikId { get; set; } = null!;
        public virtual Użytkownik Użytkownik { get; set; } = null!;
        public int ProduktId { get; set; }
        public virtual Produkt Produkt { get; set; } = null!;
    }
}