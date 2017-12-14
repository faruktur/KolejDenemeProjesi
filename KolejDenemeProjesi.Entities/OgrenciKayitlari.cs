namespace KolejDenemeProjesi.Entities
{
    public class OgrenciKayitlari : MyEntityBase
    {
        public string OkulNo { get; set; }

        public virtual OgrenimTipleri OgrenimTipi { get; set; }
        public virtual SinifSeviyeleri Seviye { get; set; }
        public virtual Subeler Sube { get; set; }
        public virtual Donemler Donem { get; set; }
        public virtual Ogrenciler Ogrenci { get; set; }
    }
}