using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class GunTipleri:MyEntityBase
    {

        public string GunTipAdi { get; set; }

        public virtual List<DonemGunBilgileri> GunBilgileri { get; set; }
        public GunTipleri()
        {
            GunBilgileri = new List<Entities.DonemGunBilgileri>();
        }
    }
}
