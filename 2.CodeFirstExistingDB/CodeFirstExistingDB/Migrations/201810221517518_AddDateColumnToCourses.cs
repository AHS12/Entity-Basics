namespace CodeFirstExistingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateColumnToCourses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Date");
        }
    }
}
