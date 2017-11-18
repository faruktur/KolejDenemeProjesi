using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class DonemGunBilgileri : MyEntityBase
    {
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }

        public virtual GunTipleri GunTipi { get; set; }
        public virtual DonemTakvimi Takvim { get; set; }

    }
}
