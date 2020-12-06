using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
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

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            UserModel model;

            if (User.Identity.IsAuthenticated)
            {
                model = userService.GetUsers().
                    FirstOrDefault(user => user.Login == User.Identity.Name);
                if (model != null)
                {
                    return View(model);
                }
            }

            return Redirect("/Account/Index");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Account/Index");
        }
    }
}