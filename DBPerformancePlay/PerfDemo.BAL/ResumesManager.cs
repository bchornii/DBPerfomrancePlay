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

		public bool Remove(int id)
		{
			return dbWorker.RemoveResume(id);
		}
	}
}
