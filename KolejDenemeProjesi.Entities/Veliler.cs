using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class Veliler : MyEntityBase
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TC { get; set; }
        public string Eposta { get; set; }
        public string Ceptel { get; set; }
        public string Ceptel2 { get; set; }
        public string İl { get; set; }
        public string İlce { get; set; }
        public string Semt_Mahalle { get;set; }
        public string Sokak { get; set; }
        public string ApartmanNo_Daire { get; set; }


        public virtual VeliYakinlikDereceleri YakinklikDerecesi { get; set; }
        public virtual List<OgrenciVelileri> Ogrenciler { get; set; }
        public virtual Kullanicilar KullaniciGiris { get; set; }

        public Veliler()
        {
            Ogrenciler = new List<OgrenciVelileri>();
        }
    }
}
