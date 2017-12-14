using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class OgrenimTipleri:MyEntityBase
    {
        public string OgrenimTip { get; set; }
        public virtual List<SinifSeviyeleri> SinifSeviyeleri { get; set; }

        public OgrenimTipleri()
        {
            SinifSeviyeleri = new List<Entities.SinifSeviyeleri>(); // nesne tanımlandığında NULL kalmaması için...
        }
    }
}
