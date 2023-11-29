namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fgdsfsdas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicine",
                c => new
                    {
                        IDMedicine = c.Int(nullable: false, identity: true),
                        NameMidecine = c.String(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.IDMedicine);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medicine");
        }
    }
}
