using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class DersProgramiDersOgretmenleri : MyEntityBase
    {
        public virtual DersProgramiDersleri Ders { get; set; }
        public virtual Ogretmenler Ogretmen { get; set; }
    }
}
