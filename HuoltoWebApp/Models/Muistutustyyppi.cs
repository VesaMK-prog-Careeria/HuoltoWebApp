using System;
using System.Collections.Generic;

namespace HuoltoWebApp.Models
{
    public partial class Muistutustyyppi
    {
        public Muistutustyyppi()
        {
            AutoMuistutus = new HashSet<AutoMuistutu>();
            PvMuistutus = new HashSet<PvMuistutu>();
            SäiliöMuistutus = new HashSet<SäiliöMuistutu>();
        }

        public int MuistutustyyppiId { get; set; }
        public string? MuistutustyyppiNimi { get; set; }

        public virtual ICollection<AutoMuistutu> AutoMuistutus { get; set; }
        public virtual ICollection<PvMuistutu> PvMuistutus { get; set; }
        public virtual ICollection<SäiliöMuistutu> SäiliöMuistutus { get; set; }
    }
}
