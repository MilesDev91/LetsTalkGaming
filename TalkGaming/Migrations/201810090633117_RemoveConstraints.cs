namespace TalkGaming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveConstraints : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Post drop constraint [FK_dbo.Post_dbo.Forums_Forum_Id]");
            RenameTable(name: "dbo.Comment", newName: "Comments");
            RenameTable(name: "dbo.Post", newName: "Posts");
            DropForeignKey("dbo.Comment", "Post_Id", "dbo.Post");
            DropForeignKey("dbo.Post", "Forum_Id", "dbo.Forum");
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropIndex("dbo.Posts", new[] { "Forum_Id" });
            DropColumn("dbo.Comments", "Post_Id");
            DropColumn("dbo.Posts", "Forum_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Forum_Id", c => c.Int());
            AddColumn("dbo.Comments", "Post_Id", c => c.Int());
            CreateIndex("dbo.Posts", "Forum_Id");
            CreateIndex("dbo.Comments", "Post_Id");
            AddForeignKey("dbo.Post", "Forum_Id", "dbo.Forum", "Id");
            AddForeignKey("dbo.Comment", "Post_Id", "dbo.Post", "Id");
            RenameTable(name: "dbo.Posts", newName: "Post");
            RenameTable(name: "dbo.Comments", newName: "Comment");
            Sql("ALTER TABLE Post add constraint [FK_dbo.Post_dbo.Forums_Forum_Id]");
        }
    }
}
