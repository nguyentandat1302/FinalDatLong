namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ListOfMedications", "IDTreatment", "dbo.Treatment");
            DropPrimaryKey("dbo.Treatment");
            AlterColumn("dbo.Treatment", "IDTreatment", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Treatment", "IDTreatment");
            AddForeignKey("dbo.ListOfMedications", "IDTreatment", "dbo.Treatment", "IDTreatment");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListOfMedications", "IDTreatment", "dbo.Treatment");
            DropPrimaryKey("dbo.Treatment");
            AlterColumn("dbo.Treatment", "IDTreatment", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Treatment", "IDTreatment");
            AddForeignKey("dbo.ListOfMedications", "IDTreatment", "dbo.Treatment", "IDTreatment");
        }
    }
}
