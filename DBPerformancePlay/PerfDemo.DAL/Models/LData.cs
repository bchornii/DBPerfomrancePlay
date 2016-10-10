using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfDemo.DAL.Models
{
	[Table("LData")]
	public class LData
	{
		public long Id { get; set; }
		public string Rstring { get; set; }
		public long Rnumber { get; set; }

		public void Randomize()
		{
			//Rnumber = Helper.R.Next();
			//Rstring = Helper.GetLorem();
		}
	}
}
