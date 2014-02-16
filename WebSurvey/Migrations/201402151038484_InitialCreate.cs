namespace WebSurvey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Document = c.String(),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.IdClient);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        IdLocation = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.IdLocation);
            
            CreateTable(
                "dbo.TravelHistory",
                c => new
                    {
                        IdTravelHistory = c.Int(nullable: false, identity: true),
                        IdLocation = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Satisfaction = c.Int(),
                        IdClient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTravelHistory);
            
            CreateTable(
                "dbo.SysAdmin",
                c => new
                    {
                        IdAdmin = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Document = c.String(),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.IdAdmin);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SysAdmin");
            DropTable("dbo.TravelHistory");
            DropTable("dbo.Location");
            DropTable("dbo.Client");
        }
    }
}
