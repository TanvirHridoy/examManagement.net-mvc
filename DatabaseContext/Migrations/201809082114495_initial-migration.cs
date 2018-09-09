namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false, maxLength: 50),
                        CourseCode = c.String(nullable: false, maxLength: 50),
                        Duration = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Outline = c.String(),
                        TrainerType = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        ExamType = c.String(),
                        ExamCode = c.String(),
                        Topic = c.String(),
                        FullMarks = c.Double(nullable: false),
                        Duration = c.Double(nullable: false),
                        Serial = c.String(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Exams", new[] { "Course_Id" });
            DropTable("dbo.Exams");
            DropTable("dbo.Courses");
        }
    }
}
