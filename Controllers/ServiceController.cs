using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ServiceDTO;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/Services")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepo;
        public ServiceController(IServiceRepository serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var sev = await _serviceRepo.GetAllServices();
            return Ok(sev);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var sev = await _serviceRepo.GetById(id);
            if (sev == null)
            {
                return NotFound();
            }

            return Ok(sev);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(ServiceRequestDTO requestDTO)
        {
            var sev = requestDTO.NewService();
            await _serviceRepo.CreateService(sev);

            return CreatedAtAction(nameof(GetById), new { id = sev.ServiceId }, sev);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService([FromRoute] int id, [FromBody] UpdateServiceDTO serviceDTO)
        {
            var sev = await _serviceRepo.UpdateService(id, serviceDTO);
            if (sev == null)
            {
                return NotFound();
            }

            sev.Name = serviceDTO.Name;
            sev.Description = serviceDTO.Description;
            sev.Category = serviceDTO.Category;
            sev.Price = serviceDTO.Price;

            return Ok(sev);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var sev = await _serviceRepo.DeleteService(id);
            if (sev == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}