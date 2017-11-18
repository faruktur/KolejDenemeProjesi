using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class Dersler:MyEntityBase
    {
        public string DersAdi { get; set; }
       
        public virtual OgrenimTipleri OgrenimTip { get; set; }
        public virtual SinifSeviyeleri SinifSeviye { get; set; }
    }
}
