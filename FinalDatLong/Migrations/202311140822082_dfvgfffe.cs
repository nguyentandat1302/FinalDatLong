namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfvgfffe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patient", "FullName", c => c.String(maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patient", "FullName", c => c.String(nullable: false, maxLength: 255, unicode: false));
        }
    }
}
