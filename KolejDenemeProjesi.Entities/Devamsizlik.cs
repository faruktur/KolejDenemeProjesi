using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class Devamsizlik:MyEntityBase
    {
        public virtual Kisiler Kisi { get; set; }
        public virtual Donemler Donem { get; set; }
        public DateTime Tarih { get; set; }    
    }
}
