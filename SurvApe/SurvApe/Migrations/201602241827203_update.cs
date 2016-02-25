namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        pollster_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pollsters", t => t.pollster_ID)
                .Index(t => t.pollster_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Surveys", "pollster_ID", "dbo.Pollsters");
            DropIndex("dbo.Surveys", new[] { "pollster_ID" });
            DropTable("dbo.Surveys");
        }
    }
}
