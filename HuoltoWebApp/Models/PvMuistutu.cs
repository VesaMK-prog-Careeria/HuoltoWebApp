using System;
using System.Collections.Generic;

namespace HuoltoWebApp.Models
{
    public partial class PvMuistutu
    {
        public int PvMuistutusId { get; set; }
        public int? PvId { get; set; }
        public DateTime? MuistutusPvm { get; set; }
        public int? Muistutustyyppi { get; set; }

        public virtual Muistutustyyppi? MuistutustyyppiNavigation { get; set; }
        public virtual Pv? Pv { get; set; }
    }
}
