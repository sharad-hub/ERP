using System.Web.Mvc;

namespace ERP.Areas.MarketingExecutive
{
    public class MarketingExecutiveAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MarketingExecutive";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MarketingExecutive_default",
                "MarketingExecutive/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}