using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Keyless]
    public partial class SatislarSorgusu
    {
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
        [StringLength(40)]
        public string SirketAdi { get; set; } = null!;
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
    }
}
