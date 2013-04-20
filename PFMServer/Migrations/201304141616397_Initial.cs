namespace PFMServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.UserProfile",
            //    c => new
            //        {
            //            UserId = c.Int(nullable: false, identity: true),
            //            UserName = c.String(),
            //        })
            //    .PrimaryKey(t => t.UserId);

            //CreateTable(
            //    "dbo.Incomes",
            //    c => new
            //        {
            //            IncomeId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Paid = c.Boolean(nullable: false),
            //            Recurrent = c.Boolean(nullable: false),
            //            Parcels = c.Int(nullable: false),
            //            Description = c.String(),
            //            Date = c.DateTime(nullable: false),
            //            Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            MethodOfPayment_MethodOfPaymentId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.IncomeId)
            //    .ForeignKey("dbo.MethodOfPayments", t => t.MethodOfPayment_MethodOfPaymentId)
            //    .Index(t => t.MethodOfPayment_MethodOfPaymentId);

            //CreateTable(
            //    "dbo.Categories",
            //    c => new
            //        {
            //            CategoryId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Description = c.String(),
            //            Income_IncomeId = c.Int(),
            //            Expense_ExpenseId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.CategoryId)
            //    .ForeignKey("dbo.Incomes", t => t.Income_IncomeId)
            //    .ForeignKey("dbo.Expenses", t => t.Expense_ExpenseId)
            //    .Index(t => t.Income_IncomeId)
            //    .Index(t => t.Expense_ExpenseId);

            //CreateTable(
            //    "dbo.MethodOfPayments",
            //    c => new
            //        {
            //            MethodOfPaymentId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Description = c.String(),
            //        })
            //    .PrimaryKey(t => t.MethodOfPaymentId);

            //CreateTable(
            //    "dbo.Expenses",
            //    c => new
            //        {
            //            ExpenseId = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Recurrent = c.Boolean(nullable: false),
            //            Parcels = c.Int(nullable: false),
            //            Paid = c.Boolean(nullable: false),
            //            Description = c.String(),
            //            Date = c.DateTime(nullable: false),
            //            Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            MethodOfPayment_MethodOfPaymentId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ExpenseId)
            //    .ForeignKey("dbo.MethodOfPayments", t => t.MethodOfPayment_MethodOfPaymentId)
            //    .Index(t => t.MethodOfPayment_MethodOfPaymentId);
            
        }
        
        public override void Down()
        {
            //DropIndex("dbo.Expenses", new[] { "MethodOfPayment_MethodOfPaymentId" });
            //DropIndex("dbo.Categories", new[] { "Expense_ExpenseId" });
            //DropIndex("dbo.Categories", new[] { "Income_IncomeId" });
            //DropIndex("dbo.Incomes", new[] { "MethodOfPayment_MethodOfPaymentId" });
            //DropForeignKey("dbo.Expenses", "MethodOfPayment_MethodOfPaymentId", "dbo.MethodOfPayments");
            //DropForeignKey("dbo.Categories", "Expense_ExpenseId", "dbo.Expenses");
            //DropForeignKey("dbo.Categories", "Income_IncomeId", "dbo.Incomes");
            //DropForeignKey("dbo.Incomes", "MethodOfPayment_MethodOfPaymentId", "dbo.MethodOfPayments");
            //DropTable("dbo.Expenses");
            //DropTable("dbo.MethodOfPayments");
            //DropTable("dbo.Categories");
            //DropTable("dbo.Incomes");
            //DropTable("dbo.UserProfile");
        }
    }
}
