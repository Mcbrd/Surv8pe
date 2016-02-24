namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        QuestionText = c.String(),
                        AnswerGivenString = c.String(),
                        AnswerGivenInt = c.Int(nullable: false),
                        AnswerGivenBool = c.Boolean(nullable: false),
                        question_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.question_ID)
                .Index(t => t.question_ID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        QuestionText = c.String(),
                        AnswerOptionString = c.String(),
                        AnswerOptionInt = c.Int(nullable: false),
                        AnswerOptionBool = c.Boolean(nullable: false),
                        pollster_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pollsters", t => t.pollster_ID)
                .Index(t => t.pollster_ID);
            
            CreateTable(
                "dbo.Pollsters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                        Address = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Zipcode = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        Company = c.String(),
                        JobTitle = c.String(),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CompletedSurveys",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        QuestionText = c.String(),
                        AnswerGivenString = c.String(),
                        AnswerGivenInt = c.Int(nullable: false),
                        AnswerGivenBool = c.Boolean(nullable: false),
                        answer_ID = c.Int(),
                        pollster_ID = c.Int(),
                        question_ID = c.Int(),
                        respondant_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Answers", t => t.answer_ID)
                .ForeignKey("dbo.Pollsters", t => t.pollster_ID)
                .ForeignKey("dbo.Questions", t => t.question_ID)
                .ForeignKey("dbo.Respondants", t => t.respondant_ID)
                .Index(t => t.answer_ID)
                .Index(t => t.pollster_ID)
                .Index(t => t.question_ID)
                .Index(t => t.respondant_ID);
            
            CreateTable(
                "dbo.Respondants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Zipcode = c.Int(nullable: false),
                        Citizenship = c.String(),
                        Age = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Company = c.String(),
                        Salary = c.Int(nullable: false),
                        Ethnicity = c.String(),
                        Religion = c.String(),
                        Education = c.String(),
                        Employed = c.Boolean(nullable: false),
                        PoliticalLeaning = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PossibleAnswers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        QuestionText = c.String(),
                        AnswerOptionString = c.String(),
                        AnswerOptionInt = c.Int(nullable: false),
                        AnswerOptionBool = c.Boolean(nullable: false),
                        question_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.question_ID)
                .Index(t => t.question_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PossibleAnswers", "question_ID", "dbo.Questions");
            DropForeignKey("dbo.CompletedSurveys", "respondant_ID", "dbo.Respondants");
            DropForeignKey("dbo.CompletedSurveys", "question_ID", "dbo.Questions");
            DropForeignKey("dbo.CompletedSurveys", "pollster_ID", "dbo.Pollsters");
            DropForeignKey("dbo.CompletedSurveys", "answer_ID", "dbo.Answers");
            DropForeignKey("dbo.Answers", "question_ID", "dbo.Questions");
            DropForeignKey("dbo.Questions", "pollster_ID", "dbo.Pollsters");
            DropIndex("dbo.PossibleAnswers", new[] { "question_ID" });
            DropIndex("dbo.CompletedSurveys", new[] { "respondant_ID" });
            DropIndex("dbo.CompletedSurveys", new[] { "question_ID" });
            DropIndex("dbo.CompletedSurveys", new[] { "pollster_ID" });
            DropIndex("dbo.CompletedSurveys", new[] { "answer_ID" });
            DropIndex("dbo.Questions", new[] { "pollster_ID" });
            DropIndex("dbo.Answers", new[] { "question_ID" });
            DropTable("dbo.PossibleAnswers");
            DropTable("dbo.Respondants");
            DropTable("dbo.CompletedSurveys");
            DropTable("dbo.Pollsters");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
