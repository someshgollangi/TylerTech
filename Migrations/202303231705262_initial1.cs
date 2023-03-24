namespace TylerTech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "ManagerName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "ManagerName", c => c.Int(nullable: false));
        }
    }
}
