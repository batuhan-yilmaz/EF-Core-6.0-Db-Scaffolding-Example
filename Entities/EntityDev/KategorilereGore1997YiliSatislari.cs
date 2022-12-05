using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Keyless]
    public partial class KategorilereGore1997YiliSatislari
    {
        [StringLength(15)]
        public string KategoriAdi { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal? KategoriSales { get; set; }
    }
}
