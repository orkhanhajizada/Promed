namespace Promed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aboutelementchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AboutElements", "Text", c => c.String(storeType: "ntext"));
            AlterColumn("dbo.AboutElements", "Icon", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AboutElements", "Icon", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.AboutElements", "Text", c => c.String(nullable: false, storeType: "ntext"));
        }
    }
}
