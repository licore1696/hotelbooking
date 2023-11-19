using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Entities;
using HotelBooking.DataAccess;
using HotelBooking.BookingDTO;
using HotelBooking.Services.Contracts;

namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("api/HotelBooking/Review")]
    public class ReviewController : ControllerBase
    {
        public readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ReviewDto>> GetById(int id)
        {
            return await _reviewService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] ReviewDto review)
        {
            return await _reviewService.Create(review);
        }

        [HttpGet("Reviews")]
        public async Task<ActionResult<List<ReviewDto>>> GetReviews()
        {
            var reviews = await _reviewService.GetReviews();
            return Ok(reviews);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ReviewDto reviewDto)
        {
            var updatedReviewDto = await _reviewService.Update(reviewDto);

            if (updatedReviewDto == null)
            {
                return NotFound();
            }

            return Ok(updatedReviewDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _reviewService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}