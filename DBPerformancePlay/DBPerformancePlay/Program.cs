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

			var data = dbW.ExecuteComplexQuery();

			var tasks = new List<Task>();
			

			//MeasureCall(() =>
			//{
			//	dbW.SeedRandomContact();
			//});

			//MeasureCall(() =>
			//{
			//	var z = dbW.GetResumes(200000);
			//});

			//MeasureCall(() =>
			//{
			//	var z = dbW.GetResumes(200000);
			//});
			//MeasureCall(() =>
			//{
			//	var z = dbW.GetResumes(200000, true);
			//});
			Console.WriteLine("Done");
			Console.ReadLine();
		}

		public static void MeasureCall(Action action)
		{
			var sw = Stopwatch.StartNew();
			action();
			sw.Stop();
			Console.WriteLine("ExecutionTime: " + sw.ElapsedMilliseconds);
		}
	}
}
