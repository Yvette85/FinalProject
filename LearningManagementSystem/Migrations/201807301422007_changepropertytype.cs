namespace LearningManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changepropertytype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Modules", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modules", "Description", c => c.Int(nullable: false));
        }
    }
}
