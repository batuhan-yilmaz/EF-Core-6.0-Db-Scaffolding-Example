using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Table("Personeller")]
    [Index(nameof(PostaKodu), Name = "PostaKodu")]
    [Index(nameof(SoyAdi), Name = "SoyAdi")]
    public partial class Personeller
    {
        public Personeller()
        {
            InverseBagliCalistigiKisiNavigation = new HashSet<Personeller>();
            Satislars = new HashSet<Satislar>();
            Territories = new HashSet<Bolgeler>();
        }

        [Key]
        [Column("PersonelID")]
        public int PersonelId { get; set; }
        [StringLength(20)]
        public string SoyAdi { get; set; } = null!;
        [StringLength(10)]
        public string Adi { get; set; } = null!;
        [StringLength(30)]
        public string? Unvan { get; set; }
        [StringLength(25)]
        public string? UnvanEki { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DogumTarihi { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? IseBaslamaTarihi { get; set; }
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
        public string? EvTelefonu { get; set; }
        [StringLength(4)]
        public string? Extension { get; set; }
        [Column(TypeName = "image")]
        public byte[]? Fotograf { get; set; }
        [Column(TypeName = "ntext")]
        public string? Notlar { get; set; }
        public int? BagliCalistigiKisi { get; set; }
        [StringLength(255)]
        public string? FotografPath { get; set; }

        [ForeignKey(nameof(BagliCalistigiKisi))]
        [InverseProperty(nameof(Personeller.InverseBagliCalistigiKisiNavigation))]
        public virtual Personeller? BagliCalistigiKisiNavigation { get; set; }
        [InverseProperty(nameof(Personeller.BagliCalistigiKisiNavigation))]
        public virtual ICollection<Personeller> InverseBagliCalistigiKisiNavigation { get; set; }
        [InverseProperty(nameof(Satislar.Personel))]
        public virtual ICollection<Satislar> Satislars { get; set; }

        [ForeignKey("PersonelId")]
        [InverseProperty(nameof(Bolgeler.Personels))]
        public virtual ICollection<Bolgeler> Territories { get; set; }
    }
}
