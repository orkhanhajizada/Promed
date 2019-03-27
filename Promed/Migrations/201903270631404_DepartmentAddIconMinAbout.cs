namespace Promed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentAddIconMinAbout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Icon", c => c.String(maxLength: 200));
            AddColumn("dbo.Departments", "MinAbout", c => c.String(nullable: false, storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "MinAbout");
            DropColumn("dbo.Departments", "Icon");
        }
    }
}
