using System.Linq;
using System.Web.Mvc;
using WritingPlatform.Data.Entities;
using WritingPlatform.Models.Users;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService userService;

        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(Credential credential)
        {
            return View();
        }

        public ActionResult Login(Credential credential)
        {
            var users = userService.GetUsers();

            if (users.Any(user => user.Login == credential.Login))
            {

            }

            return Redirect("/index");
        }
    }
}