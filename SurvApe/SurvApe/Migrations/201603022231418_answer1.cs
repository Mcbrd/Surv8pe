namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class answer1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompletedSurveys", "answer_ID", "dbo.Answers");
            DropIndex("dbo.CompletedSurveys", new[] { "answer_ID" });
            DropColumn("dbo.CompletedSurveys", "answer_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompletedSurveys", "answer_ID", c => c.Int());
            CreateIndex("dbo.CompletedSurveys", "answer_ID");
            AddForeignKey("dbo.CompletedSurveys", "answer_ID", "dbo.Answers", "ID");
        }
    }
}
