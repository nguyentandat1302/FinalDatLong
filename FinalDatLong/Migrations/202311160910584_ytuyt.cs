namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ytuyt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admin", "Role", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admin", "Role");
        }
    }
}
