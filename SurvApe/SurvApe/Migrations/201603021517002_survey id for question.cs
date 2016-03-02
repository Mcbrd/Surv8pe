namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class surveyidforquestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "SurveyID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "SurveyID");
        }
    }
}
