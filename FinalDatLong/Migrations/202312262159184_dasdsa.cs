namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dasdsa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Booking", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Booking", "Description");
        }
    }
}
