using NLipsum.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPerformancePlay
{
	public class Helper
	{
		public static Random R = new Random();
		public static LipsumGenerator GR = new LipsumGenerator();
		public static string GetLorem()
		{
			return GR.GenerateLipsum(R.Next(0, 10));
		}
	}
}
