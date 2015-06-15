namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaskManager.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManager.Models.TaskManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaskManager.Models.TaskManagerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Categories.AddOrUpdate(x => x.Id,
                new Category { Id =1, Text = "Studying" },
                new Category {Id = 2, Text = "Housekeeping"});
            context.Tasks.AddOrUpdate(x => x.Id,
                new Task
                {
                    Id = 1,
                    CategoryId = 1,
                    Date = new DateTime(2015, 06, 02),
                    IsDone = false,
                    Text = "Make a task manager application",
                    CategoryUrl = "/Home/Category/1"
                },
                    new Task
                    {
                        Id = 2,
                        CategoryId = 2,
                        Date = new DateTime(2015, 06, 03),
                        IsDone = false,
                        Text = "Cook dessert for tomorrow dinner",
                        CategoryUrl = "/Home/Category/2"
                    });
            context.Subtasks.AddOrUpdate(x => x.Id,
                new Subtask { Id = 1, Text = "Read tutorials", IsDone = false, TaskId = 1 },
                new Subtask { Id = 2, Text = "Write code", IsDone = false, TaskId = 1 },
                new Subtask { Id = 3, Text = "Peel potatoes", IsDone = false, TaskId = 2 },
                new Subtask { Id = 4, Text = "Boil popatoes", IsDone = false, TaskId = 2 });                                
        }
    }
}
