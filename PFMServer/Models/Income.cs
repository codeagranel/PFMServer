using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PFMServer.Models
{
    public class Income
    {
        public Income()
        {
        }

        public int IncomeId { get; set; }
        public string Name { get; set; }
        public bool Paid { get; set; }
        public bool Recurrent { get; set; }
        public int Parcels { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public List<Category> Categories { get; set; }
        public MethodOfPayment MethodOfPayment { get; set; }
    }
}