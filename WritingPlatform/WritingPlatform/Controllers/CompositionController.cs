using System;
using System.Web.Mvc;
using WritingPlatform.Models.Compositions;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.Controllers
{
    public class CompositionController : Controller
    {
        private readonly ICompositionService compositionService;

        public CompositionController(ICompositionService compositionService)
        {
            this.compositionService = compositionService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(CompositionWithCommentsModel model)
        {
            return View(model);
        }

        public ActionResult PublishComposition(int id)
        {
            var newComposition = new NewCompositionModel
            {                
                UserId = id,
                Name = string.Empty,
                Genre = string.Empty,
                Content = string.Empty
            };

            return View(newComposition);
        }

        public ActionResult AddComposition(NewCompositionModel model)
        {
            model.PublicationTime = DateTime.Now.Date;
            compositionService.AddWork(model);

            return Redirect($"/User/Index/{model.UserId}");
        }
    }
}