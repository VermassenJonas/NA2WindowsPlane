namespace Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TravelGroups",
                c => new
                    {
                        TravelGroupId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TravelGroupId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Sent = c.DateTime(nullable: false),
                        Sender_TicketNumber = c.Int(),
                        TravelGroup_TravelGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Passengers", t => t.Sender_TicketNumber)
                .ForeignKey("dbo.TravelGroups", t => t.TravelGroup_TravelGroupId)
                .Index(t => t.Sender_TicketNumber)
                .Index(t => t.TravelGroup_TravelGroupId);
            
            CreateTable(
                "dbo.Stewards",
                c => new
                    {
                        PersonnelNumber = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Name = c.String(),
                        Password = c.String(),
                        Hash = c.String(),
                    })
                .PrimaryKey(t => t.PersonnelNumber);
            
            AddColumn("dbo.Passengers", "TravelGroup_TravelGroupId", c => c.Int());
            CreateIndex("dbo.Passengers", "TravelGroup_TravelGroupId");
            AddForeignKey("dbo.Passengers", "TravelGroup_TravelGroupId", "dbo.TravelGroups", "TravelGroupId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passengers", "TravelGroup_TravelGroupId", "dbo.TravelGroups");
            DropForeignKey("dbo.Messages", "TravelGroup_TravelGroupId", "dbo.TravelGroups");
            DropForeignKey("dbo.Messages", "Sender_TicketNumber", "dbo.Passengers");
            DropIndex("dbo.Messages", new[] { "TravelGroup_TravelGroupId" });
            DropIndex("dbo.Messages", new[] { "Sender_TicketNumber" });
            DropIndex("dbo.Passengers", new[] { "TravelGroup_TravelGroupId" });
            DropColumn("dbo.Passengers", "TravelGroup_TravelGroupId");
            DropTable("dbo.Stewards");
            DropTable("dbo.Messages");
            DropTable("dbo.TravelGroups");
        }
    }
}
