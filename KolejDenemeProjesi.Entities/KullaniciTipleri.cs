using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class KullaniciTipleri:MyEntityBase
    {
        public string Tip { get; set; }

        public virtual List<Kullanicilar> Kullanicilar { get; set; }
    }
}
