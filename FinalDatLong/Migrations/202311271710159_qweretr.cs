namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qweretr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Treatment", "TreatmentDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Treatment", "TreatmentDescription");
        }
    }
}
