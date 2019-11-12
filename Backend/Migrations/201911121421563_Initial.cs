namespace Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        TicketNumber = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Name = c.String(),
                        Seat_SeatId = c.Int(),
                    })
                .PrimaryKey(t => t.TicketNumber)
                .ForeignKey("dbo.Seats", t => t.Seat_SeatId)
                .Index(t => t.Seat_SeatId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Passenger_TicketNumber = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Passengers", t => t.Passenger_TicketNumber)
                .Index(t => t.Passenger_TicketNumber);
            
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        OrderLineId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Article_ArticleId = c.Int(),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderLineId)
                .ForeignKey("dbo.Articles", t => t.Article_ArticleId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .Index(t => t.Article_ArticleId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatId = c.Int(nullable: false, identity: true),
                        SeatNumber = c.String(),
                    })
                .PrimaryKey(t => t.SeatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passengers", "Seat_SeatId", "dbo.Seats");
            DropForeignKey("dbo.Orders", "Passenger_TicketNumber", "dbo.Passengers");
            DropForeignKey("dbo.OrderLines", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderLines", "Article_ArticleId", "dbo.Articles");
            DropIndex("dbo.OrderLines", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderLines", new[] { "Article_ArticleId" });
            DropIndex("dbo.Orders", new[] { "Passenger_TicketNumber" });
            DropIndex("dbo.Passengers", new[] { "Seat_SeatId" });
            DropTable("dbo.Seats");
            DropTable("dbo.Articles");
            DropTable("dbo.OrderLines");
            DropTable("dbo.Orders");
            DropTable("dbo.Passengers");
        }
    }
}
