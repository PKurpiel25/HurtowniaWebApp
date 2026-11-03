using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HurtowniaAPI.Entities
{
    public class Produkt
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(60)]
        public string Nazwa { get; set; } = null!;

        [Column(TypeName = "ntext")]
        public string Opis { get; set; } = null!;

        public virtual List<Zdjęcie>? Zdjęcia { get; set; }

        [Precision(2,2)]
        public decimal VAT { get; set; }

        [Precision(7,2)]
        public decimal Cena { get; set; }

        public int Ilość { get; set; }

        public bool Usunięty { get; set; } = false;

        public virtual List<ProduktZamówienie>? Zamówienia { get; set; }
    }
}