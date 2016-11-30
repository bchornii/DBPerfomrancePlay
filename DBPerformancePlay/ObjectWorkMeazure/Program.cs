using PerfDemo.DAL.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectWorkMeazure
{
	class Program
	{
		static void Main(string[] args)
		{
			var z = GetNumbers();
			foreach (var k in z) Console.WriteLine(k);
			Console.ReadLine();
			return;

			var client = new RestClient("http://localhost/WebApp/home/");
			var request = new RestRequest("Resumes", Method.GET);
			string end = string.Empty;
			do
			{
				var sw = Stopwatch.StartNew();
				var result = client.Execute(request);
				sw.Stop();
				Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
				end = Console.ReadLine();
			} while (String.IsNullOrEmpty(end));
			
		}

		private static IEnumerable<int> GetNumbers()
		{
			var number = 0;
			while (true)
			{
				if (number > 10)
					yield break;

				yield return number++;
			}
		}
	}
}
