namespace QuizLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationAfterAnswerMode : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Answers", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "ImageUrl", c => c.String());
        }
    }
}
