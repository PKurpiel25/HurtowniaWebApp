using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HurtowniaAPI.Entities
{
    public class RodzajPrzesyłki
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string Nazwa { get; set; } = null!;

        [Precision(7,2)]
        public decimal Koszt { get; set; }
    }
}
