using ConsoleDemo.Pre;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			SeedTaskExample();
		}

		public static void SeedTaskExample_Sleep()
		{
			var m = new One_SeedData();
			m.SeedDataTuned(true);
		}

		public static void SeedTaskExample()
		{
			var m = new One_SeedData();
			m.SeedData();
		}

		public static void SeedTaskExample_Tuned()
		{
			var m = new One_SeedData();
			m.SeedDataTuned();
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
