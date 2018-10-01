namespace TalkGaming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBackForeignKeysToModelsAndDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Post_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Forum_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "Post_Id");
            CreateIndex("dbo.Posts", "Forum_Id");
            AddForeignKey("dbo.Comments", "Post_Id", "dbo.Posts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "Forum_Id", "dbo.Forum", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Forum_Id", "dbo.Forum");
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "Forum_Id" });
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropColumn("dbo.Posts", "Forum_Id");
            DropColumn("dbo.Comments", "Post_Id");
        }
    }
}
