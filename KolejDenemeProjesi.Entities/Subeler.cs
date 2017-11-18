using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class Subeler:MyEntityBase
    {
        public string SubeAdi { get; set; }
        public virtual SinifSeviyeleri Seviye { get; set; }
        public virtual List<OgrenciTipDonem> Ogrenciler { get; set; }
        public virtual SinifSeviyeleri SinifSeviyesi { get; set; }
        public virtual DersProgramlari DersProgrami { get; set; }
    }
}
