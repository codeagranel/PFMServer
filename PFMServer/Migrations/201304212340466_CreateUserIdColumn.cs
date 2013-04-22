namespace PFMServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserIdColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incomes", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.MethodOfPayments", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Expenses", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expenses", "UserId");
            DropColumn("dbo.MethodOfPayments", "UserId");
            DropColumn("dbo.Categories", "UserId");
            DropColumn("dbo.Incomes", "UserId");
        }
    }
}
