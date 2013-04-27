using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFMServer.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsRecurrent { get; set; }
        public Nullable<int> Parcels { get; set; }
        public Nullable<bool> IsAlreadyPaid { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> AuthorId { get; set; }

        public virtual MethodOfPayment MethodOfPayment { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }
    }
}