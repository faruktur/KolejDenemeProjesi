using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class Branslar :MyEntityBase
    {
        public string BransAdi { get; set; }


        public List<Ogretmenler> Ogretmenler { get; set; }
    }
}
