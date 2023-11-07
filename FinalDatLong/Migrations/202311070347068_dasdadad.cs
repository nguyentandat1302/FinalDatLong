namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dasdadad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        IDAdmin = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        UserName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        FullName = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.IDAdmin);
            
            CreateTable(
                "dbo.Doctor",
                c => new
                    {
                        IDDoctor = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        UserName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        FullName = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Specialization = c.String(),
                        IDAdmin = c.String(maxLength: 20, fixedLength: true),
                    })
                .PrimaryKey(t => t.IDDoctor)
                .ForeignKey("dbo.Admin", t => t.IDAdmin)
                .Index(t => t.IDAdmin);
            
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        IDDoctor = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        IDPartient = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        Datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDDoctor, t.IDPartient, t.Datetime })
                .ForeignKey("dbo.Partient", t => t.IDPartient)
                .ForeignKey("dbo.Doctor", t => t.IDDoctor)
                .Index(t => t.IDDoctor)
                .Index(t => t.IDPartient);
            
            CreateTable(
                "dbo.Partient",
                c => new
                    {
                        IDPartient = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        UserName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 255, unicode: false),
                        FullName = c.String(maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.IDPartient);
            
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        IDPartient = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        IDDoctor = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        Datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDPartient, t.IDDoctor, t.Datetime })
                .ForeignKey("dbo.Partient", t => t.IDDoctor)
                .ForeignKey("dbo.Doctor", t => t.IDPartient)
                .Index(t => t.IDPartient)
                .Index(t => t.IDDoctor);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        IDPartient = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        Feedback = c.String(),
                    })
                .PrimaryKey(t => t.IDPartient)
                .ForeignKey("dbo.Partient", t => t.IDPartient)
                .Index(t => t.IDPartient);
            
            CreateTable(
                "dbo.Treatment",
                c => new
                    {
                        IDTreatment = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        IDDoctor = c.String(maxLength: 20, fixedLength: true),
                        IDPartient = c.String(maxLength: 20, fixedLength: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.IDTreatment)
                .ForeignKey("dbo.Doctor", t => t.IDDoctor)
                .ForeignKey("dbo.Partient", t => t.IDPartient)
                .Index(t => t.IDDoctor)
                .Index(t => t.IDPartient);
            
            CreateTable(
                "dbo.ListOfMedications",
                c => new
                    {
                        IDTreatment = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        medicine = c.String(maxLength: 255),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.IDTreatment)
                .ForeignKey("dbo.Treatment", t => t.IDTreatment)
                .Index(t => t.IDTreatment);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Booking", "IDPartient", "dbo.Doctor");
            DropForeignKey("dbo.Appointment", "IDDoctor", "dbo.Doctor");
            DropForeignKey("dbo.Treatment", "IDPartient", "dbo.Partient");
            DropForeignKey("dbo.ListOfMedications", "IDTreatment", "dbo.Treatment");
            DropForeignKey("dbo.Treatment", "IDDoctor", "dbo.Doctor");
            DropForeignKey("dbo.Feedback", "IDPartient", "dbo.Partient");
            DropForeignKey("dbo.Booking", "IDDoctor", "dbo.Partient");
            DropForeignKey("dbo.Appointment", "IDPartient", "dbo.Partient");
            DropForeignKey("dbo.Doctor", "IDAdmin", "dbo.Admin");
            DropIndex("dbo.ListOfMedications", new[] { "IDTreatment" });
            DropIndex("dbo.Treatment", new[] { "IDPartient" });
            DropIndex("dbo.Treatment", new[] { "IDDoctor" });
            DropIndex("dbo.Feedback", new[] { "IDPartient" });
            DropIndex("dbo.Booking", new[] { "IDDoctor" });
            DropIndex("dbo.Booking", new[] { "IDPartient" });
            DropIndex("dbo.Appointment", new[] { "IDPartient" });
            DropIndex("dbo.Appointment", new[] { "IDDoctor" });
            DropIndex("dbo.Doctor", new[] { "IDAdmin" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.ListOfMedications");
            DropTable("dbo.Treatment");
            DropTable("dbo.Feedback");
            DropTable("dbo.Booking");
            DropTable("dbo.Partient");
            DropTable("dbo.Appointment");
            DropTable("dbo.Doctor");
            DropTable("dbo.Admin");
        }
    }
}
