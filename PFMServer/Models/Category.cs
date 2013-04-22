using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PFMServer.Models
{
    public class Category
    {
        public Category()
        {

        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int UserId { get; set; }
    }
}