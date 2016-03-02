namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _int : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CompletedSurveys", "AnswerGivenInt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompletedSurveys", "AnswerGivenInt", c => c.Int(nullable: false));
        }
    }
}
