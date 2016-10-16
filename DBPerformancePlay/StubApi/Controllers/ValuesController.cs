using FizzWare.NBuilder;
using PerfDemo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace StubApi.Controllers
{
	public class ValuesController : ApiController
	{
		// GET api/values
		public IEnumerable<GitHubResume> Get()
		{
			Thread.Sleep(10000);
			var data = Builder<GitHubResume>.CreateListOfSize(10000).All()
				.With(c => c.PiplMatchedDate = Faker.Date.Past())
				.With(c => c.Login = Faker.User.Username())
				.With(c => c.Location = Faker.Address.SecondaryAddress())
				.With(c => c.Name = Faker.Name.FullName())
				.With(c => c.Bio = Faker.Lorem.Paragraph(10))
				.With(c => c.Email = Faker.User.Email()).Build();

			return data;

		}

		// GET api/values/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
