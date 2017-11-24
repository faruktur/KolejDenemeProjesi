# Okul Bilgi Sistemi  
ASP.Net MVC
Jquery/Javascript
MS-SQL
Codefirst

                          Kodlar ile ilgili genel açıklamalar
BusinessLayer : İş katmanı.Veritabanı işlemleri için gerekli fonksiyonlar,parametreleri ve geri dönüş değerleri mevcut(BusinessLayerResult)
Common   : Katmanlar arasında objelerin değerlerini aktarır.
Core : Katmanlar arası Nesne/Class implement ilişkilerini sağlar.
Entities : ORM nesneleri ve  kullanılacak bazı nesneler tanımlanır.
DataAccess : Veritabanına erişim sağladığımız katman burasıdır. BusinessLayer içerisindeki metotlar ile bu katmana erişmekteyiz 
Web(User Interface) : Sadece arayüz katmanını ilgilendirecek kodlar yazılır.Bu proje için örneklendirirsek yalnızca Asp.net MVC için kodlar yer almaktadır.


          C   | →        User Interface                                 ← |  C
          O   |         ↓Func1(data)     ↑   return Message               |  O
          M   |         ↓Func2(data)     ↑   return Message               |  R
          M   | →       BusinessLayer                                   ← |  E
          O   |         ↓Repo1(data)     ↑ return Businesslayerresult1    |
          N   |         ↓Repo2(data)     ↑ return Businesslayerresult2    |
              | →       DataAccessLayer                                 ← |
              |         ↓Data            ↑ return result1                 |
              |         ↓Data            ↑ return result2                 |
              |         Database                                          |
