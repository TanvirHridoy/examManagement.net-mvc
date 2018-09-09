namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelsupdatedforcourses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exams", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Exams", new[] { "Course_Id" });
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Address = c.String(),
                        ContactNo = c.String(),
                        Logo = c.Byte(nullable: false),
                        Course_Id = c.Int(),
                        Batch_Id = c.Int(),
                        Student_Id = c.Int(),
                        Trainer_Id = c.Int(),
                        Exams_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Batches", t => t.Batch_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Trainers", t => t.Trainer_Id)
                .ForeignKey("dbo.Exams", t => t.Exams_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Batch_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Trainer_Id)
                .Index(t => t.Exams_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RegNo = c.String(),
                        ContactNo = c.String(),
                        Email = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        PostalCode = c.Int(nullable: false),
                        Country = c.String(),
                        Profession = c.String(),
                        HighestAcademic = c.String(),
                        Image = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchNo = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactNo = c.String(),
                        Email = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        PostalCode = c.Int(nullable: false),
                        Country = c.String(),
                        Image = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.ExamsCourses",
                c => new
                    {
                        Exams_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Exams_Id, t.Course_Id })
                .ForeignKey("dbo.Exams", t => t.Exams_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Exams_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Course_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.TrainerCourses",
                c => new
                    {
                        Trainer_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trainer_Id, t.Course_Id })
                .ForeignKey("dbo.Trainers", t => t.Trainer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Trainer_Id)
                .Index(t => t.Course_Id);
            
            AddColumn("dbo.Courses", "Batch_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Batch_Id");
            AddForeignKey("dbo.Courses", "Batch_Id", "dbo.Batches", "Id");
            DropColumn("dbo.Exams", "CourseName");
            DropColumn("dbo.Exams", "Course_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exams", "Course_Id", c => c.Int());
            AddColumn("dbo.Exams", "CourseName", c => c.String());
            DropForeignKey("dbo.Tags", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Organizations", "Exams_Id", "dbo.Exams");
            DropForeignKey("dbo.Organizations", "Trainer_Id", "dbo.Trainers");
            DropForeignKey("dbo.TrainerCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.TrainerCourses", "Trainer_Id", "dbo.Trainers");
            DropForeignKey("dbo.Organizations", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Batches", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Organizations", "Batch_Id", "dbo.Batches");
            DropForeignKey("dbo.Courses", "Batch_Id", "dbo.Batches");
            DropForeignKey("dbo.Organizations", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.ExamsCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.ExamsCourses", "Exams_Id", "dbo.Exams");
            DropIndex("dbo.TrainerCourses", new[] { "Course_Id" });
            DropIndex("dbo.TrainerCourses", new[] { "Trainer_Id" });
            DropIndex("dbo.StudentCourses", new[] { "Course_Id" });
            DropIndex("dbo.StudentCourses", new[] { "Student_Id" });
            DropIndex("dbo.ExamsCourses", new[] { "Course_Id" });
            DropIndex("dbo.ExamsCourses", new[] { "Exams_Id" });
            DropIndex("dbo.Tags", new[] { "Course_Id" });
            DropIndex("dbo.Batches", new[] { "Student_Id" });
            DropIndex("dbo.Organizations", new[] { "Exams_Id" });
            DropIndex("dbo.Organizations", new[] { "Trainer_Id" });
            DropIndex("dbo.Organizations", new[] { "Student_Id" });
            DropIndex("dbo.Organizations", new[] { "Batch_Id" });
            DropIndex("dbo.Organizations", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "Batch_Id" });
            DropColumn("dbo.Courses", "Batch_Id");
            DropTable("dbo.TrainerCourses");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.ExamsCourses");
            DropTable("dbo.Tags");
            DropTable("dbo.Trainers");
            DropTable("dbo.Batches");
            DropTable("dbo.Students");
            DropTable("dbo.Organizations");
            CreateIndex("dbo.Exams", "Course_Id");
            AddForeignKey("dbo.Exams", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
