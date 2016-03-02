namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class answer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "AnswerOptionInt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "AnswerOptionInt", c => c.Int(nullable: false));
        }
    }
}
