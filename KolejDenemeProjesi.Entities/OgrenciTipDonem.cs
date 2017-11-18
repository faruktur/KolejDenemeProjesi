using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class OgrenciTipDonem:MyEntityBase
    {
        public string OgrenciNo { get; set; }

        public virtual Subeler Sube { get; set; }
        public virtual Ogrenciler Ogrenci { get; set; }
        public virtual Donemler Donem { get; set; }
        public virtual OgrenimTipleri OgrenimTipi {get;set;}
    }
}
