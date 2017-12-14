using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class Ogrenciler:MyEntityBase
    {




        public virtual Kisiler KisiselBilgiler { get; set; }
        public virtual List<Burslar> Burslar {get;set;}
        public List<OgrenciKayitlari> DonemKayitlari { get; set; }
        public virtual List<OgrenciVelileri> Veliler { get; set; }

        public Ogrenciler()
        {
            Burslar = new List<Entities.Burslar>();
            Veliler = new List<Entities.OgrenciVelileri>();
        }

    }
}
