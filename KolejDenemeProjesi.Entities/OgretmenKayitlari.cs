namespace KolejDenemeProjesi.Entities
{
    public class OgretmenKayitlari: MyEntityBase
    {
        //Gerekirse ek alanlar eklenebilir

        public virtual Ogretmenler Ogretmen { get; set; }
        public virtual Donemler Donem { get; set; }
    }
}