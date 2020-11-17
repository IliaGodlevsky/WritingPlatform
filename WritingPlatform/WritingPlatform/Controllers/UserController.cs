using System.Web.Mvc;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAll()
        {
            var users = userService.GetUsers();

            return View(users);
        }

        public ActionResult ShowUser(int id)
        {
            var user = userService.GetById(id);

            return View(user);
        }
    }
}