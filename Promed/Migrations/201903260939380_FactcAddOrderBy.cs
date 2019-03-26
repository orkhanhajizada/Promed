namespace Promed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FactcAddOrderBy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facts", "OrderBy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Facts", "OrderBy");
        }
    }
}
