using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class OgrenciVelileri:MyEntityBase
    {
        public virtual Veliler Veli { get; set; }
        public virtual Ogrenciler Ogrenci { get; set; }
    }
}
