using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFMServer.ViewModels
{
    public class AssignedCategories
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}