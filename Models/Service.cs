using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Service
    {
        //Services provided by SPA
        public int ServiceId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        
        //Create a relationship with a serviews, customer can review the services that we're provided
        public List<Review> review { get; set; } = new List<Review>();

    }
}