using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ServiceDTO;
using api.Models;

namespace api.Interfaces
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAllServices();
        Task<Service?> GetById(int id);
        Task<Service> CreateService(Service serviceModel);
        Task<Service?> UpdateService(int id, UpdateServiceDTO serviceDTO);
        Task<Service?> DeleteService(int id);
    }
}