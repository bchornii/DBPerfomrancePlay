using PerfDemo.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace WebApp.Controllers
{
	[SessionState(SessionStateBehavior.ReadOnly)]
	public class DataController : AsyncController
    {
		[HttpPost]
		public async Task<JsonResult> SessionExampleAsync()
		{
			var res = await Task.Run<string>(() => {
				var db = new DataBal();
				return db.StubData();
			});
			return Json(res, JsonRequestBehavior.AllowGet);
		}
	}
}