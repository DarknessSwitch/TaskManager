namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeSubtaskList : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subtasks", "TaskId", "dbo.Tasks");
            DropIndex("dbo.Subtasks", new[] { "TaskId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Subtasks", "TaskId");
            AddForeignKey("dbo.Subtasks", "TaskId", "dbo.Tasks", "Id", cascadeDelete: true);
        }
    }
}
