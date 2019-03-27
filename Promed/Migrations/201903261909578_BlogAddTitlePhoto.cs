namespace Promed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogAddTitlePhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "TitlePhoto", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "TitlePhoto");
        }
    }
}
