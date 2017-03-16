namespace QuizLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        QuizId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Topic = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuizId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        Category = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Quizs", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                        Content = c.String(),
                        ImageUrl = c.String(),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuizId", "dbo.Quizs");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "QuizId" });
            DropTable("dbo.Answers");
            DropTable("dbo.Questions");
            DropTable("dbo.Quizs");
        }
    }
}
