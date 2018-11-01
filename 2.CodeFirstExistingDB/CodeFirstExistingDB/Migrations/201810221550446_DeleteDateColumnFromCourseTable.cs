namespace CodeFirstExistingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDateColumnFromCourseTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Date", c => c.DateTime());
        }
    }
}
