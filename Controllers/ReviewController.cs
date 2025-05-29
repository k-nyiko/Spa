using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ReviewDTO;
using api.Mappers;
using api.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using api.Dtos.NoteDTO.ReviewDTO;

namespace api.Controllers
{
    [Route("/Reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepo;
        public ReviewController(IReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var rev = await _reviewRepo.GetAllReview();
            return Ok(rev);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var rev = await _reviewRepo.GetById(id);
            if (rev == null)
            {
                return NotFound();
            }

            return Ok(rev);
        }


        [HttpPost]
        public async Task<IActionResult> CreateReview(ReviewRequestDTO requestDTO)
        {
            var rev = requestDTO.NewReview();
            await _reviewRepo.CreateReview(rev);

            return CreatedAtAction(nameof(GetById), new { id = rev.ReviewId }, rev);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview([FromRoute] int id, [FromBody] UpdateReviewDTO reviewDTO)
        {
            var rev = await _reviewRepo.UpdateReview(id, reviewDTO);
            if (rev == null)
            {
                return NotFound();
            }

            rev.Comment = reviewDTO.Comment;
            rev.DateCreated = reviewDTO.DateCreated;

            return Ok(rev);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview([FromRoute] int id)
        {
            var rev = await _reviewRepo.DeleteReview(id);
            if (rev == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}