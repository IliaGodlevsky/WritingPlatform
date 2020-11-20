using System.Collections.Generic;
using System.Web.Mvc;
using WritingPlatform.Models;
using WritingPlatform.Models.Comments;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IWorkService workService;
        private readonly ICommentService commentService;

        public HomeController(
            IUserService userService,
            IWorkService workService,
            ICommentService commentService)
        {
            this.userService = userService;
            this.workService = workService;
            this.commentService = commentService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}