namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sfsfsfsf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctor", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctor", "Role");
        }
    }
}
