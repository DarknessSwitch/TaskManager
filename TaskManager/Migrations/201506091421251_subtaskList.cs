namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subtaskList : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Subtasks", "TaskId", "dbo.Tasks", "Id", cascadeDelete: true);
            CreateIndex("dbo.Subtasks", "TaskId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Subtasks", new[] { "TaskId" });
            DropForeignKey("dbo.Subtasks", "TaskId", "dbo.Tasks");
        }
    }
}
