namespace TalkGaming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCommentsAndPostsInDb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Title", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
