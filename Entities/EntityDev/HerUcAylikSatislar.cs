using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.EntityDev
{
    [Keyless]
    public partial class HerUcAylikSatislar
    {
        [Column("MusteriID")]
        [StringLength(5)]
        public string? MusteriId { get; set; }
        [StringLength(40)]
        public string? SirketAdi { get; set; }
        [StringLength(15)]
        public string? Sehir { get; set; }
        [StringLength(15)]
        public string? Ulke { get; set; }
    }
}
