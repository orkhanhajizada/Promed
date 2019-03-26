namespace Promed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorAddMinabout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "MinAbout", c => c.String(nullable: false, storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "MinAbout");
        }
    }
}
