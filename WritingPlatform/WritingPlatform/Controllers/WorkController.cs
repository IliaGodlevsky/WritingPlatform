using System.Web.Mvc;
using WritingPlatform.Data.Entities;
using WritingPlatform.Models.Works;
using WritingPlatform.Service.Absractions;

namespace WritingPlatform.Controllers
{
    public class WorkController : Controller
    {
        private readonly IWorkService workService;

        public WorkController(IWorkService workService)
        {
            this.workService = workService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PublishWork(NewWorkModel work)
        {
            workService.AddWork(work);

            return Redirect("/user/index");
        }
    }
}