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
			GetResumesFromApi();
		}

		#region One
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
		#endregion

		#region Two
		public static void GetResumesFromApi()
		{
			var m = new Two_LongRequestSim();
			var r = m.GetResumes();
		}
		#endregion

		#region OnePlus
		public static void OnePlus()
		{
			var m = new NplusOne();
			var r = m.GetResumes();
		}

		public static void OnePlus_T()
		{
			var m = new NplusOne();
			var r = m.GetResumes_Tuned();
		}
		#endregion

		public static void MeasureCall(Action action)
		{
			var sw = Stopwatch.StartNew();
			action();
			sw.Stop();
			Console.WriteLine("ExecutionTime: " + sw.ElapsedMilliseconds);
		}
	}
}
