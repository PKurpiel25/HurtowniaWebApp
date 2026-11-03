using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HurtowniaAPI.Entities
{
    public class Zdjęcie
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Nazwa { get; set; } = null!;

        public int ProduktId { get; set; }
        public virtual Produkt? Produkt { get; set; }
    }
}