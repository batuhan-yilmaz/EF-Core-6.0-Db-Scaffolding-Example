using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Keyless]
    public partial class KategorilereGoreUrunler
    {
        [StringLength(15)]
        public string KategoriAdi { get; set; } = null!;
        [StringLength(40)]
        public string UrunAdi { get; set; } = null!;
        [StringLength(20)]
        public string? BirimdekiMiktar { get; set; }
        public short? HedefStokDuzeyi { get; set; }
        public bool Sonlandi { get; set; }
    }
}
