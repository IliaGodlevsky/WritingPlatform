using System.Linq;
using System.Web.Mvc;
using WritingPlatform.Models.Users;
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

        [HttpGet]
        public ActionResult Index(UserModel userModel)
        {
            return View(userModel);
        }

        [Authorize]
        public ActionResult MyCompositions(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userWithWorks = userService.GetUsersWithCompositions().
                    FirstOrDefault(user => user.Login == User.Identity.Name);
                return View(userWithWorks);
            }

            return Redirect("/home/Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult AllCompositions()
        {
            if (User.Identity.IsAuthenticated)
            {
                var usersWithWorks = userService.GetUsersWithCompositions();
                return View(usersWithWorks);
            }

            return Redirect("/home/Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteAccount(int id)
        {
            var user = userService.GetById(id);
            user.IsDeleted = true;

            //userService.UpdateUser();
            //FormsAuthentication.SignOut();

            return Redirect("/home/index");
        }

        public ActionResult UpdateUser(int id)
        {
            var user = userService.GetById(id);

            return View();
        }
    }
}