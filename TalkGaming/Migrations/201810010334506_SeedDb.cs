namespace TalkGaming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDb : DbMigration
    {
        public override void Up()
        {
            // FORUMS
            Sql("INSERT INTO Forums (Title) VALUES ('Tetris')");
            Sql("INSERT INTO Forums (Title) VALUES ('Super Mario World')");
            Sql("INSERT INTO Forums (Title) VALUES ('Legend of Zelda')");
            Sql("INSERT INTO Forums (Title) VALUES ('Final Fantasy')");
            Sql("INSERT INTO Forums (Title) VALUES ('World of Warcraft')");
            Sql("INSERT INTO Forums (Title) VALUES ('Call of Duty')");
        }
        
        public override void Down()
        {
        }
    }
}
