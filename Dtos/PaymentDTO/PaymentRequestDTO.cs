using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.PaymentDTO
{
    public class PaymentRequestDTO
    {
        public string PaymentMethod { get; set; } = string.Empty; //This cannot be null
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }
    }
}