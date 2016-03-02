namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class props : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Surveys", "SelectedAnswer", c => c.Int(nullable: false));
            AddColumn("dbo.Surveys", "question_ID", c => c.Int());
            CreateIndex("dbo.Surveys", "question_ID");
            AddForeignKey("dbo.Surveys", "question_ID", "dbo.Questions", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Surveys", "question_ID", "dbo.Questions");
            DropIndex("dbo.Surveys", new[] { "question_ID" });
            DropColumn("dbo.Surveys", "question_ID");
            DropColumn("dbo.Surveys", "SelectedAnswer");
        }
    }
}
