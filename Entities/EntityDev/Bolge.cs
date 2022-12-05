using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Table("Bolge")]
    public partial class Bolge
    {
        public Bolge()
        {
            Bolgelers = new HashSet<Bolgeler>();
        }

        [Key]
        [Column("BolgeID")]
        public int BolgeId { get; set; }
        [StringLength(50)]
        public string BolgeTanimi { get; set; } = null!;

        [InverseProperty(nameof(Bolgeler.Bolge))]
        public virtual ICollection<Bolgeler> Bolgelers { get; set; }
    }
}
