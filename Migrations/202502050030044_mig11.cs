namespace AcunMedyaRestaurantly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookATables",
                c => new
                    {
                        BookATableId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(maxLength: 11),
                        IsRead = c.Boolean(nullable: false),
                        People = c.Int(nullable: false),
                        SendDate = c.DateTime(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.BookATableId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookATables");
        }
    }
}
