using System.Web.Mvc;
using WritingPlatform.Models.Compositions;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.Controllers
{
    public class CompositionController : Controller
    {
        private readonly ICompositionService workService;

        public CompositionController(ICompositionService workService)
        {
            this.workService = workService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PublishWork(NewCompositionModel work)
        {
            try
            {
                workService.AddWork(work);
            }
            catch
            {

            }

            return Redirect("/user/index");
        }
    }
}