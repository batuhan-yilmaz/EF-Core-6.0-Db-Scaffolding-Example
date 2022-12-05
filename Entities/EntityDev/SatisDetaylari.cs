using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Table("Satis Detaylari")]
    [Index(nameof(SatisId), Name = "SatisID")]
    [Index(nameof(SatisId), Name = "SatislarOrder_Details")]
    [Index(nameof(UrunId), Name = "UrunID")]
    [Index(nameof(UrunId), Name = "UrunlerOrder_Details")]
    public partial class SatisDetaylari
    {
        [Key]
        [Column("SatisID")]
        public int SatisId { get; set; }
        [Key]
        [Column("UrunID")]
        public int UrunId { get; set; }
        [Column(TypeName = "money")]
        public decimal BirimFiyati { get; set; }
        public short Miktar { get; set; }
        public float İndirim { get; set; }

        [ForeignKey(nameof(SatisId))]
        [InverseProperty(nameof(Satislar.SatisDetaylaris))]
        public virtual Satislar Satis { get; set; } = null!;
        [ForeignKey(nameof(UrunId))]
        [InverseProperty(nameof(Urunler.SatisDetaylaris))]
        public virtual Urunler Urun { get; set; } = null!;
    }
}
