using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class Personeller:MyEntityBase
    {
        public virtual Kisiler KisiselBilgiler { get; set; }
        public virtual PersonelTipleri PersonelTipi { get; set; }
    }
}
