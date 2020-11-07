namespace TaskManagementSystemMITT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configuredview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectTasks", "PercentComplete", c => c.Int(nullable: false));
            AddColumn("dbo.ProjectTasks", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectTasks", "Comments");
            DropColumn("dbo.ProjectTasks", "PercentComplete");
        }
    }
}
