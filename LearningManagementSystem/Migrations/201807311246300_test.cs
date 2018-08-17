namespace LearningManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CourseName", c => c.String(nullable: false));
            DropColumn("dbo.Courses", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Courses", "CourseName");
        }
    }
}
