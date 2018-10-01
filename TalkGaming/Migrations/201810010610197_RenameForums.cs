namespace TalkGaming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameForums : DbMigration
    {
        public override void Up()
        {
            RenameTable("Forums", "Forum");
        }
        
        public override void Down()
        {
            RenameTable("Forum", "Forums");
        }
    }
}
