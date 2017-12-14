using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class OgretmenUnvanlari:MyEntityBase
    {
        public string Unvan { get; set; }
        public List<Ogretmenler> Ogretmenler { get; set; }
    }
}
