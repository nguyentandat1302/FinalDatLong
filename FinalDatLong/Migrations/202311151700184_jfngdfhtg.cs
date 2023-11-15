namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jfngdfhtg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        IDAdmin = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 255, unicode: false),
                        Password = c.String(nullable: false, maxLength: 255, unicode: false),
                        FullName = c.String(nullable: false, maxLength: 255, unicode: false),
                        Email = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.IDAdmin);
            
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        IDAppointment = c.Int(nullable: false),
                        IDDoctor = c.Int(),
                        IDPatient = c.Int(),
                        Datetime = c.DateTime(),
                    })
                .PrimaryKey(t => t.IDAppointment)
                .ForeignKey("dbo.Doctor", t => t.IDDoctor)
                .ForeignKey("dbo.Patient", t => t.IDPatient)
                .Index(t => t.IDDoctor)
                .Index(t => t.IDPatient);
            
            CreateTable(
                "dbo.Doctor",
                c => new
                    {
                        IDDoctor = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 255, unicode: false),
                        Password = c.String(nullable: false, maxLength: 255, unicode: false),
                        FullName = c.String(nullable: false, maxLength: 255, unicode: false),
                        Email = c.String(nullable: false, maxLength: 255, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 255),
                        Specialization = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.IDDoctor);
            
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        IDBooking = c.Int(nullable: false),
                        IDPatient = c.Int(),
                        IDDoctor = c.Int(),
                        Datetime = c.DateTime(),
                    })
                .PrimaryKey(t => t.IDBooking)
                .ForeignKey("dbo.Doctor", t => t.IDDoctor)
                .ForeignKey("dbo.Patient", t => t.IDPatient)
                .Index(t => t.IDPatient)
                .Index(t => t.IDDoctor);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        IDPatient = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 255, unicode: false),
                        FullName = c.String(maxLength: 255, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.IDPatient);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        IDFeedback = c.Int(nullable: false),
                        IDPatient = c.Int(),
                        Feedback = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.IDFeedback)
                .ForeignKey("dbo.Patient", t => t.IDPatient)
                .Index(t => t.IDPatient);
            
            CreateTable(
                "dbo.Treatment",
                c => new
                    {
                        IDTreatment = c.Int(nullable: false),
                        IDDoctor = c.Int(),
                        IDPatient = c.Int(),
                        Description = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.IDTreatment)
                .ForeignKey("dbo.Doctor", t => t.IDDoctor)
                .ForeignKey("dbo.Patient", t => t.IDPatient)
                .Index(t => t.IDDoctor)
                .Index(t => t.IDPatient);
            
            CreateTable(
                "dbo.ListOfMedications",
                c => new
                    {
                        IDListOfMedications = c.Int(nullable: false),
                        IDTreatment = c.Int(),
                        Medicine = c.String(maxLength: 255, unicode: false),
                        Description = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.IDListOfMedications)
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
            DropForeignKey("dbo.Treatment", "IDPatient", "dbo.Patient");
            DropForeignKey("dbo.ListOfMedications", "IDTreatment", "dbo.Treatment");
            DropForeignKey("dbo.Treatment", "IDDoctor", "dbo.Doctor");
            DropForeignKey("dbo.Feedback", "IDPatient", "dbo.Patient");
            DropForeignKey("dbo.Booking", "IDPatient", "dbo.Patient");
            DropForeignKey("dbo.Appointment", "IDPatient", "dbo.Patient");
            DropForeignKey("dbo.Booking", "IDDoctor", "dbo.Doctor");
            DropForeignKey("dbo.Appointment", "IDDoctor", "dbo.Doctor");
            DropIndex("dbo.ListOfMedications", new[] { "IDTreatment" });
            DropIndex("dbo.Treatment", new[] { "IDPatient" });
            DropIndex("dbo.Treatment", new[] { "IDDoctor" });
            DropIndex("dbo.Feedback", new[] { "IDPatient" });
            DropIndex("dbo.Booking", new[] { "IDDoctor" });
            DropIndex("dbo.Booking", new[] { "IDPatient" });
            DropIndex("dbo.Appointment", new[] { "IDPatient" });
            DropIndex("dbo.Appointment", new[] { "IDDoctor" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.ListOfMedications");
            DropTable("dbo.Treatment");
            DropTable("dbo.Feedback");
            DropTable("dbo.Patient");
            DropTable("dbo.Booking");
            DropTable("dbo.Doctor");
            DropTable("dbo.Appointment");
            DropTable("dbo.Admin");
        }
    }
}
