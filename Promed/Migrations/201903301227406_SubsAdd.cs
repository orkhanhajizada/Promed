namespace Promed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubsAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscribes");
        }
    }
}
