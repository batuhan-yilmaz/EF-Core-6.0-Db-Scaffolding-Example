using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    public partial class MusteriDemographic
    {
        public MusteriDemographic()
        {
            Musteris = new HashSet<Musteriler>();
        }

        [Key]
        [Column("MusteriTypeID")]
        [StringLength(10)]
        public string MusteriTypeId { get; set; } = null!;
        [Column(TypeName = "ntext")]
        public string? MusteriDesc { get; set; }

        [ForeignKey("MusteriTypeId")]
        [InverseProperty(nameof(Musteriler.MusteriTypes))]
        public virtual ICollection<Musteriler> Musteris { get; set; }
    }
}
