namespace QBO_Events_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Renche2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Participants");
            AlterColumn("dbo.Participants", "ParticipantID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Participants", "EventsID", c => c.String());
            AddPrimaryKey("dbo.Participants", "ParticipantID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Participants");
            AlterColumn("dbo.Participants", "EventsID", c => c.Int(nullable: false));
            AlterColumn("dbo.Participants", "ParticipantID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Participants", "ParticipantID");
        }
    }
}
