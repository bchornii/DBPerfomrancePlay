using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PerfDemo.BAL
{
    public class DataBal
    {
		public string StubData(int wait = 3000)
		{
			var data = "Stubbed data: " + DateTime.Now;
			Thread.Sleep(wait);
			return data;
		}
    }
}
