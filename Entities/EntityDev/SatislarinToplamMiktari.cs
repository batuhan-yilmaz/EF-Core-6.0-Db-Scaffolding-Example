using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Keyless]
    public partial class SatislarinToplamMiktari
    {
        [Column(TypeName = "money")]
        public decimal? SaleAmount { get; set; }
        [Column("SatisID")]
        public int SatisId { get; set; }
        [StringLength(40)]
        public string SirketAdi { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime? SevkTarihi { get; set; }
    }
}
