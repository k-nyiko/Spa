using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.PaymentDTO;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;
        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> CreatePayment(Payment paymentModel)
        {
            await _context.Payments.AddAsync(paymentModel);
            await _context.SaveChangesAsync();

            return paymentModel;
        }

        public async Task<Payment?> DeletePaymnet(int id)
        {
            var pay = await _context.Payments.FirstOrDefaultAsync(p => p.PaymentId == id);
            if (pay == null)
            {
                return null;
            }

            _context.Payments.Remove(pay);
            await _context.SaveChangesAsync();
            return pay;
        }

        public async Task<List<Payment>> GetAllPayments()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment?> GetById(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task<Payment?> UpdatePayment(int id, UpdatePaymentDTO paymentDTO)
        {
            var pay = await _context.Payments.FirstOrDefaultAsync(p => p.PaymentId == id);
            if (pay == null)
            {
                return null;
            }

            pay.PaymentMethod = paymentDTO.PaymentMethod;
            pay.Amount = paymentDTO.Amount;
            pay.PaidAt = paymentDTO.PaidAt;

            await _context.SaveChangesAsync();
            return pay;
        }
    }
}