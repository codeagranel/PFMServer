namespace PFMServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorOfModelEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "MethodOfPaymentId", "dbo.MethodOfPayments");
            DropForeignKey("dbo.ExpenseCategories", "Expense_ExpenseId", "dbo.Expenses");
            DropForeignKey("dbo.ExpenseCategories", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryIncomes", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryIncomes", "Income_IncomeId", "dbo.Incomes");
            DropIndex("dbo.Expenses", new[] { "MethodOfPaymentId" });
            DropIndex("dbo.ExpenseCategories", new[] { "Expense_ExpenseId" });
            DropIndex("dbo.ExpenseCategories", new[] { "Category_CategoryId" });
            DropIndex("dbo.CategoryIncomes", new[] { "Category_CategoryId" });
            DropIndex("dbo.CategoryIncomes", new[] { "Income_IncomeId" });
            CreateTable(
                "dbo.ExpenseTypes",
                c => new
                    {
                        ExpenseTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        AuthorId = c.Int(),
                    })
                .PrimaryKey(t => t.ExpenseTypeId);
            
            CreateTable(
                "dbo.IncomeTypes",
                c => new
                    {
                        IncomeTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        AuthorId = c.Int(),
                    })
                .PrimaryKey(t => t.IncomeTypeId);
            
            AddColumn("dbo.Incomes", "IsRecurrent", c => c.Boolean());
            AddColumn("dbo.Incomes", "IsAlreadyPaid", c => c.Boolean());
            AddColumn("dbo.Incomes", "PaymentDate", c => c.DateTime());
            AddColumn("dbo.Incomes", "AuthorId", c => c.Int());
            AddColumn("dbo.Incomes", "IncomeType_IncomeTypeId", c => c.Int());
            AddColumn("dbo.Expenses", "IsRecurrent", c => c.Boolean());
            AddColumn("dbo.Expenses", "IsAlreadyPaid", c => c.Boolean());
            AddColumn("dbo.Expenses", "PaymentDate", c => c.DateTime());
            AddColumn("dbo.Expenses", "AuthorId", c => c.Int());
            AddColumn("dbo.Expenses", "MethodOfPayment_MethodOfPaymentId", c => c.Int());
            AddColumn("dbo.Expenses", "ExpenseType_ExpenseTypeId", c => c.Int());
            AddColumn("dbo.MethodOfPayments", "AuthorId", c => c.Int());
            AlterColumn("dbo.Incomes", "Parcels", c => c.Int());
            AlterColumn("dbo.Incomes", "Amount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Expenses", "Name", c => c.String());
            AlterColumn("dbo.Expenses", "Parcels", c => c.Int());
            AlterColumn("dbo.Expenses", "Amount", c => c.Decimal(precision: 18, scale: 2));
            AddForeignKey("dbo.Expenses", "MethodOfPayment_MethodOfPaymentId", "dbo.MethodOfPayments", "MethodOfPaymentId");
            AddForeignKey("dbo.Expenses", "ExpenseType_ExpenseTypeId", "dbo.ExpenseTypes", "ExpenseTypeId");
            AddForeignKey("dbo.Incomes", "IncomeType_IncomeTypeId", "dbo.IncomeTypes", "IncomeTypeId");
            CreateIndex("dbo.Expenses", "MethodOfPayment_MethodOfPaymentId");
            CreateIndex("dbo.Expenses", "ExpenseType_ExpenseTypeId");
            CreateIndex("dbo.Incomes", "IncomeType_IncomeTypeId");
            DropColumn("dbo.Incomes", "Paid");
            DropColumn("dbo.Incomes", "Recurrent");
            DropColumn("dbo.Incomes", "Date");
            DropColumn("dbo.Incomes", "UserId");
            DropColumn("dbo.Expenses", "Recurrent");
            DropColumn("dbo.Expenses", "Paid");
            DropColumn("dbo.Expenses", "Date");
            DropColumn("dbo.Expenses", "MethodOfPaymentId");
            DropColumn("dbo.Expenses", "UserId");
            DropColumn("dbo.MethodOfPayments", "UserId");
            DropTable("dbo.Categories");
            DropTable("dbo.ExpenseCategories");
            DropTable("dbo.CategoryIncomes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CategoryIncomes",
                c => new
                    {
                        Category_CategoryId = c.Int(nullable: false),
                        Income_IncomeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_CategoryId, t.Income_IncomeId });
            
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        Expense_ExpenseId = c.Int(nullable: false),
                        Category_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Expense_ExpenseId, t.Category_CategoryId });
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.MethodOfPayments", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Expenses", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Expenses", "MethodOfPaymentId", c => c.Int(nullable: false));
            AddColumn("dbo.Expenses", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Expenses", "Paid", c => c.Boolean(nullable: false));
            AddColumn("dbo.Expenses", "Recurrent", c => c.Boolean(nullable: false));
            AddColumn("dbo.Incomes", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Incomes", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Incomes", "Recurrent", c => c.Boolean(nullable: false));
            AddColumn("dbo.Incomes", "Paid", c => c.Boolean(nullable: false));
            DropIndex("dbo.Incomes", new[] { "IncomeType_IncomeTypeId" });
            DropIndex("dbo.Expenses", new[] { "ExpenseType_ExpenseTypeId" });
            DropIndex("dbo.Expenses", new[] { "MethodOfPayment_MethodOfPaymentId" });
            DropForeignKey("dbo.Incomes", "IncomeType_IncomeTypeId", "dbo.IncomeTypes");
            DropForeignKey("dbo.Expenses", "ExpenseType_ExpenseTypeId", "dbo.ExpenseTypes");
            DropForeignKey("dbo.Expenses", "MethodOfPayment_MethodOfPaymentId", "dbo.MethodOfPayments");
            AlterColumn("dbo.Expenses", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Expenses", "Parcels", c => c.Int(nullable: false));
            AlterColumn("dbo.Expenses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Incomes", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Incomes", "Parcels", c => c.Int(nullable: false));
            DropColumn("dbo.MethodOfPayments", "AuthorId");
            DropColumn("dbo.Expenses", "ExpenseType_ExpenseTypeId");
            DropColumn("dbo.Expenses", "MethodOfPayment_MethodOfPaymentId");
            DropColumn("dbo.Expenses", "AuthorId");
            DropColumn("dbo.Expenses", "PaymentDate");
            DropColumn("dbo.Expenses", "IsAlreadyPaid");
            DropColumn("dbo.Expenses", "IsRecurrent");
            DropColumn("dbo.Incomes", "IncomeType_IncomeTypeId");
            DropColumn("dbo.Incomes", "AuthorId");
            DropColumn("dbo.Incomes", "PaymentDate");
            DropColumn("dbo.Incomes", "IsAlreadyPaid");
            DropColumn("dbo.Incomes", "IsRecurrent");
            DropTable("dbo.IncomeTypes");
            DropTable("dbo.ExpenseTypes");
            CreateIndex("dbo.CategoryIncomes", "Income_IncomeId");
            CreateIndex("dbo.CategoryIncomes", "Category_CategoryId");
            CreateIndex("dbo.ExpenseCategories", "Category_CategoryId");
            CreateIndex("dbo.ExpenseCategories", "Expense_ExpenseId");
            CreateIndex("dbo.Expenses", "MethodOfPaymentId");
            AddForeignKey("dbo.CategoryIncomes", "Income_IncomeId", "dbo.Incomes", "IncomeId", cascadeDelete: true);
            AddForeignKey("dbo.CategoryIncomes", "Category_CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.ExpenseCategories", "Category_CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.ExpenseCategories", "Expense_ExpenseId", "dbo.Expenses", "ExpenseId", cascadeDelete: true);
            AddForeignKey("dbo.Expenses", "MethodOfPaymentId", "dbo.MethodOfPayments", "MethodOfPaymentId", cascadeDelete: true);
        }
    }
}
