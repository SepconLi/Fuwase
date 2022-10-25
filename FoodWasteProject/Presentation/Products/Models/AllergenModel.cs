using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Products.Models
{
    public class AllergenModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }

        public AllergenModel(string name, string description, string category)
        {
            Name = name;
            Description = description;
            Category = category;
        }
    }
}
