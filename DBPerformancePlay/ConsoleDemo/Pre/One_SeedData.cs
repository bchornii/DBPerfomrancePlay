using DBPerformancePlay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo.Pre
{
	public class One_SeedData
	{
		private int standardAmount = 10000;
		public void SeedData(bool wait = false)
		{
			if (wait) System.Threading.Thread.Sleep(8000);
			var dbW = new DbWorker();
			dbW.SeedGitUsers(standardAmount*3);

		}

		public void SeedDataTuned(bool plinq = false)
		{
			var dbW = new DbWorker();
			var tList = new List<Task>();
			if (plinq)
			{
				for (var i = 0; i < 3; i++)
				{
					tList.Add(Task.Factory.StartNew(() =>
					{
						dbW.SeedGitUsers(standardAmount);
					}));
				}
				Task.WaitAll(tList.ToArray());
			} else
			{
				var amounts = new List<int>() { standardAmount, standardAmount, standardAmount };
				Parallel.ForEach(amounts, new ParallelOptions() { MaxDegreeOfParallelism = 3 }, (x) =>
				{
					dbW.SeedGitUsers(x);
				}
				);
			}
		}
	}
}
