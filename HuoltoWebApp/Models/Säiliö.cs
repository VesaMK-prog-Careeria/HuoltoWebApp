using System;
using System.Collections.Generic;

namespace HuoltoWebApp.Models
{
    public partial class Säiliö
    {
        public Säiliö()
        {
            Autos = new HashSet<Auto>();
            SäiliöHuollots = new HashSet<SäiliöHuollot>();
            SäiliöHuoltopyyntös = new HashSet<SäiliöHuoltopyyntö>();
            SäiliöMuistutus = new HashSet<SäiliöMuistutu>();
        }

        public int SäiliöId { get; set; }
        public int SäiliöNro { get; set; }
        public DateTime? Vakaus { get; set; }
        public DateTime? Välitarkastus { get; set; }
        public DateTime? Määräaikaistarkastus { get; set; }
        public int? SäiliöInfoId { get; set; }

        public virtual SäiliöInfo? SäiliöInfo { get; set; }
        public virtual ICollection<Auto> Autos { get; set; }
        public virtual ICollection<SäiliöHuollot> SäiliöHuollots { get; set; }
        public virtual ICollection<SäiliöHuoltopyyntö> SäiliöHuoltopyyntös { get; set; }
        public virtual ICollection<SäiliöMuistutu> SäiliöMuistutus { get; set; }
    }
}
