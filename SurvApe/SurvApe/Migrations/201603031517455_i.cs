namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "RespondantID", c => c.String());
            AddColumn("dbo.Questions", "PollsterID", c => c.String());
            AddColumn("dbo.CompletedSurveys", "PollsterID", c => c.String());
            AddColumn("dbo.CompletedSurveys", "SurveyID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompletedSurveys", "SurveyID");
            DropColumn("dbo.CompletedSurveys", "PollsterID");
            DropColumn("dbo.Questions", "PollsterID");
            DropColumn("dbo.Questions", "RespondantID");
        }
    }
}
