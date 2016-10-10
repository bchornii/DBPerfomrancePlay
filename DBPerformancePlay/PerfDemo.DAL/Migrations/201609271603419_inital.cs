namespace DBPerformancePlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GitHubResume",
                c => new
                    {
                        UserResumeId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        Login = c.String(),
                        Name = c.String(),
                        Location = c.String(),
                        Email = c.String(),
                        Company = c.String(),
                        Bio = c.String(),
                        Blog = c.String(),
                        PiplMatchedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserResumeId);
            
            CreateTable(
                "dbo.GitHubUser",
                c => new
                    {
                        DBId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        Login = c.String(),
                        AvatarUrl = c.String(),
                        GravatarId = c.String(),
                        Url = c.String(),
                        HtmlUrl = c.String(),
                        FollowersUrl = c.String(),
                        FollowingUrl = c.String(),
                        GistsUrl = c.String(),
                        StarredUrl = c.String(),
                        SubscriptionsUrl = c.String(),
                        OrganizationsUrl = c.String(),
                        ReposUrl = c.String(),
                        EventsUrl = c.String(),
                        ReceivedEventsUrl = c.String(),
                        Type = c.String(),
                        SiteAdmin = c.Boolean(nullable: false),
                        GrabDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.DBId);
            
            CreateTable(
                "dbo.LData",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Rstring = c.String(),
                        Rnumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonSkill",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SkillName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonSkill");
            DropTable("dbo.LData");
            DropTable("dbo.GitHubUser");
            DropTable("dbo.GitHubResume");
        }
    }
}
