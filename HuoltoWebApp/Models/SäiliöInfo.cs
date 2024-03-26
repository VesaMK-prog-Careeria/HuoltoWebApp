using System;
using System.Collections.Generic;

namespace HuoltoWebApp.Models
{
    public partial class SäiliöInfo
    {
        public int SäiliöInfoId { get; set; }
        public int SäiliöId { get; set; }
        public string? InfoTxt { get; set; }
        public byte[]? Kuva { get; set; }

        public virtual Säiliö Säiliö { get; set; } = null!;
    }
}
