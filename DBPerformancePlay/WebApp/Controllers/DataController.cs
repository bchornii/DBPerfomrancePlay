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
		// GET: Data
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