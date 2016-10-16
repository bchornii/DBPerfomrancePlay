using DBPerformancePlay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
	public class HomeController : BaseController
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult SimpleView()
		{
			return View();
		}

		[OutputCache(Duration = 30, VaryByParam = "none")]
		public JsonResult Resumes(int count = 50000)
		{
			var dbWorker = new DbWorker();
			return Json(dbWorker.GetResumes(50000), JsonRequestBehavior.AllowGet);
		}

		public async Task<JsonResult> SessionExampleAsync()
		{
			return await Task.Run<JsonResult>(() => {
				var data = "Stubbed data: " + DateTime.Now;
				Thread.Sleep(5000);
				return Json(data, JsonRequestBehavior.AllowGet);
			});
		}
	}
}