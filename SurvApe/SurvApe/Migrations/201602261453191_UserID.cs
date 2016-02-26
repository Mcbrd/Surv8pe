namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "UserID", c => c.String());
            AddColumn("dbo.Questions", "UserID", c => c.String());
            AddColumn("dbo.Pollsters", "UserID", c => c.String());
            AddColumn("dbo.CompletedSurveys", "UserID", c => c.String());
            AddColumn("dbo.Surveys", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Surveys", "UserID");
            DropColumn("dbo.CompletedSurveys", "UserID");
            DropColumn("dbo.Pollsters", "UserID");
            DropColumn("dbo.Questions", "UserID");
            DropColumn("dbo.Answers", "UserID");
        }
    }
}
