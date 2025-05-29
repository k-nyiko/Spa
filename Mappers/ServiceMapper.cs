using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ServiceDTO;
using api.Models;
using Npgsql.Replication;

namespace api.Mappers
{
    public static class ServiceMapper
    {
        public static Service NewService(this ServiceRequestDTO requestDTO)
        {
            return new Service
            {
                Name = requestDTO.Name,
                Description = requestDTO.Description,
                Category = requestDTO.Category,
                Price = requestDTO.Price
            };
        }
    }
}