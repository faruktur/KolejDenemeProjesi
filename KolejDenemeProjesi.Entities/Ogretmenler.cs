using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class Ogretmenler:MyEntityBase
    {
        public virtual Branslar Brans { get; set; }
        public virtual OgretmenUnvanlari Unvan { get; set; }
        public virtual Kisiler KisiselBilgiler { get; set; }
        public virtual List<OgretmenKayitlari> DonemKayitlari { get; set; }
    }
}
