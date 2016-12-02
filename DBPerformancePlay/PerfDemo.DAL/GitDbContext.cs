namespace PerfDemo.DAL
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using Models;
	public partial class GitDbContext : DbContext
	{
		public GitDbContext(bool enableLazy = false)
			: base("name=GitInfoDB")
		{
			this.Configuration.LazyLoadingEnabled = enableLazy;
		}

		public virtual DbSet<GitHubResume> GitHubResumes { get; set; }
		public virtual DbSet<GitHubUser> GitHubUsers { get; set; }
		public virtual DbSet<PersonSkill> PersonSkills { get; set; }
		public virtual DbSet<LData> LDatas { get; set; }
		public virtual DbSet<ContactData> ContactDatas { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
