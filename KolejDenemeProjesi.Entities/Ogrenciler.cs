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
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TC_No{ get; set; }
        public string OkulNo { get; set; }
        public string Email { get; set; }
        public DateTime DogumTarihi{ get; set; }
        [ScaffoldColumn(false)]
        public bool isActive { get; set; }
        

        public virtual Kullanicilar KullaniciGiris{get;set;}
        public virtual List<Burslar> Burslar {get;set;}
        public virtual List<OgrenciTipDonem> Donemler { get; set; }
        public virtual List<OgrenciVelileri> Veliler { get; set; }

        public Ogrenciler()
        {
            Burslar = new List<Entities.Burslar>();
            Donemler = new List<OgrenciTipDonem>();
            Veliler = new List<Entities.OgrenciVelileri>();
        }

    }
}
