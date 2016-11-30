using DBPerformancePlay;
using PerfDemo.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ResumeController : Controller
    {
		ResumesManager rm = new ResumesManager();
		// GET: Resume
		public ActionResult Index()
		{
            return View(rm.Get(100, true));
        }

		public ActionResult Dashboard()
		{
			return View();
		}

		[HttpPost]
		public int GetCountSlow()
		{
			return rm.GetResumesCount();
		}

		[HttpPost]
		public int GetCountFast()
		{
			return rm.GetResumesCount(true);
		}

		[HttpPost]
		public JsonResult Delete(int id)
		{
			return Json(rm.Remove(id));
		}
    }
}