using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class Kullanicilar:MyEntityBase
    {
        public string Username { get; set; }
        public string Sifre { get; set; }
        
        public virtual KullaniciTipleri KullaniciTip { get; set; }
    }
}
