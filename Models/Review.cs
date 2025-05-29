using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        //Make a review to the service that was provided
        public int? ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}