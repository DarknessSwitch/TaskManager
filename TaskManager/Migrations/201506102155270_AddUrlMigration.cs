namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrlMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "CategoryUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "CategoryUrl");
        }
    }
}
