namespace Promed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OpeningHoursAddOrderBy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OpeningHours", "OrderBy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OpeningHours", "OrderBy");
        }
    }
}
