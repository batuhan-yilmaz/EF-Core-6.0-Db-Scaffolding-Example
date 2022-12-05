using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Keyless]
    public partial class Faturalar
    {
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
        [Column("MusteriID")]
        [StringLength(5)]
        public string? MusteriId { get; set; }
        [StringLength(40)]
        public string MusteriName { get; set; } = null!;
        [StringLength(60)]
        public string? Adres { get; set; }
        [StringLength(15)]
        public string? Sehir { get; set; }
        [StringLength(15)]
        public string? Bolge { get; set; }
        [StringLength(10)]
        public string? PostaKodu { get; set; }
        [StringLength(15)]
        public string? Ulke { get; set; }
        [StringLength(31)]
        public string PersonelSatislari { get; set; } = null!;
        [Column("SatisID")]
        public int SatisId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SatisTarihi { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OdemeTarihi { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SevkTarihi { get; set; }
        [StringLength(40)]
        public string NakliyeciName { get; set; } = null!;
        [Column("UrunID")]
        public int UrunId { get; set; }
        [StringLength(40)]
        public string UrunAdi { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal BirimFiyati { get; set; }
        public short Miktar { get; set; }
        public float İndirim { get; set; }
        [Column(TypeName = "money")]
        public decimal? ExtendedPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal? NakliyeUcreti { get; set; }
    }
}
