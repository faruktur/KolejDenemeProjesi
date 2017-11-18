using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities
{
    public class VeliYakinlikDereceleri:MyEntityBase
    {
        public string Yakinlik { get; set; }
        
        public List<Veliler> Veliler { get; set; }

        public VeliYakinlikDereceleri()
        {
            Veliler = new List<Entities.Veliler>();
        }
    }
}
