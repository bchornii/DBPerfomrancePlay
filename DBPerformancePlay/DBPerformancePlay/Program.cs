using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPerformancePlay
{
	class Program
	{
		static void Main(string[] args)
		{
			var dbW = new DbWorker();
			var sw = Stopwatch.StartNew();
			var tasks = new List<Task>();
			tasks.Add(Task.Run(() =>
			{
				dbW.SeedGitUsers(50000);
			}));
			tasks.Add(Task.Run(() =>
			{
				dbW.SeedGitUsers(50000);
			}));
			tasks.Add(Task.Run(() =>
			{
				dbW.SeedGitUsers(50000);
			}));
			//tasks.Add(Task.Run(() =>
			//{
			//	dbW.SeedGitUsers(50000);
			//}));
			//tasks.Add(Task.Run(() =>
			//{
			//	dbW.SeedGitUsers(50000);
			//}));
			//tasks.Add(Task.Run(() =>
			//{
			//	dbW.SeedGitUsers(50000);
			//}));
			//tasks.Add(Task.Run(() =>
			//{
			//	dbW.SeedGitUsers(50000);
			//}));
			//tasks.Add(Task.Run(() =>
			//{
			//	dbW.SeedLData(50000);
			//}));
			//tasks.Add(Task.Run(() =>
			//{
			//	dbW.SeedLData(50000);
			//}));
			//tasks.Add(Task.Run(() =>
			//{
			//	dbW.SeedLData(100000);
			//}));
			//tasks.Add(Task.Run(() =>
			//{
			//	dbW.SeedLData(25000);
			//}));
			//tasks.Add(Task.Run(() =>
			//{
			//	dbW.SeedLData(25000);
			//}));
			//tasks.Add(Task.Run(() =>
			//{
			//	dbW.SeedLData(25000);
			//}));
			//tasks.Add(Task.Run(() =>
			//{
			//	dbW.SeedLData(25000);
			//}));
			//tasks.Add(Task.Run(() =>
			//{
			//	dbW.SeedLData(25000);
			//}));
			//tasks.Add(Task.Run(() =>
			//{
			//	dbW.SeedLData(25000);
			//}));

			Task.WaitAll(tasks.ToArray());
			sw.Stop();
			Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
			Console.ReadLine();
		}
	}
}
