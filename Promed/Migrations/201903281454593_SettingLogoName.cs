namespace Promed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingLogoName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "Photo", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.Settings", "Logo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Settings", "Logo", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.Settings", "Photo");
        }
    }
}
