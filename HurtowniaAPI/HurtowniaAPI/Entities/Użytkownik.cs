using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HurtowniaAPI.Entities
{
    public class Użytkownik : IdentityUser
    {
        [Column(TypeName = "nvarchar")]
        [StringLength(15)]
        public string Imię { get; set; } = null!;

        [Column(TypeName = "nvarchar")]
        [StringLength(35)]
        public string Nazwisko { get; set; } = null!;

        [Column(TypeName = "nvarchar")]
        [StringLength(25)]
        public string? Firma { get; set; }

        [Column(TypeName = "char")]
        [StringLength(11)]
        public string? PESEL { get; set; }

        [Column(TypeName = "char")]
        [StringLength(44)]
        public string? RefreshToken { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? RefreshTime { get; set; }

        public virtual List<Zapytanie>? Zapytania { get; set; }
        public virtual List<Zamówienie>? Zamówienia { get; set; }
    }
}
