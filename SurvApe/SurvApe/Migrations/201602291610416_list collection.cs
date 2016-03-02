namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listcollection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrueOrFalseQuestions", "Survey_ID", "dbo.Surveys");
            DropIndex("dbo.TrueOrFalseQuestions", new[] { "Survey_ID" });
            DropColumn("dbo.TrueOrFalseQuestions", "Survey_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrueOrFalseQuestions", "Survey_ID", c => c.Int());
            CreateIndex("dbo.TrueOrFalseQuestions", "Survey_ID");
            AddForeignKey("dbo.TrueOrFalseQuestions", "Survey_ID", "dbo.Surveys", "ID");
        }
    }
}
