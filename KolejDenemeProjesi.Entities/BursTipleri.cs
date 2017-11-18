using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class BursTipleri:MyEntityBase
    {
        public string BursTipi { get; set; }

        public virtual List<Burslar> Burslar {get;set;}
    }
}
