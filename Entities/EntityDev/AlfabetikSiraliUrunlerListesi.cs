using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Keyless]
    public partial class AlfabetikSiraliUrunlerListesi
    {
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
        [StringLength(15)]
        public string KategoriAdi { get; set; } = null!;
    }
}
