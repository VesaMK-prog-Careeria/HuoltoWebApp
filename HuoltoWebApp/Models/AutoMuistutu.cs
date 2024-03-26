using System;
using System.Collections.Generic;

namespace HuoltoWebApp.Models
{
    public partial class AutoMuistutu
    {
        public int AutoMuistutusId { get; set; }
        public int? AutoId { get; set; }
        public DateTime? MuistutusPvm { get; set; }
        public int? Muistutustyyppi { get; set; }

        public virtual Auto? Auto { get; set; }
        public virtual Muistutustyyppi? MuistutustyyppiNavigation { get; set; }
    }
}
