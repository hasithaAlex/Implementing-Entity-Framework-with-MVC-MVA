namespace _03_MVA_Ex_RepoPatern.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albams",
                c => new
                    {
                        AlbamID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        ArtistID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbamID)
                .ForeignKey("dbo.Artists", t => t.ArtistID, cascadeDelete: true)
                .Index(t => t.ArtistID);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ArtistID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albams", "ArtistID", "dbo.Artists");
            DropIndex("dbo.Albams", new[] { "ArtistID" });
            DropTable("dbo.Artists");
            DropTable("dbo.Albams");
        }
    }
}
