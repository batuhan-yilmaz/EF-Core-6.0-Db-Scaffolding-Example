using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Table("Urunler")]
    [Index(nameof(KategoriId), Name = "KategoriID")]
    [Index(nameof(KategoriId), Name = "KategorilerUrunler")]
    [Index(nameof(TedarikciId), Name = "TedarikciID")]
    [Index(nameof(TedarikciId), Name = "TedarikcilerUrunler")]
    [Index(nameof(UrunAdi), Name = "UrunAdi")]
    public partial class Urunler
    {
        public Urunler()
        {
            SatisDetaylaris = new HashSet<SatisDetaylari>();
        }

        [Key]
        [Column("UrunID")]
        public int UrunId { get; set; }
        [StringLength(40)]
        public string UrunAdi { get; set; } = null!;
        [Column("TedarikciID")]
        public int? TedarikciId { get; set; }
        [Column("KategoriID")]
        public int? KategoriId { get; set; }
        [StringLength(20)]
        public string? BirimdekiMiktar { get; set; }
        [Column(TypeName = "money")]
        public decimal? BirimFiyati { get; set; }
        public short? HedefStokDuzeyi { get; set; }
        public short? YeniSatis { get; set; }
        public short? EnAzYenidenSatisMikatari { get; set; }
        public bool Sonlandi { get; set; }

        [ForeignKey(nameof(KategoriId))]
        [InverseProperty(nameof(Kategoriler.Urunlers))]
        public virtual Kategoriler? Kategori { get; set; }
        [ForeignKey(nameof(TedarikciId))]
        [InverseProperty(nameof(Tedarikciler.Urunlers))]
        public virtual Tedarikciler? Tedarikci { get; set; }
        [InverseProperty(nameof(SatisDetaylari.Urun))]
        public virtual ICollection<SatisDetaylari> SatisDetaylaris { get; set; }
    }
}
