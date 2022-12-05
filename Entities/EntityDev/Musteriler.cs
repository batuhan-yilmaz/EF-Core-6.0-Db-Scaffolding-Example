using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Table("Musteriler")]
    [Index(nameof(Bolge), Name = "Bolge")]
    [Index(nameof(PostaKodu), Name = "PostaKodu")]
    [Index(nameof(Sehir), Name = "Sehir")]
    [Index(nameof(SirketAdi), Name = "SirketAdi")]
    public partial class Musteriler
    {
        public Musteriler()
        {
            Satislars = new HashSet<Satislar>();
            MusteriTypes = new HashSet<MusteriDemographic>();
        }

        [Key]
        [Column("MusteriID")]
        [StringLength(5)]
        public string MusteriId { get; set; } = null!;
        [StringLength(40)]
        public string SirketAdi { get; set; } = null!;
        [StringLength(30)]
        public string? MusteriAdi { get; set; }
        [StringLength(30)]
        public string? MusteriUnvani { get; set; }
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
        [StringLength(24)]
        public string? Telefon { get; set; }
        [StringLength(24)]
        public string? Faks { get; set; }

        [InverseProperty(nameof(Satislar.Musteri))]
        public virtual ICollection<Satislar> Satislars { get; set; }

        [ForeignKey("MusteriId")]
        [InverseProperty(nameof(MusteriDemographic.Musteris))]
        public virtual ICollection<MusteriDemographic> MusteriTypes { get; set; }
    }
}
