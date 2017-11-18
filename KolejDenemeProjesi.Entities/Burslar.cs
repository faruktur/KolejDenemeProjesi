using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class Burslar:MyEntityBase
    {
        public string Miktar {get; set;}
        public string Aciklama { get; set; }

        public virtual BursTipleri BursTipi { get; set;}
        public virtual Donemler Donem { get; set; }
        public virtual Ogrenciler Ogrenci { get; set; }
    }
}
