using DBPerformancePlay;
using PerfDemo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.Pre
{
	public class Two_LongRequestSim
	{
		public List<GitHubResume> GetResumes()
		{
			var dbWorker = new DbWorker();
			// simulate Service long waiting request
			System.Threading.Thread.Sleep(8000);
			return dbWorker.GetResumes(10, true);
		}
	}
}
