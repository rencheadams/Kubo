namespace QBO_Events_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Time", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Time");
        }
    }
}
