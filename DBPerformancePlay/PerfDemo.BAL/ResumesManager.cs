using DBPerformancePlay;
using PerfDemo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfDemo.BAL
{
	public class ResumesManager
	{
		private DbWorker dbWorker = new DbWorker();
		/// <summary>
		/// Very terible represenetation of buisness logic method
		/// </summary>
		/// <param name="count"></param>
		/// <returns></returns>
		public List<GitHubResume> Get(int count, bool tuned = false)
		{
			
			if (tuned)
			{
				return dbWorker.GetResumes(count, true);
			}
			else
				return dbWorker.GetAllResumes().Take(count).ToList();
		}

		public int GetResumesCount(bool tuned = false)
		{
			VerifyUserRole();
			IsAuthorized();
			InitUserManager();
			return dbWorker.GetResumesCount(tuned);
		}

		public bool Remove(int id)
		{
			return dbWorker.RemoveResume(id);
		}

		public void VerifyUserRole()
		{
			for (var i =0; i< 10000; i++)
			{
				IsAuthorized();
				var k = "mess" + i.ToString();
			}
		}

		public void IsAuthorized()
		{
			var k = 200;
		}

		public void InitUserManager()
		{
			// some rtequest to extra service
		}
	}
}
