namespace LearningManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Modules", "CourseId", "dbo.Courses");
            DropIndex("dbo.Modules", new[] { "CourseId" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Course_Id", newName: "CourseId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Course_Id", newName: "IX_CourseId");
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "RoleName", c => c.String());
            AddColumn("dbo.AspNetUsers", "CourseName", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 255));
            DropTable("dbo.Modules");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "CourseName");
            DropColumn("dbo.AspNetUsers", "RoleName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_CourseId", newName: "IX_Course_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "CourseId", newName: "Course_Id");
            CreateIndex("dbo.Modules", "CourseId");
            AddForeignKey("dbo.Modules", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
