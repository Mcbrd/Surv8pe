namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redo2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "questionType", c => c.Int());
            AddColumn("dbo.Questions", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Questions", "question_ID", c => c.Int());
            AddColumn("dbo.Questions", "survey_ID", c => c.Int());
            CreateIndex("dbo.Questions", "question_ID");
            CreateIndex("dbo.Questions", "survey_ID");
            AddForeignKey("dbo.Questions", "question_ID", "dbo.Questions", "ID");
            AddForeignKey("dbo.Questions", "survey_ID", "dbo.Surveys", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "survey_ID", "dbo.Surveys");
            DropForeignKey("dbo.Questions", "question_ID", "dbo.Questions");
            DropIndex("dbo.Questions", new[] { "survey_ID" });
            DropIndex("dbo.Questions", new[] { "question_ID" });
            DropColumn("dbo.Questions", "survey_ID");
            DropColumn("dbo.Questions", "question_ID");
            DropColumn("dbo.Questions", "Discriminator");
            DropColumn("dbo.Questions", "questionType");
        }
    }
}
