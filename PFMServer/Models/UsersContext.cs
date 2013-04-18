﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PFMServer.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Income> Incomes { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<MethodOfPayment> MethodOfPayments { get; set; }
    }
}