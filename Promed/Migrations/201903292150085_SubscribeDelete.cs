namespace Promed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubscribeDelete : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Subscribes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
