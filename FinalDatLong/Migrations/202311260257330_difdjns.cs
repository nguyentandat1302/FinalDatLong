namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class difdjns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctor", "Avatar", c => c.String());
            AlterColumn("dbo.Patient", "Avatar", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patient", "Avatar", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Doctor", "Avatar", c => c.String(maxLength: 1000));
        }
    }
}
