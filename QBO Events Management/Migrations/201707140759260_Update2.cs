namespace QBO_Events_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Participants", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Participants", "Email", c => c.String());
        }
    }
}
