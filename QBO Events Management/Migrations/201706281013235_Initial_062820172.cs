namespace QBO_Events_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_062820172 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Participants", "PersonID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Participants", "PersonID", c => c.Guid(nullable: false));
        }
    }
}
