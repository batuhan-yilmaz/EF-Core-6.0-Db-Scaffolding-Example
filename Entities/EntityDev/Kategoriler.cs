using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Table("Kategoriler")]
    [Index(nameof(KategoriAdi), Name = "KategoriAdi")]
    public partial class Kategoriler
    {
        public Kategoriler()
        {
            Urunlers = new HashSet<Urunler>();
        }

        [Key]
        [Column("KategoriID")]
        public int KategoriId { get; set; }
        [StringLength(15)]
        public string KategoriAdi { get; set; } = null!;
        [Column(TypeName = "ntext")]
        public string? Tanimi { get; set; }
        [Column(TypeName = "image")]
        public byte[]? Resim { get; set; }

        [InverseProperty(nameof(Urunler.Kategori))]
        public virtual ICollection<Urunler> Urunlers { get; set; }
    }
}
