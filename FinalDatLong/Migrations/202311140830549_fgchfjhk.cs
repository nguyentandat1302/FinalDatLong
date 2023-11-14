namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fgchfjhk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointment", "IDPatient", "dbo.Patient");
            DropForeignKey("dbo.Booking", "IDPatient", "dbo.Patient");
            DropForeignKey("dbo.Feedback", "IDPatient", "dbo.Patient");
            DropForeignKey("dbo.Treatment", "IDPatient", "dbo.Patient");
            DropPrimaryKey("dbo.Patient");
            AlterColumn("dbo.Patient", "IDPatient", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Patient", "IDPatient");
            AddForeignKey("dbo.Appointment", "IDPatient", "dbo.Patient", "IDPatient");
            AddForeignKey("dbo.Booking", "IDPatient", "dbo.Patient", "IDPatient");
            AddForeignKey("dbo.Feedback", "IDPatient", "dbo.Patient", "IDPatient");
            AddForeignKey("dbo.Treatment", "IDPatient", "dbo.Patient", "IDPatient");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Treatment", "IDPatient", "dbo.Patient");
            DropForeignKey("dbo.Feedback", "IDPatient", "dbo.Patient");
            DropForeignKey("dbo.Booking", "IDPatient", "dbo.Patient");
            DropForeignKey("dbo.Appointment", "IDPatient", "dbo.Patient");
            DropPrimaryKey("dbo.Patient");
            AlterColumn("dbo.Patient", "IDPatient", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Patient", "IDPatient");
            AddForeignKey("dbo.Treatment", "IDPatient", "dbo.Patient", "IDPatient");
            AddForeignKey("dbo.Feedback", "IDPatient", "dbo.Patient", "IDPatient");
            AddForeignKey("dbo.Booking", "IDPatient", "dbo.Patient", "IDPatient");
            AddForeignKey("dbo.Appointment", "IDPatient", "dbo.Patient", "IDPatient");
        }
    }
}
