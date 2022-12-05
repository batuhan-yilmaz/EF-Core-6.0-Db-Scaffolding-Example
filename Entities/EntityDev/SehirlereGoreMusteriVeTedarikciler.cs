using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Keyless]
    public partial class SehirlereGoreMusteriVeTedarikciler
    {
        [StringLength(15)]
        public string? Sehir { get; set; }
        [StringLength(40)]
        public string SirketAdi { get; set; } = null!;
        [StringLength(30)]
        public string? MusteriAdi { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string Relationship { get; set; } = null!;
    }
}
