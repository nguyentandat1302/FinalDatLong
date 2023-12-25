namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfgj : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Booking");
            AddColumn("dbo.Booking", "Accept", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Booking", "IDBooking", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Booking", "IDBooking");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Booking");
            AlterColumn("dbo.Booking", "IDBooking", c => c.Int(nullable: false));
            DropColumn("dbo.Booking", "Accept");
            AddPrimaryKey("dbo.Booking", "IDBooking");
        }
    }
}
