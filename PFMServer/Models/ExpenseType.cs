using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFMServer.Models
{
    public class ExpenseType
    {
        public ExpenseType()
        {
            this.Expenses = new HashSet<Expense>();
        }

        public int ExpenseTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> AuthorId { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}