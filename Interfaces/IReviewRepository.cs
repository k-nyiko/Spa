using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.NoteDTO.ReviewDTO;
using api.Models;

namespace api.Interfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllReview();
        Task<Review?> GetById(int id);
        Task<Review> CreateReview(Review reviewModel);
        Task<Review?> UpdateReview(int id, UpdateReviewDTO updateReview);
        Task<Review?> DeleteReview(int id);
    }
}