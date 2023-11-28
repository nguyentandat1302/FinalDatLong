namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfdsdfsd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedback", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feedback", "Rating");
        }
    }
}
