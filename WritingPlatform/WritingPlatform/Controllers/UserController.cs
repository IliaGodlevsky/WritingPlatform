using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using WritingPlatform.Models;
using WritingPlatform.Models.Compositions;
using WritingPlatform.Models.Users;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly ICompositionService compositionService;

        public UserController(IUserService userService, 
            ICompositionService compositionService)
        {
            this.userService = userService;
            this.compositionService = compositionService;
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

        [HttpGet]
        [Authorize]
        public ActionResult MyCompositions(int page = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userModel = userService
                    .GetUsers()
                    .FirstOrDefault(user => user.Login == User.Identity.Name);

                if (userModel != null)
                {
                    var compositions = compositionService
                        .GetCompositions()
                        .Where(comp => comp.UserId == userModel.Id);

                    const int PAGE_SIZE = 30;

                    var compositionsPerPages = compositions
                        .Skip((page - 1) * PAGE_SIZE)
                        .Take(PAGE_SIZE);

                    var pageInfo = new PageInfo
                    {
                        PageNumber = page,
                        PageSize = PAGE_SIZE,
                        TotalItems = compositions.Count()
                    };

                    var ivm = new IndexViewModel<CompositionModel> 
                    { 
                        PageInfo = pageInfo, 
                        Collection = compositionsPerPages 
                    };

                    return View(ivm);
                }
            }
            return Redirect("/Account/Index");
        }
    }
}