using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Keyless]
    public partial class OzetYillikSatislar
    {
        [Column(TypeName = "datetime")]
        public DateTime? SevkTarihi { get; set; }
        [Column("SatisID")]
        public int SatisId { get; set; }
        [Column(TypeName = "money")]
        public decimal? Subtotal { get; set; }
    }
}
