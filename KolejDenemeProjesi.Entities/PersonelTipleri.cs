using System.Collections.Generic;

namespace KolejDenemeProjesi.Entities
{
    public class PersonelTipleri:MyEntityBase
    {
        public string TipAdi { get; set; }

        public List<Personeller> Personeller { get; set; }
    }
}