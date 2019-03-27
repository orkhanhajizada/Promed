namespace Promed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogAddMinAbout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "MinAbout", c => c.String(nullable: false, storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "MinAbout");
        }
    }
}
