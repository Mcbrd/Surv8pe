namespace SurvApe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questiontype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Type");
        }
    }
}
