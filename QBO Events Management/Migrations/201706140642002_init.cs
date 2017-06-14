namespace QBO_Events_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "IsPublished", c => c.Boolean(nullable: false));
            AddColumn("dbo.Events", "Status", c => c.String());
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Events", "Venue", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Venue", c => c.String());
            AlterColumn("dbo.Events", "Name", c => c.String());
            DropColumn("dbo.Events", "Status");
            DropColumn("dbo.Events", "IsPublished");
        }
    }
}
