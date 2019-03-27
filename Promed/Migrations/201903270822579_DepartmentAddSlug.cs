namespace Promed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentAddSlug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Slug", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "Slug");
        }
    }
}
