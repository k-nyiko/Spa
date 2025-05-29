using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PaymentDTO;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/Payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepo;
        public PaymentController(IPaymentRepository paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var pay = await _paymentRepo.GetAllPayments();
            return Ok(pay);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var pay = await _paymentRepo.GetById(id);
            if (pay == null)
            {
                return NotFound();
            }

            return Ok(pay);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(PaymentRequestDTO paymentRequestDTO)
        {
            var pay = paymentRequestDTO.NewPayment();
            await _paymentRepo.CreatePayment(pay);

            return CreatedAtAction(nameof(GetById), new { id = pay.PaymentId }, pay);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment([FromRoute] int id, [FromBody] UpdatePaymentDTO updatePaymentDTO)
        {
            var pay = await _paymentRepo.UpdatePayment(id, updatePaymentDTO);
            if (pay == null)
            {
                return NotFound();
            }

            pay.PaymentMethod = updatePaymentDTO.PaymentMethod;
            pay.Amount = updatePaymentDTO.Amount;
            pay.PaidAt = updatePaymentDTO.PaidAt;

            return Ok(pay);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var pay = await _paymentRepo.DeletePaymnet(id);
            if (pay == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}