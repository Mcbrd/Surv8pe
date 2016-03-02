namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class completedanswers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompletedSurveys", "QuestionAnswered_ID", c => c.Int());
            CreateIndex("dbo.CompletedSurveys", "QuestionAnswered_ID");
            AddForeignKey("dbo.CompletedSurveys", "QuestionAnswered_ID", "dbo.Questions", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompletedSurveys", "QuestionAnswered_ID", "dbo.Questions");
            DropIndex("dbo.CompletedSurveys", new[] { "QuestionAnswered_ID" });
            DropColumn("dbo.CompletedSurveys", "QuestionAnswered_ID");
        }
    }
}
