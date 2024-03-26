using System;
using System.Collections.Generic;

namespace HuoltoWebApp.Models
{
    public partial class Auto
    {
        public Auto()
        {
            AutoHuollots = new HashSet<AutoHuollot>();
            AutoHuoltopyyntös = new HashSet<AutoHuoltopyyntö>();
            AutoMuistutus = new HashSet<AutoMuistutu>();
        }

        public int AutoId { get; set; }
        public string RekNro { get; set; } = null!;
        public int? SäiliöId { get; set; }
        public DateTime? Katsastus { get; set; }
        public DateTime? Adr { get; set; }
        public DateTime? Piirturi { get; set; }
        public DateTime? Alkolukko { get; set; }
        public DateTime? Nopeudenrajoitin { get; set; }
        public int? AutoInfoId { get; set; }

        public virtual Säiliö? Säiliö { get; set; }
        public virtual AutoInfo? AutoInfo { get; set; }
        public virtual ICollection<AutoHuollot> AutoHuollots { get; set; }
        public virtual ICollection<AutoHuoltopyyntö> AutoHuoltopyyntös { get; set; }
        public virtual ICollection<AutoMuistutu> AutoMuistutus { get; set; }
    }
}
