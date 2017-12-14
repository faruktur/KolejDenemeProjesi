using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class Donemler:MyEntityBase
    {
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string DonemKodu { get; set; }
        public string Aciklama { get; set;}
        public virtual List<DonemTakvimi> Takvimler {get;set;}
        public List<Devamsizlik> Devamsizliklar { get; set; }
        public List<OgrenciKayitlari> OgrenciKayitlari { get; set; }
        public List<OgretmenKayitlari> OgretmenKayitlari { get; set; }
        public List<PersonelKayitlari> PersonelKayitlari { get; set; }
    }
}
