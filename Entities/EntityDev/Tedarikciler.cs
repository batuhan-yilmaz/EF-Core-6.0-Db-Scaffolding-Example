using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Table("Tedarikciler")]
    [Index(nameof(PostaKodu), Name = "PostaKodu")]
    [Index(nameof(SirketAdi), Name = "SirketAdi")]
    public partial class Tedarikciler
    {
        public Tedarikciler()
        {
            Urunlers = new HashSet<Urunler>();
        }

        [Key]
        [Column("TedarikciID")]
        public int TedarikciId { get; set; }
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
        [Column(TypeName = "ntext")]
        public string? WebSayfasi { get; set; }

        [InverseProperty(nameof(Urunler.Tedarikci))]
        public virtual ICollection<Urunler> Urunlers { get; set; }
    }
}
