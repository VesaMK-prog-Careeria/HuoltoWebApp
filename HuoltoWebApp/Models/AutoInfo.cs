using System;
using System.Collections.Generic;

namespace HuoltoWebApp.Models
{
    public partial class AutoInfo
    {
        public int AutoInfoId { get; set; }
        public int AutoId { get; set; }
        public string? InfoTxt { get; set; }
        public byte[]? Kuva { get; set; }

        public virtual Auto Auto { get; set; } = null!;
    }
}
