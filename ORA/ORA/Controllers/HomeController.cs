using System.Web.Mvc;

namespace ORA.Controllers
{
    public class HomeController : Controller
    {
        // GET: Assignment
        public ActionResult Index()
        {
            if (Session["Name"] != null)
            {
                return View("Index");
            }
            else
            {
                return PartialView("Login");
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}