using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class SinifSeviyeleri:MyEntityBase
    {
        public string Seviye { get; set; }
        

      
        public virtual OgrenimTipleri OgrenimTip { get; set; }
        public virtual List<Subeler> Subeler { get; set; }

        public SinifSeviyeleri()
        {
            Subeler = new List<Entities.Subeler>();
        }
    }
}
