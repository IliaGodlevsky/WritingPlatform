using System.Linq;
using System.Web.Mvc;
using WritingPlatform.Models.Compositions;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.Controllers
{
    public class CompositionController : Controller
    {
        private readonly IUserService userService;
        private readonly ICommentService commentService;
        private readonly IMarkService markService;

        public CompositionController(
            IUserService userService, 
            ICommentService commentService,
            IMarkService markService)
        {
            this.userService = userService;
            this.commentService = commentService;
            this.markService = markService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(CompositionModel model)
        {
            var marks = markService
                .GetMarks()
                .Where(mark => mark.CompositionId == model.Id);

            var comments = commentService
                .GetComments()
                .Where(comment => comment.CompositionId == model.Id);

            var author = userService
                .GetUsers()
                .FirstOrDefault(user => user.Id == model.UserId);

            var detailedComposition = new DetailedCompositionModel
            {
                Id = model.Id,
                Author = author,
                PublicationTime = model.PublicationTime,
                Genre = model.Genre,
                Name = model.Name,
                Comments = comments,
                Mark = marks.Average(mark => mark.Rating)
            };

            return View(detailedComposition);
        }

        public ActionResult Read(string content)
        {

            return View(content);
        }
    }
}