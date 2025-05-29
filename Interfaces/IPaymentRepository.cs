using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PaymentDTO;
using api.Models;

namespace api.Interfaces
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllPayments();
        Task<Payment?> GetById(int id);
        Task<Payment> CreatePayment(Payment paymentModel);
        Task<Payment?> UpdatePayment(int id, UpdatePaymentDTO paymentDTO);
        Task<Payment?> DeletePaymnet(int id);
    }
}