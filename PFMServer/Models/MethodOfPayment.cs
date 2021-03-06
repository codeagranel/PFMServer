﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFMServer.Models
{
    public class MethodOfPayment
    {
        public MethodOfPayment()
        {
            this.Incomes = new HashSet<Income>();
            this.Expenses = new HashSet<Expense>();
        }

        public int MethodOfPaymentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> AuthorId { get; set; }

        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}