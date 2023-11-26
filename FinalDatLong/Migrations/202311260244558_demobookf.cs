namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class demobookf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctor", "Avatar", c => c.String(maxLength: 1000));
            AddColumn("dbo.Doctor", "Introduction", c => c.String(maxLength: 255));
            AddColumn("dbo.Patient", "PhoneNumber", c => c.String(maxLength: 100));
            AddColumn("dbo.Patient", "Avatar", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patient", "Avatar");
            DropColumn("dbo.Patient", "PhoneNumber");
            DropColumn("dbo.Doctor", "Introduction");
            DropColumn("dbo.Doctor", "Avatar");
        }
    }
}
