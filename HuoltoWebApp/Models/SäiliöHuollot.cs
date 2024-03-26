using System;
using System.Collections.Generic;

namespace HuoltoWebApp.Models
{
    public partial class SäiliöHuollot
    {
        public int HuoltoId { get; set; }
        public int SäiliöId { get; set; }
        public DateTime? HuoltoPvm { get; set; }
        public int? HuoltoPaikkaId { get; set; }
        public string? HuollonKuvaus { get; set; }
        public byte[]? Kuva { get; set; }

        public virtual Säiliö Säiliö { get; set; } = null!;
    }
}
