namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelstagsupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "TagList", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "TagList");
        }
    }
}
