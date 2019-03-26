namespace Promed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedbackAddDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feedbacks", "Date");
        }
    }
}
