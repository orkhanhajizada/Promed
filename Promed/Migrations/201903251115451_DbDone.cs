namespace Promed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbDone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutElements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 500),
                        Text = c.String(nullable: false, storeType: "ntext"),
                        Icon = c.String(nullable: false, maxLength: 200),
                        IsTop = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 500),
                        Text = c.String(nullable: false, storeType: "ntext"),
                        Photo = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Adress = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 250),
                        Photo = c.String(nullable: false, maxLength: 250),
                        Title = c.String(nullable: false, maxLength: 350),
                        Text = c.String(nullable: false, storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Slug = c.String(maxLength: 1000),
                        Name = c.String(nullable: false, maxLength: 250),
                        Photo = c.String(nullable: false, maxLength: 250),
                        About = c.String(nullable: false, storeType: "ntext"),
                        Phone = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 250),
                        Adress = c.String(nullable: false, maxLength: 300),
                        Facebook = c.String(maxLength: 250),
                        Twitter = c.String(maxLength: 250),
                        Google = c.String(maxLength: 250),
                        Linkedin = c.String(maxLength: 250),
                        IsHead = c.Boolean(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        SpecialityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.Specialities", t => t.SpecialityId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.SpecialityId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Slug = c.String(maxLength: 1000),
                        Title = c.String(nullable: false, maxLength: 500),
                        Text = c.String(nullable: false, storeType: "ntext"),
                        Photo = c.String(nullable: false, maxLength: 250),
                        Date = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Facts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Icon = c.String(nullable: false, maxLength: 200),
                        Count = c.Int(nullable: false),
                        Text = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 100),
                        Photo = c.String(nullable: false, maxLength: 250),
                        Text = c.String(nullable: false, storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OpeningHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.String(nullable: false, maxLength: 250),
                        OpenHour = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logo = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Phone2 = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Email2 = c.String(nullable: false, maxLength: 50),
                        Adress = c.String(nullable: false, maxLength: 200),
                        Facebook = c.String(nullable: false, maxLength: 250),
                        Twitter = c.String(nullable: false, maxLength: 250),
                        Google = c.String(nullable: false, maxLength: 250),
                        Linkedin = c.String(nullable: false, maxLength: 250),
                        VideoLink = c.String(nullable: false, maxLength: 200),
                        VideoText = c.String(nullable: false, maxLength: 500),
                        Lat = c.String(nullable: false, maxLength: 50),
                        Lng = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, storeType: "ntext"),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subsliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(nullable: false, maxLength: 250),
                        Title = c.String(nullable: false, maxLength: 250),
                        Text = c.String(nullable: false, storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.Doctors", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Blogs", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Blogs", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Blogs", new[] { "DoctorId" });
            DropIndex("dbo.Blogs", new[] { "CategoryId" });
            DropIndex("dbo.Doctors", new[] { "SpecialityId" });
            DropIndex("dbo.Doctors", new[] { "DepartmentId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "DepartmentId" });
            DropTable("dbo.Subsliders");
            DropTable("dbo.Subscribes");
            DropTable("dbo.Specialities");
            DropTable("dbo.Sliders");
            DropTable("dbo.Settings");
            DropTable("dbo.OpeningHours");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Facts");
            DropTable("dbo.Categories");
            DropTable("dbo.Blogs");
            DropTable("dbo.Doctors");
            DropTable("dbo.Departments");
            DropTable("dbo.Appointments");
            DropTable("dbo.Abouts");
            DropTable("dbo.AboutElements");
        }
    }
}
