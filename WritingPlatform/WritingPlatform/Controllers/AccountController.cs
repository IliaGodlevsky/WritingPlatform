using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using WritingPlatform.Models.Identity;
using WritingPlatform.Models.Users;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Register()
        {
            return View(new NewUserModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(NewUserModel model)
        {
            UserModel userModel = null;

            if (ModelState.IsValid)
            {
                userModel = userService.GetUsers().FirstOrDefault(user => user.Login == model.Login);

                if (userModel == null)
                {
                    userService.AddUser(model);
                    userModel = userService.GetUsers().FirstOrDefault(u => u.Login == model.Login);

                    if (userModel != null) 
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return Redirect($"/User/Index/{userModel.Id}");
                    }
                }
                else
                {
                    ModelState.AddModelError("Such a user exists", "User with such a login already exists");
                }
            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View(new Credentials());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Credentials model)
        {
            if (ModelState.IsValid)
            {
                UserModel userModel = userService.GetByCredentials(model);

                if (userModel != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return Redirect($"/User/Index/{userModel.Id}");
                }
                else
                {
                    ModelState.AddModelError("Such a user doesn't exist", "User with such a login doesn't exist");
                }
            }

            return View(model);
        }
    }
}