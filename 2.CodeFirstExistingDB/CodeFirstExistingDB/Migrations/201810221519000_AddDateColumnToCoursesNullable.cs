namespace CodeFirstExistingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateColumnToCoursesNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Date", c => c.DateTime(nullable: false));
        }
    }
}
