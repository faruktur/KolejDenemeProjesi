using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class DersProgramlari:MyEntityBase
    {
        public virtual Donemler Donem { get; set; }
        public virtual Subeler Sube { get; set; }
        public virtual List<DersProgramiDersleri> Dersler { get; set; }
    }
}
