using System.Web.Mvc;
using WritingPlatform.Models.Comments;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService service)
        {
            commentService = service;
        }

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddComment(NewCommentModel model)
        {
            commentService.AddComment(model);

            return RedirectToAction("Start", "User");
        }
    }
}