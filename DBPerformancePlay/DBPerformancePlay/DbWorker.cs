﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using EntityFramework.BulkInsert.Extensions;
using BenchmarkDotNet.Attributes;
using PerfDemo.DAL.Models;
using PerfDemo.DAL;

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

		public int GetResumesCount()
		{
			using (var context = new GitDbContext())
			{
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

		public void SeedGitUsers(int amount = 10000)
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
				context.BulkInsertAsync(data, amount).Wait();
				// EFBatchOperation.For(context, context.GitHubResumes).InsertAll(data);
				//context.AttachAndModify(data);
				//context.BulkInsert(data);
				//context.GitHubResumes.AddRange(data);
				// context.SaveChanges();
			}
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
						toSaveList.Add(cd);
					}
				}
				//context.ContactDatas.AddRange(toSaveList)
				context.BulkInsertAsync(toSaveList).Wait();
			}
		}

	}
}
