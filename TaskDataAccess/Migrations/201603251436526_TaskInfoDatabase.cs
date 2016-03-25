namespace TaskDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskInfoDatabase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TaskInfoes", newName: "TaskInfo");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TaskInfo", newName: "TaskInfoes");
        }
    }
}
