namespace _02_MVA_Ex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblModification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albam_OneTowMany",
                c => new
                    {
                        Albam_OneTowManyID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        ArtistID = c.Int(nullable: false),
                        Artist_Artist_OneTowManyID = c.Int(),
                    })
                .PrimaryKey(t => t.Albam_OneTowManyID)
                .ForeignKey("dbo.Artist_OneTowMany", t => t.Artist_Artist_OneTowManyID)
                .Index(t => t.Artist_Artist_OneTowManyID);
            
            CreateTable(
                "dbo.Artist_OneTowMany",
                c => new
                    {
                        Artist_OneTowManyID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Artist_OneTowManyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albam_OneTowMany", "Artist_Artist_OneTowManyID", "dbo.Artist_OneTowMany");
            DropIndex("dbo.Albam_OneTowMany", new[] { "Artist_Artist_OneTowManyID" });
            DropTable("dbo.Artist_OneTowMany");
            DropTable("dbo.Albam_OneTowMany");
        }
    }
}
