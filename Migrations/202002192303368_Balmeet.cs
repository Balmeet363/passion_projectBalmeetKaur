namespace Passion_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Balmeet : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artists", "ArtistEmail", c => c.String());
            DropColumn("dbo.Artists", "ArtistAge");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "ArtistAge", c => c.Int(nullable: false));
            AlterColumn("dbo.Artists", "ArtistEmail", c => c.Int(nullable: false));
        }
    }
}
