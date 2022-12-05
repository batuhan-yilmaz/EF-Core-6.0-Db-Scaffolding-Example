using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.EntityDev
{
    [Table("Bolgeler")]
    public partial class Bolgeler
    {
        public Bolgeler()
        {
            Personels = new HashSet<Personeller>();
        }

        [Key]
        [Column("TerritoryID")]
        [StringLength(20)]
        public string TerritoryId { get; set; } = null!;
        [StringLength(50)]
        public string TerritoryTanimi { get; set; } = null!;
        [Column("BolgeID")]
        public int BolgeId { get; set; }

        [ForeignKey(nameof(BolgeId))]
        [InverseProperty("Bolgelers")]
        public virtual Bolge Bolge { get; set; } = null!;

        [ForeignKey("TerritoryId")]
        [InverseProperty(nameof(Personeller.Territories))]
        public virtual ICollection<Personeller> Personels { get; set; }
    }
}
