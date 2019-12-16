namespace Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditMedium : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Media", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Media", "File", c => c.String());
        }
    }
}
