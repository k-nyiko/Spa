using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ServiceDTO;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Service> CreateService(Service serviceModel)
        {
            await _context.Services.AddAsync(serviceModel);
            await _context.SaveChangesAsync();

            return serviceModel;
        }

        public async Task<Service?> DeleteService(int id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.ServiceId == id);
            if (service == null)
            {
                return null;
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return service;
        }

        public async Task<List<Service>> GetAllServices()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service?> GetById(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<Service?> UpdateService(int id, UpdateServiceDTO serviceDTO)
        {
            var sev = await _context.Services.FirstOrDefaultAsync(s => s.ServiceId == id);
            if (sev == null)
            {
                return null;
            }

            sev.Name = serviceDTO.Name;
            sev.Description = serviceDTO.Description;
            sev.Category = serviceDTO.Category;
            sev.Price = serviceDTO.Price;

            await _context.SaveChangesAsync();
            return sev;
        }
    }
}