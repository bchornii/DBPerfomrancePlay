using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using EntityFramework.BulkInsert.Extensions;
using BenchmarkDotNet.Attributes;
using PerfDemo.DAL.Models;
using PerfDemo.DAL;
using EntityFramework;
using System.Data.Entity;

namespace DBPerformancePlay
{
	public class DbWorker
	{
		public List<GitHubUser> GetAllUsers()
		{
			using (var context = new GitDbContext())
			{
				var k = context.GitHubUsers.ToList();
				return k;
			}
		}

		public List<GitHubResume> GetAllResumes()
		{
			using (var context = new GitDbContext())
			{
				return context.GitHubResumes.ToList();
			}
		}
		public List<GitHubResume> GetResumes(int count = 50000, bool notracking = false)
		{
			using (var context = new GitDbContext())
			{
				IQueryable<GitHubResume> data;
				if (notracking) data = context.GitHubResumes.AsNoTracking();
				else data = context.GitHubResumes;
				return data.Take(count).ToList();
			}
		}

		public int GetResumesCount(bool fast = false)
		{
			using (var context = new GitDbContext())
			{
				if (fast)
					return context.GitHubResumes.Count();
				else 
					return context.GitHubResumes.ToList().Count;
			}
		}


		public void SeedLData(int amount = 1000)
		{
			var data = new List<LData>();
			for (var i = 0; i < amount; i++)
			{
				var item = new LData();
				item.Randomize();
				data.Add(item);
			}
			using (var context = new GitDbContext())
			{
				//context.BulkInsert(data);
				context.SaveChanges();
			}
		}

		public void SeedGitUsers(int amount = 10000, bool tuned = false)
		{
			var data = Builder<GitHubResume>.CreateListOfSize(amount).All()
				.With(c => c.PiplMatchedDate = Faker.Date.Past())
				.With(c => c.Login = Faker.User.Username())
				.With(c => c.Location = Faker.Address.SecondaryAddress())
				.With(c => c.Name = Faker.Name.FullName())
				.With(c => c.Bio = Faker.Lorem.Paragraph(10))
				.With(c => c.Email = Faker.User.Email())
				.Build();

			using (var context = new GitDbContext())
			{
				if (tuned)
				{
					context.BulkInsertAsync(data, amount).Wait();
				} else
				{
					context.GitHubResumes.AddRange(data);
					context.SaveChanges();
				}
				// EFBatchOperation.For(context, context.GitHubResumes).InsertAll(data);
				//context.AttachAndModify(data);
				//context.BulkInsert(data);
				//context.GitHubResumes.AddRange(data);
				// context.SaveChanges();
			}
		}

		public void Seed()
		{
			SeedGitUsers(tuned: true);
			SeedRandomContact();
		}

		public void SeedRandomContact(int count = 100000)
		{
			var rand = new Random();
			using (var context = new GitDbContext())
			{
				var ids = context.GitHubResumes.OrderBy(x=>Guid.NewGuid()).Take(count).Select(x => x.Id).ToList();
				var toSaveList = new List<ContactData>();
				foreach (var id in ids)
				{
					var amount = rand.Next(1, 5);
					for(var i=0; i<amount; i++)
					{
						var cd = new ContactData() { GitHubResumeId = id, ContactType = (ContactType)rand.Next(2) };
						if (cd.ContactType == ContactType.Address) cd.Data = Faker.Address.SecondaryAddress();
						else if (cd.ContactType == ContactType.Email) cd.Data = Faker.User.Email();
						else cd.Data = Faker.Number.RandomNumber(950000000, 959999999).ToString();
						cd.PersonalKey = Faker.User.Password(10, true);
						toSaveList.Add(cd);
					}
				}
				//context.ContactDatas.AddRange(toSaveList)
				context.BulkInsertAsync(toSaveList).Wait();
			}
		}

		/// <summary>
		/// Remove example
		/// </summary>
		/// <param name="id"></param>
		/// <param name="tuned"></param>
		/// <returns></returns>
		public bool RemoveResume(int id, bool tuned = false)
		{
			using (var context = new GitDbContext())
			{
				if (!tuned)
				{
					var item = context.GitHubResumes.Find(id);
					context.GitHubResumes.Remove(item);
					context.SaveChanges();
				} else
				{
					var item = new GitHubResume() { Id = id };
					context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
					context.SaveChanges();
				}
			}
			return true;
		}

		public List<GitHubResume> GetResumesWithContacts(bool tuned = false, int count = 1000)
		{
			using (var context = new GitDbContext())
			{
				IQueryable<GitHubResume> resumes = null;
				if (!tuned)
				{
					resumes = context.GitHubResumes.Where(x => x.Contacts.Any()).Take(count);
					
				}
				else
				{
					resumes = context.GitHubResumes.Include(x => x.Contacts).Where(x => x.Contacts.Any()).Take(count);
				}
				foreach (var r in resumes)
				{
					foreach (var c in r.Contacts)
					{
						// hide personal key
						c.PersonalKey = string.Empty;
					}
				}
				return resumes.ToList();
			}
		}

		/// <summary>
		/// Get Resumes with complex sql logic that should take some time
		/// </summary>
		/// <returns></returns>
		public List<GitHubResume> ResumesByComplexQuery()
		{
			using (var context = new GitDbContext())
			{
				var result = context.GitHubResumes.SqlQuery("Select * FROM GitHubResume WHERE PiplMatchedDate IN (SELECT top 100 PiplMatchedDate From GitHubResume ORDER BY NEWID())").ToList();
				return result;
			}
		}

		// <summary>
		/// Get Resumes with complex sql logic that should take some time
		/// </summary>
		/// <returns></returns>
		public int ExecuteComplexQuery()
		{
			using (var context = new GitDbContext())
			{
				return context.Database.ExecuteSqlCommand("Select * FROM GitHubResume WHERE PiplMatchedDate IN (SELECT top 1000 PiplMatchedDate From GitHubResume ORDER BY NEWID())");
			}
		}
	}
}
