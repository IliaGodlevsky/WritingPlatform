using System.Linq;
using System.Web.Mvc;
using WritingPlatform.Models;
using WritingPlatform.Models.Users;
using WritingPlatform.Models.Works;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IWorkService workService;
        private readonly ICommentService commentService;

        public UserController(
            IUserService userService,
            IWorkService workService,
            ICommentService commentService)
        {
            this.userService = userService;
            this.workService = workService;
            this.commentService = commentService;
        }

        [HttpGet]
        public ActionResult Index(UserModel userModel)
        {
            return View(userModel);
        }

        [Authorize]
        public ActionResult MyWorks()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = userService.GetUsers().FirstOrDefault(u => u.Login == User.Identity.Name);
                var works = workService.GetWorks();
                var comments = commentService.GetComments();

                var worksWithComments = works.GroupJoin(comments,
                    work => work.Id,
                    comment => comment.WorkId,
                    (work, comment) =>
                    new WorkWithCommentsModel
                    {
                        Comments = comment,
                        Name = work.Name,
                        UserId = work.UserId,
                        Genre = work.Genre,
                        TextOfWork = work.TextOfWork,
                        Rating = work.Rating,
                        PublicationTime = work.PublicationTime
                    });

                var userWorks = worksWithComments.Where(work => work.UserId == user.Id);

                var userWithWorks = new UserWithWorksModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Login = user.Login,
                    IsDeleted = user.IsDeleted,
                    Works = userWorks,
                    Email = user.Email,
                    BirthDay = user.BirthDay
                };

                return View(userWithWorks);
            }

            return Redirect("/home/Index");
        }

        [HttpGet]
        public ActionResult AllWorks()
        {
            return View();
        }
        
        public ActionResult AddWork(NewWorkModel model)
        {
            workService.AddWork(model);

            return Redirect("/user/myworks");
        }
    }
}