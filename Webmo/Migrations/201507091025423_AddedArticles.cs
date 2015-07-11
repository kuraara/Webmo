namespace Webmo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedArticles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Posted = c.DateTime(nullable: false),
                        Updatd = c.DateTime(),
                        Title = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Posted = c.DateTime(nullable: false),
                        Author = c.String(),
                        Content = c.String(),
                        Article_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Article", t => t.Article_ID)
                .Index(t => t.Article_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "Article_ID", "dbo.Article");
            DropIndex("dbo.Comment", new[] { "Article_ID" });
            DropTable("dbo.Comment");
            DropTable("dbo.Article");
        }
    }
}
