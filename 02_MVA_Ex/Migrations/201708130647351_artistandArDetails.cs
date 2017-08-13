namespace _02_MVA_Ex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class artistandArDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ArtistID);
            
            CreateTable(
                "dbo.ArtistDetails",
                c => new
                    {
                        ArtistID = c.Int(nullable: false),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.ArtistID)
                .ForeignKey("dbo.Artists", t => t.ArtistID)
                .Index(t => t.ArtistID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtistDetails", "ArtistID", "dbo.Artists");
            DropIndex("dbo.ArtistDetails", new[] { "ArtistID" });
            DropTable("dbo.ArtistDetails");
            DropTable("dbo.Artists");
        }
    }
}
