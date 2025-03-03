namespace AcunMedyaRestaurantly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class event2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Message", c => c.String());
            AddColumn("dbo.Events", "Message2", c => c.String());
            AddColumn("dbo.Events", "Message3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Message3");
            DropColumn("dbo.Events", "Message2");
            DropColumn("dbo.Events", "Message");
        }
    }
}
