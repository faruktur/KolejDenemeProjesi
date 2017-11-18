using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class DersProgramiDersleri:MyEntityBase
    {
        public virtual Dersler Ders { get; set; }
        public virtual List<DersProgramiDersOgretmenleri> Ogretmenler { get; set; }
    }
}
