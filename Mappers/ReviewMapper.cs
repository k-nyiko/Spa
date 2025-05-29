using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ReviewDTO;
using api.Models;
using Npgsql.Replication;

namespace api.Mappers
{
    public static class ReviewMapper
    {
        public static Review NewReview(this ReviewRequestDTO requestDTO)
        {
            return new Review
            {
                Comment = requestDTO.Comment,
                DateCreated = requestDTO.DateCreated
            };
        }
    }
}