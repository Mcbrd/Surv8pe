namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class respondantid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompletedSurveys", "RespondantID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompletedSurveys", "RespondantID");
        }
    }
}
