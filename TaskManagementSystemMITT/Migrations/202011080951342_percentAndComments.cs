namespace TaskManagementSystemMITT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class percentAndComments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectTasks", "Comment", c => c.String());
            AddColumn("dbo.ProjectTasks", "PercentCompleted", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectTasks", "Comment");
            DropColumn("dbo.ProjectTasks", "PercentCompleted");
        }
    }
}
