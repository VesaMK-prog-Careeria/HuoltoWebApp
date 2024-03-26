using System;
using System.Collections.Generic;

namespace HuoltoWebApp.Models
{
    public partial class SäiliöMuistutu
    {
        public int SäiliöMuistutusId { get; set; }
        public int? SäiliöId { get; set; }
        public DateTime? MuistutusPvm { get; set; }
        public int? Muistutustyyppi { get; set; }

        public virtual Muistutustyyppi? MuistutustyyppiNavigation { get; set; }
        public virtual Säiliö? Säiliö { get; set; }
    }
}
