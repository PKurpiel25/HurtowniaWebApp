using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HurtowniaAPI.Entities
{
    public class Zamówienie
    {
        public int Id { get; set; }
        public int RodzajPrzesyłkiId { get; set; }
        public virtual RodzajPrzesyłki RodzajPrzesyłki { get; set; } = null!;
        public int RodzajPłatnościId { get; set; }
        public virtual RodzajPłatności RodzajPłatności { get; set; } = null!;

        [Precision(7, 2)]
        public decimal Koszt { get; set; }

        public string UżytkownikId { get; set; } = null!;
        public virtual Użytkownik Użytkownik { get; set; } = null!;
        public virtual List<ProduktZamówienie>? Produkty { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(40)]
        public string Adres { get; set; } = null!;
    }
}