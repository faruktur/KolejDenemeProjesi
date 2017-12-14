using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KolejDenemeProjesi.Entities.Init
{
    public enum MyEnum
    {
        [Description("Admin")]
        Admin,
        [Description("Ogrenci")]
        Ogrenci,
        [Description("Ogretmen")]
        Ogretmen,
        [Description("Veli")]
        Veli,
        [Description("Personel")]
        Personel
    }

}

