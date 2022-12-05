using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Keyless]
    public partial class AyrintiliSatisDetaylari
    {
        [Column("SatisID")]
        public int SatisId { get; set; }
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
    }
}
