namespace PFMServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoringExpense : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Income_IncomeId", "dbo.Incomes");
            DropForeignKey("dbo.Categories", "Expense_ExpenseId", "dbo.Expenses");
            DropForeignKey("dbo.Expenses", "MethodOfPayment_MethodOfPaymentId", "dbo.MethodOfPayments");
            DropIndex("dbo.Categories", new[] { "Income_IncomeId" });
            DropIndex("dbo.Categories", new[] { "Expense_ExpenseId" });
            DropIndex("dbo.Expenses", new[] { "MethodOfPayment_MethodOfPaymentId" });
            RenameColumn(table: "dbo.Expenses", name: "MethodOfPayment_MethodOfPaymentId", newName: "MethodOfPaymentId");
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        Expense_ExpenseId = c.Int(nullable: false),
                        Category_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Expense_ExpenseId, t.Category_CategoryId })
                .ForeignKey("dbo.Expenses", t => t.Expense_ExpenseId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId, cascadeDelete: true)
                .Index(t => t.Expense_ExpenseId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.CategoryIncomes",
                c => new
                    {
                        Category_CategoryId = c.Int(nullable: false),
                        Income_IncomeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_CategoryId, t.Income_IncomeId })
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Incomes", t => t.Income_IncomeId, cascadeDelete: true)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.Income_IncomeId);
            
            AlterColumn("dbo.Expenses", "Name", c => c.String(nullable: false));
            AddForeignKey("dbo.Expenses", "MethodOfPaymentId", "dbo.MethodOfPayments", "MethodOfPaymentId", cascadeDelete: true);
            CreateIndex("dbo.Expenses", "MethodOfPaymentId");
            DropColumn("dbo.Categories", "Income_IncomeId");
            DropColumn("dbo.Categories", "Expense_ExpenseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Expense_ExpenseId", c => c.Int());
            AddColumn("dbo.Categories", "Income_IncomeId", c => c.Int());
            DropIndex("dbo.CategoryIncomes", new[] { "Income_IncomeId" });
            DropIndex("dbo.CategoryIncomes", new[] { "Category_CategoryId" });
            DropIndex("dbo.ExpenseCategories", new[] { "Category_CategoryId" });
            DropIndex("dbo.ExpenseCategories", new[] { "Expense_ExpenseId" });
            DropIndex("dbo.Expenses", new[] { "MethodOfPaymentId" });
            DropForeignKey("dbo.CategoryIncomes", "Income_IncomeId", "dbo.Incomes");
            DropForeignKey("dbo.CategoryIncomes", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ExpenseCategories", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ExpenseCategories", "Expense_ExpenseId", "dbo.Expenses");
            DropForeignKey("dbo.Expenses", "MethodOfPaymentId", "dbo.MethodOfPayments");
            AlterColumn("dbo.Expenses", "Name", c => c.String());
            DropTable("dbo.CategoryIncomes");
            DropTable("dbo.ExpenseCategories");
            RenameColumn(table: "dbo.Expenses", name: "MethodOfPaymentId", newName: "MethodOfPayment_MethodOfPaymentId");
            CreateIndex("dbo.Expenses", "MethodOfPayment_MethodOfPaymentId");
            CreateIndex("dbo.Categories", "Expense_ExpenseId");
            CreateIndex("dbo.Categories", "Income_IncomeId");
            AddForeignKey("dbo.Expenses", "MethodOfPayment_MethodOfPaymentId", "dbo.MethodOfPayments", "MethodOfPaymentId");
            AddForeignKey("dbo.Categories", "Expense_ExpenseId", "dbo.Expenses", "ExpenseId");
            AddForeignKey("dbo.Categories", "Income_IncomeId", "dbo.Incomes", "IncomeId");
        }
    }
}
