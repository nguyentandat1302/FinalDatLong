namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fsfsfs : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Admin");
            AlterColumn("dbo.Admin", "IDAdmin", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Admin", "IDAdmin");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Admin");
            AlterColumn("dbo.Admin", "IDAdmin", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Admin", "IDAdmin");
        }
    }
}
