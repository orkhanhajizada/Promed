namespace Promed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "DepartmentId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropTable("dbo.Appointments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 250),
                        Message = c.String(nullable: false, storeType: "ntext"),
                        Date = c.DateTime(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Appointments", "DoctorId");
            CreateIndex("dbo.Appointments", "DepartmentId");
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
