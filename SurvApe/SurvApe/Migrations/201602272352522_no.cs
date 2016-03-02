namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class no : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "question_ID", "dbo.Questions");
            DropForeignKey("dbo.Questions", "survey_ID", "dbo.Surveys");
            DropIndex("dbo.Questions", new[] { "question_ID" });
            DropIndex("dbo.Questions", new[] { "survey_ID" });
            DropColumn("dbo.Questions", "questionType");
            DropColumn("dbo.Questions", "Discriminator");
            DropColumn("dbo.Questions", "question_ID");
            DropColumn("dbo.Questions", "survey_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "survey_ID", c => c.Int());
            AddColumn("dbo.Questions", "question_ID", c => c.Int());
            AddColumn("dbo.Questions", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Questions", "questionType", c => c.Int());
            CreateIndex("dbo.Questions", "survey_ID");
            CreateIndex("dbo.Questions", "question_ID");
            AddForeignKey("dbo.Questions", "survey_ID", "dbo.Surveys", "ID");
            AddForeignKey("dbo.Questions", "question_ID", "dbo.Questions", "ID");
        }
    }
}
