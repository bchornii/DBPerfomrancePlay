using DBPerformancePlay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.BulkInsert.Extensions;

namespace DBPerformancePlay
{
	public class DbWorker
	{
		public List<GitHubUser> GetAllUsers()
		{
			using (var context = new GitDbContext())
			{
				var k = context.GitHubUsers.ToList();
				return k;
			}
		}

		public void SeedLData(int amount = 1000)
		{
			var data = new List<LData>();
			for (var i =0; i<amount; i++)
			{
				var item = new LData();
				item.Randomize();
				data.Add(item);
			}
			using (var context = new GitDbContext())
			{
				context.BulkInsert(data);
				context.SaveChanges();
			}
		}

	}
}
