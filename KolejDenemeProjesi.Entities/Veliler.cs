using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class Veliler : MyEntityBase
    {
       


        public virtual VeliYakinlikDereceleri YakinklikDerecesi { get; set; }
        public virtual List<OgrenciVelileri> Ogrenciler { get; set; }
        public virtual Kisiler KisiselBilgiler { get; set; }

        public Veliler()
        {
            Ogrenciler = new List<OgrenciVelileri>();
        }
    }
}
