namespace DBPerformancePlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonalKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactDatas", "PersonalKey", c => c.String(defaultValue: "qs@231"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactDatas", "PersonalKey");
        }
    }
}
