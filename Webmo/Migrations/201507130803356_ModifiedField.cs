namespace Webmo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Article", "Posted", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Article", "Posted", c => c.DateTime(nullable: false));
        }
    }
}
