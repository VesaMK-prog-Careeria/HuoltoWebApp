using System;
using System.Collections.Generic;

namespace HuoltoWebApp.Models
{
    public partial class AutoHuoltopyyntö
    {
        public int HuoltoId { get; set; }
        public int AutoId { get; set; }
        public string? HuollonKuvaus { get; set; }
        public byte[]? Kuva { get; set; }

        public virtual Auto Auto { get; set; } = null!;
    }
}
