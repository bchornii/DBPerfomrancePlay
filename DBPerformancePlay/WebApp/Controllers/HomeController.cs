using DBPerformancePlay;
using PerfDemo.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

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
			MemoryCache.Default.Add(new CacheItem("asd", "asd"), new CacheItemPolicy());
			var dbWorker = new DbWorker();
			return Json(dbWorker.GetResumes(50000), JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult SessionExampleSync()
		{
			//return await Task.Run<JsonResult>(() => {
			Session["tick"] = DateTime.Now.Ticks;
			var db = new DataBal();
			return Json(db.StubData(), JsonRequestBehavior.AllowGet);
			//});
		}

		[HttpGet]
		public JsonResult SessionExampleSync(object data)
		{
			//return await Task.Run<JsonResult>(() => {
			var db = new DataBal();
			return Json(db.StubData(), JsonRequestBehavior.AllowGet);
			//});
		}

		[HttpGet]
		public async Task<JsonResult> SessionExampleAsync()
		{
			return await Task.Run<JsonResult>(() => {
				Session["ticks"] = DateTime.Now.Ticks;
				var db = new DataBal();
				return Json(db.StubData(), JsonRequestBehavior.AllowGet);
			});
		}

		[HttpPost]
		public async Task<JsonResult> SessionExampleAsync(object data)
		{
			return await Task.Run<JsonResult>(() => {
				Session["tick"] = DateTime.Now.Ticks;
				var db = new DataBal();
				return Json(db.StubData(), JsonRequestBehavior.AllowGet);
			});
		}
	}
}