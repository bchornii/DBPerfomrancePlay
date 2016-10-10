using BenchmarkDotNet.Running;
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
			var z = dbW.GetResumes();
			//z = dbW.GetResumes();
			//z = dbW.GetResumes();

			//Task.WaitAll(tasks.ToArray());
			//sw.Stop();
			//Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
			//Console.ReadLine();
		}
	}
}
