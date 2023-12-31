﻿using HotelBooking.BookingDTO.ReviewDtos;
using HotelBooking.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("token/Review")]
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