using DBPerformancePlay;
using PerfDemo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.Pre
{
	public class NplusOne
	{
		public List<GitHubResume> GetResumes()
		{
			var result = new List<GitHubResume>();

			var dbw = new DbWorker();
			result = dbw.GetResumesWithContacts();

			return result;
		}

		public List<GitHubResume> GetResumes_Tuned()
		{
			var result = new List<GitHubResume>();

			var dbw = new DbWorker();
			result = dbw.GetResumesWithContacts(true);

			return result;
		}
	}
}
