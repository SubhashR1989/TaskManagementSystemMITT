namespace TaskManagementSystemMITT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinishBaseicClasses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "IsOpened", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProjectTasks", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectTasks", "Priority");
            DropColumn("dbo.Notifications", "IsOpened");
        }
    }
}
