namespace Passion_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(),
                        ArtistAge = c.Int(nullable: false),
                        ArtistDOB = c.String(),
                        ArtistContact = c.String(),
                    })
                .PrimaryKey(t => t.ArtistID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Artists");
        }
    }
}
