namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fsfsfs1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admin", "Avatar", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admin", "Avatar", c => c.String(maxLength: 255));
        }
    }
}
