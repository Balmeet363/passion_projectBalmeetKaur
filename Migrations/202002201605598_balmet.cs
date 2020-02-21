namespace Passion_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class balmet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.artistpoetries",
                c => new
                {
                    artist_artistID = c.Int(nullable: false),
                    poetry_poetryID = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.artist_artistID, t.poetry_poetryID })
                .ForeignKey("dbo.artists", t => t.artist_artistID, cascadeDelete: true)
                .ForeignKey("dbo.poetries", t => t.poetry_poetryID, cascadeDelete: true)
                .Index(t => t.artist_artistID)
                .Index(t => t.poetry_poetryID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.artistpoetries", "artist_artistID", "dbo.artists");
            DropForeignKey("dbo.artistpoetries", "poetry_poetryID", "dbo.poetries");
            DropIndex("dbo.artistpoetries", new[] { "artist_artistID" });
            DropIndex("dbo.artistpoetries", new[] { "poetry_poetryID" });
            DropTable("dbo.artistpoetries");
        }
    }
}
