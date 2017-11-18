using System.Web.Mvc;

namespace KolejDenemeProjesi.Web.Areas.Veli
{
    public class VeliAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Veli";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Veli_default",
                "Veli/{controller}/{action}/{id}",
                new { controller="Home",action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}