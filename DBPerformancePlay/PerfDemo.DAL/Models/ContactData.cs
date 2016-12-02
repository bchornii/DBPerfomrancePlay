using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfDemo.DAL.Models
{
	[Table("ContactDatas")]
	public class ContactData
	{
		[Key]
		public int Id { get; set; }
		public ContactType ContactType { get; set; }
		public string Data { get; set; }
		public string PersonalKey { get; set; }
		public int GitHubResumeId { get; set; }
		[ForeignKey("GitHubResumeId")]
		public virtual GitHubResume GitHubResume { get; set; }
	}

	public enum ContactType
	{
		Phone,
		Email,
		Address
	}
}
