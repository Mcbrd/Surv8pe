namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablebool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "AnswerOptionBool", c => c.Boolean());
            AlterColumn("dbo.CompletedSurveys", "AnswerGivenBool", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompletedSurveys", "AnswerGivenBool", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Questions", "AnswerOptionBool", c => c.Boolean(nullable: false));
        }
    }
}
