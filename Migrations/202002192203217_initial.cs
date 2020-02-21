namespace Passion_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "ArtistEmail", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "ArtistEmail");
        }
    }
}
