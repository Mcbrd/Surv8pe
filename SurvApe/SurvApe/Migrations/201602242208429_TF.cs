namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TF : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrueOrFalseQuestions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Type = c.Int(nullable: false),
                        Answer = c.Boolean(nullable: false),
                        Survey_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Surveys", t => t.Survey_ID)
                .Index(t => t.Survey_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrueOrFalseQuestions", "Survey_ID", "dbo.Surveys");
            DropIndex("dbo.TrueOrFalseQuestions", new[] { "Survey_ID" });
            DropTable("dbo.TrueOrFalseQuestions");
        }
    }
}
