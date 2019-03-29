namespace Promed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogTextRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "Text", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "Text", c => c.String(nullable: false, storeType: "ntext"));
        }
    }
}
