using System;
using System.Collections.Generic;

namespace HuoltoWebApp.Models
{
    public partial class PvInfo
    {
        public int PvInfoId { get; set; }
        public int PvId { get; set; }
        public string? InfoTxt { get; set; }
        public byte[]? Kuva { get; set; }

        public virtual Pv Pv { get; set; } = null!;
    }
}
