using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PaymentDTO;
using api.Models;

namespace api.Mappers
{
    public static class PaymentMapper
    {
        public static Payment NewPayment(this PaymentRequestDTO paymentRequestDTO)
        {
            return new Payment
            {
                PaymentMethod = paymentRequestDTO.PaymentMethod,
                Amount = paymentRequestDTO.Amount,
                PaidAt = paymentRequestDTO.PaidAt
            };
        }
    }
}