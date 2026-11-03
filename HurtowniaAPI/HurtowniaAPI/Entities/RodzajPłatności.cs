using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HurtowniaAPI.Entities
{
    public class RodzajPłatności
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string Nazwa { get; set; } = null!;
    }
}
