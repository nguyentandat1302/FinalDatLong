namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ListOfMedications", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ListOfMedications", "Rating");
        }
    }
}
