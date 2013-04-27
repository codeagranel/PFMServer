using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFMServer.Models
{
    public class IncomeType
    {
        public IncomeType()
        {
            this.Incomes = new HashSet<Income>();
        }
    
        public int IncomeTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> AuthorId { get; set; }
    
        public virtual ICollection<Income> Incomes { get; set; }
    }
}