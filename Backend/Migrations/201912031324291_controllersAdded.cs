namespace Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class controllersAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        Destination = c.String(),
                        Origin = c.String(),
                        ETA = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FlightId);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        MediumId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Title = c.String(),
                        File = c.String(),
                    })
                .PrimaryKey(t => t.MediumId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.NotificationId);
            
            AddColumn("dbo.Orders", "Flight_FlightId", c => c.Int());
            AddColumn("dbo.Passengers", "Flight_FlightId", c => c.Int());
            AddColumn("dbo.Passengers", "Notification_NotificationId", c => c.Int());
            AddColumn("dbo.TravelGroups", "Flight_FlightId", c => c.Int());
            AddColumn("dbo.Stewards", "Flight_FlightId", c => c.Int());
            CreateIndex("dbo.Orders", "Flight_FlightId");
            CreateIndex("dbo.Passengers", "Flight_FlightId");
            CreateIndex("dbo.Passengers", "Notification_NotificationId");
            CreateIndex("dbo.TravelGroups", "Flight_FlightId");
            CreateIndex("dbo.Stewards", "Flight_FlightId");
            AddForeignKey("dbo.Orders", "Flight_FlightId", "dbo.Flights", "FlightId");
            AddForeignKey("dbo.Passengers", "Flight_FlightId", "dbo.Flights", "FlightId");
            AddForeignKey("dbo.Stewards", "Flight_FlightId", "dbo.Flights", "FlightId");
            AddForeignKey("dbo.TravelGroups", "Flight_FlightId", "dbo.Flights", "FlightId");
            AddForeignKey("dbo.Passengers", "Notification_NotificationId", "dbo.Notifications", "NotificationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passengers", "Notification_NotificationId", "dbo.Notifications");
            DropForeignKey("dbo.TravelGroups", "Flight_FlightId", "dbo.Flights");
            DropForeignKey("dbo.Stewards", "Flight_FlightId", "dbo.Flights");
            DropForeignKey("dbo.Passengers", "Flight_FlightId", "dbo.Flights");
            DropForeignKey("dbo.Orders", "Flight_FlightId", "dbo.Flights");
            DropIndex("dbo.Stewards", new[] { "Flight_FlightId" });
            DropIndex("dbo.TravelGroups", new[] { "Flight_FlightId" });
            DropIndex("dbo.Passengers", new[] { "Notification_NotificationId" });
            DropIndex("dbo.Passengers", new[] { "Flight_FlightId" });
            DropIndex("dbo.Orders", new[] { "Flight_FlightId" });
            DropColumn("dbo.Stewards", "Flight_FlightId");
            DropColumn("dbo.TravelGroups", "Flight_FlightId");
            DropColumn("dbo.Passengers", "Notification_NotificationId");
            DropColumn("dbo.Passengers", "Flight_FlightId");
            DropColumn("dbo.Orders", "Flight_FlightId");
            DropTable("dbo.Notifications");
            DropTable("dbo.Media");
            DropTable("dbo.Flights");
        }
    }
}
