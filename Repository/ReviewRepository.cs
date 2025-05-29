using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.NoteDTO.ReviewDTO;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace api.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Review> CreateReview(Review reviewModel)
        {
            await _context.Reviews.AddAsync(reviewModel);
            await _context.SaveChangesAsync();

            return reviewModel;
        }

        public async Task<Review?> DeleteReview(int id)
        {
            var rev = await _context.Reviews.FirstOrDefaultAsync(r => r.ReviewId == id);
            if (rev == null)
            {
                return null;
            }

            _context.Reviews.Remove(rev);
            await _context.SaveChangesAsync();
            return rev;
        }

        public async Task<List<Review>> GetAllReview()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review?> GetById(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<Review?> UpdateReview(int id, UpdateReviewDTO updateReview)
        {
            var rev = await _context.Reviews.FirstOrDefaultAsync(r => r.ReviewId == id);
            if (rev == null)
            {
                return null;
            }

            rev.Comment = updateReview.Comment;
            rev.DateCreated = updateReview.DateCreated;

            await _context.SaveChangesAsync();
            return rev;
        }
    }
}