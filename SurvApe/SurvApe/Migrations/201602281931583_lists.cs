namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lists : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "Respondant_ID", c => c.Int());
            AddColumn("dbo.Questions", "Survey_ID", c => c.Int());
            CreateIndex("dbo.Answers", "Respondant_ID");
            CreateIndex("dbo.Questions", "Survey_ID");
            AddForeignKey("dbo.Answers", "Respondant_ID", "dbo.Respondants", "ID");
            AddForeignKey("dbo.Questions", "Survey_ID", "dbo.Surveys", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Survey_ID", "dbo.Surveys");
            DropForeignKey("dbo.Answers", "Respondant_ID", "dbo.Respondants");
            DropIndex("dbo.Questions", new[] { "Survey_ID" });
            DropIndex("dbo.Answers", new[] { "Respondant_ID" });
            DropColumn("dbo.Questions", "Survey_ID");
            DropColumn("dbo.Answers", "Respondant_ID");
        }
    }
}
