namespace QBO_Events_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        eventID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Time = c.Time(nullable: false, precision: 7),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.eventID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
