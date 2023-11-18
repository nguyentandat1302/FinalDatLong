namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fnmbn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admin", "Avatar", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admin", "Avatar");
        }
    }
}
