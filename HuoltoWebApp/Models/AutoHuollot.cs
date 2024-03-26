using System;
using System.Collections.Generic;

namespace HuoltoWebApp.Models
{
    public partial class AutoHuollot
    {
        public int HuollonId { get; set; }
        public int AutoId { get; set; }
        public DateTime HuoltoPvm { get; set; }
        public string? HuoltopaikkaId { get; set; }
        public string? HuollonKuvaus { get; set; }
        public byte[]? Kuva { get; set; }

        public virtual Auto Auto { get; set; } = null!;
    }
}
