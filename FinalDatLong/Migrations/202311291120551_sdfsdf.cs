namespace FinalDatLong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfsdf : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Feedback");
            AlterColumn("dbo.Feedback", "IDFeedback", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Feedback", "IDFeedback");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Feedback");
            AlterColumn("dbo.Feedback", "IDFeedback", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Feedback", "IDFeedback");
        }
    }
}
