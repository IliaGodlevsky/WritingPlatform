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

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index(int id)
        {
            ViewBag.CurrentUserId = id;

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

            if (userModel == null)
            {
                FormsAuthentication.SignOut();
                return Redirect("Account/Login");
            }

            return RedirectToAction($"/index/{userModel.Id}");
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
        public ActionResult ReadComposition(AuthoreCompositionModel model)
        {
            return View(model);
        }

        private IndexViewModel<AuthoreCompositionModel> CreateIndexViewModel(int pageNumber, int pageSize)
        {
            var users = userService.GetUsersWithCompositions();
            var compositions = new List<AuthoreCompositionModel>();

            foreach (var user in users)
            {
                foreach (var composition in user.Compositions)
                {
                    var authorComposition = new AuthoreCompositionModel
                    {
                        Id = composition.Id,
                        Name = composition.Name,
                        Genre = composition.Genre,
                        Content = composition.Content,
                        PublicationTime = composition.PublicationTime,
                        Rating = composition.Rating,
                        NumberOfMarks = composition.NumberOfMarks,
                        Author = user
                    };

                    compositions.Add(authorComposition);
                }
            }

            int totalPages = compositions.Count();
            compositions = compositions.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            var pageInfo = new PageInfo 
            { 
                PageNumber = pageNumber, 
                PageSize = pageSize, 
                TotalItems = totalPages 
            };

            return new IndexViewModel<AuthoreCompositionModel> { PageInfo = pageInfo, Compositions = compositions };
        }
    }
}