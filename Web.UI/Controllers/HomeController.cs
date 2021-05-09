using Services.InterFaces.ICoreService.User;
using System.Web.Mvc;


namespace Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;


        public HomeController()
        {

        }
        public HomeController(IUserService userService)
        {
            this._userService = userService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            return    Json(_userService.Cards(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}