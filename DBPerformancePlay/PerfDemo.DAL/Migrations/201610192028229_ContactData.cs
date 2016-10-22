namespace DBPerformancePlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactType = c.Int(nullable: false),
                        Data = c.String(),
                        GitHubResumeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GitHubResume", t => t.GitHubResumeId, cascadeDelete: true)
                .Index(t => t.GitHubResumeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactDatas", "GitHubResumeId", "dbo.GitHubResume");
            DropIndex("dbo.ContactDatas", new[] { "GitHubResumeId" });
            DropTable("dbo.ContactDatas");
        }
    }
}
