namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskFieldsCut : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.SubTasks", "TaskId", "dbo.Tasks");
            DropIndex("dbo.Tasks", new[] { "CategoryId" });
            DropIndex("dbo.SubTasks", new[] { "TaskId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.SubTasks", "TaskId");
            CreateIndex("dbo.Tasks", "CategoryId");
            AddForeignKey("dbo.SubTasks", "TaskId", "dbo.Tasks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tasks", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
