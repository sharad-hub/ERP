using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace ERP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult DashboardV1()
        {
            var userId = User.Identity.GetUserId();
            return View();
        }
        public ActionResult DashboardV2()
        {
            return View();
        }
    }
}