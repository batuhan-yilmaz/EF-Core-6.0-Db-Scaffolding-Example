using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Keyless]
    public partial class OrtalamaMaliyetinUzerindekiUrunler
    {
        [StringLength(40)]
        public string UrunAdi { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal? BirimFiyati { get; set; }
    }
}
