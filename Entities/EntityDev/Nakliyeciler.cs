using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Table("Nakliyeciler")]
    public partial class Nakliyeciler
    {
        public Nakliyeciler()
        {
            Satislars = new HashSet<Satislar>();
        }

        [Key]
        [Column("NakliyeciID")]
        public int NakliyeciId { get; set; }
        [StringLength(40)]
        public string SirketAdi { get; set; } = null!;
        [StringLength(24)]
        public string? Telefon { get; set; }

        [InverseProperty(nameof(Satislar.ShipViaNavigation))]
        public virtual ICollection<Satislar> Satislars { get; set; }
    }
}
