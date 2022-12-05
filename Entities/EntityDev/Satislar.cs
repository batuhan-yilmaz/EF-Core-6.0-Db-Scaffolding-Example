using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Table("Satislar")]
    [Index(nameof(MusteriId), Name = "MusteriID")]
    [Index(nameof(MusteriId), Name = "MusterilerSatislar")]
    [Index(nameof(ShipVia), Name = "NakliyecilerSatislar")]
    [Index(nameof(PersonelId), Name = "PersonelID")]
    [Index(nameof(PersonelId), Name = "PersonellerSatislar")]
    [Index(nameof(SatisTarihi), Name = "SatisTarihi")]
    [Index(nameof(SevkPostaKodu), Name = "SevkPostaKodu")]
    [Index(nameof(SevkTarihi), Name = "SevkTarihi")]
    public partial class Satislar
    {
        public Satislar()
        {
            SatisDetaylaris = new HashSet<SatisDetaylari>();
        }

        [Key]
        [Column("SatisID")]
        public int SatisId { get; set; }
        [Column("MusteriID")]
        [StringLength(5)]
        public string? MusteriId { get; set; }
        [Column("PersonelID")]
        public int? PersonelId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SatisTarihi { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OdemeTarihi { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SevkTarihi { get; set; }
        public int? ShipVia { get; set; }
        [Column(TypeName = "money")]
        public decimal? NakliyeUcreti { get; set; }
        [StringLength(40)]
        public string? SevkAdi { get; set; }
        [StringLength(60)]
        public string? SevkAdresi { get; set; }
        [StringLength(15)]
        public string? SevkSehri { get; set; }
        [StringLength(15)]
        public string? SevkBolgesi { get; set; }
        [StringLength(10)]
        public string? SevkPostaKodu { get; set; }
        [StringLength(15)]
        public string? SevkUlkesi { get; set; }

        [ForeignKey(nameof(MusteriId))]
        [InverseProperty(nameof(Musteriler.Satislars))]
        public virtual Musteriler? Musteri { get; set; }
        [ForeignKey(nameof(PersonelId))]
        [InverseProperty(nameof(Personeller.Satislars))]
        public virtual Personeller? Personel { get; set; }
        [ForeignKey(nameof(ShipVia))]
        [InverseProperty(nameof(Nakliyeciler.Satislars))]
        public virtual Nakliyeciler? ShipViaNavigation { get; set; }
        [InverseProperty(nameof(SatisDetaylari.Satis))]
        public virtual ICollection<SatisDetaylari> SatisDetaylaris { get; set; }
    }
}
