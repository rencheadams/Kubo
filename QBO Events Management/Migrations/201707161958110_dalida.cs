namespace QBO_Events_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dalida : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Participants", "Event_ID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Participants", "Event_ID");
            AddForeignKey("dbo.Participants", "Event_ID", "dbo.Events", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participants", "Event_ID", "dbo.Events");
            DropIndex("dbo.Participants", new[] { "Event_ID" });
            DropColumn("dbo.Participants", "Event_ID");
            DropTable("dbo.Events");
        }
    }
}
