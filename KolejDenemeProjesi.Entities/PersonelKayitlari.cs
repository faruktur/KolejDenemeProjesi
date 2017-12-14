using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class PersonelKayitlari : MyEntityBase
    {
        //Ek alanlar eklenebilir
        public virtual Personeller Personel { get; set; }
        public virtual Donemler Donem { get; set; }
    }
}
