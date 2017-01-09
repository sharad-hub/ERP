using System.Web.Mvc;

namespace ERP.Areas.Factory
{
    public class FactoryAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Factory";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Factory_default",
                "Factory/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}