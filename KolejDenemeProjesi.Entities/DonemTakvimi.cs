using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class DonemTakvimi : MyEntityBase
    {
       
        public string Aciklama { get; set; }
       
        public int EgitimGunSayisi { get; set; }
       
        public int GunlukSure { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BaslangicTarihi { get; set; }
      
        [DataType(DataType.DateTime)]
        public DateTime BitisTarihi { get; set; }
     
        [DataType(DataType.DateTime)]
        public DateTime İlkDersTarihi { get; set; }
      
        [DataType(DataType.DateTime)]
        public DateTime SonDersTarihi { get; set; }
    
        [DataType(DataType.DateTime)]
        public DateTime MezuniyetTarihi { get; set; }


        public virtual OgrenimTipleri OgrenimTip { get; set; }
        public virtual Donemler Donem { get; set; }
        public virtual List<DonemGunBilgileri> GunBilgileri { get; set; }
        
        public DonemTakvimi()
        {
            GunBilgileri = new List<DonemGunBilgileri>();
        }
    }
}
