using System.Collections.Generic;
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

        public UserController(IUserService userService, ICompositionService service)
        {
            this.userService = userService;
            compositionService = service;
        }

        [Authorize]
        public ActionResult Start()
        {
            var model = userService.GetUsers().
                FirstOrDefault(user => user.Login == User.Identity.Name);

            return View("Index", model);
        }

        public ActionResult Index(int id)
        {
            var model = userService.GetById(id);
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult MyCompositions(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userWithWorks = userService.GetUsersWithCompositions().
                    FirstOrDefault(user => id == user.Id);
                return View(userWithWorks);
            }

            return Redirect("/Account/Login");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userModel = userService.GetById(id);
            return View(userModel);
        }

        [Authorize]
        public ActionResult UpdateUser(UserModel update)
        {
            var userModel = userService.GetById(update.Id);

            userModel.Login = update.Login;
            userModel.Password = update.Password;
            userModel.Email = update.Email;

            userService.UpdateUser(userModel);

            userModel = userService.GetUsers().
               FirstOrDefault(user => user.Id == update.Id);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Account");
        }

        [Authorize]
        public ActionResult DeleteAccount(int id)
        {
            var user = userService.GetById(id);
            user.IsDeleted = true;
            userService.UpdateUser(user);

            return Redirect("/Account/Register");
        }

        public ActionResult Details(CompositionWithCommentsModel model)
        {
            return RedirectToAction("Details", "Composition", model);
        }

        [Authorize]
        public ActionResult PublishComposition(int id)
        {
            return Redirect($"/Composition/PublishComposition/{id}");
        }

        [Authorize]
        public ActionResult AllWorks(int id)
        {
            var ivm = CreateIndexViewModel(1, 3);
            return View(ivm);
        }

        [Authorize]
        public ActionResult AllWorksPaged(int page = 1)
        {
            var ivm = CreateIndexViewModel(page, 3);

            return View("AllWorks", ivm);
        }

        [Authorize]
        public ActionResult ReadComposition(CompositionWithCommentsModel model)
        {
            ViewBag.CurrentUser = userService.GetById(model.UserId);
            return View(model);
        }

        [Authorize]
        public ActionResult GetTop()
        {
            var users = userService.GetUsersWithCompositions();
            var compositions = new List<CompositionWithCommentsModel>();
            foreach(var user in users)
            {
                compositions.AddRange(user.Compositions);
            }

            compositions = compositions.AsEnumerable().
                OrderBy(composition => composition.Comments.Select(com => com.Mark).Average()).ToList();
            ViewBag.Ratings = compositions.Select(composition => composition.Comments.Select(com => com.Mark).Average()).ToList();
            return View(compositions);
        }

        private IndexViewModel<CompositionWithCommentsModel> CreateIndexViewModel(int pageNumber, int pageSize)
        {
            var compositions = compositionService.GetCompositionsWithComments();

            int totalPages = compositions.Count();

            var pageInfo = new PageInfo 
            { 
                PageNumber = pageNumber, 
                PageSize = pageSize, 
                TotalItems = totalPages 
            };

            return new IndexViewModel<CompositionWithCommentsModel> { PageInfo = pageInfo, Compositions = compositions };
        }
    }
}