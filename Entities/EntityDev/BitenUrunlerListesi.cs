using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Keyless]
    public partial class BitenUrunlerListesi
    {
        [Column("UrunID")]
        public int UrunId { get; set; }
        [StringLength(40)]
        public string UrunAdi { get; set; } = null!;
    }
}
