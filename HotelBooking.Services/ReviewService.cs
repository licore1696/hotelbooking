using AutoMapper;
using HotelBooking.BookingDTO;
using HotelBooking.DataAccess.Repository;
using HotelBooking.DataAccess.Repository.Contracts;
using HotelBooking.Entities;
using HotelBooking.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    public class ReviewService : IReviewService
    {
        public readonly IReviewRepository _reviewRepository;
        public readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(ReviewDto reviewDto)
        {
            var reviewToAdd = _mapper.Map<Review>(reviewDto);

            return await _reviewRepository.Create(reviewToAdd);
        }

        public async Task<bool> Delete(int id)
        {
            var reviewToDelete = await _reviewRepository.GetById(id);
            if (reviewToDelete == null)
            {
                return false;
            }
            await _reviewRepository.Delete(reviewToDelete);
            return true;
        }

        public async Task<ReviewDto> GetById(int id)
        {
            var review = await _reviewRepository.GetById(id);
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<List<ReviewDto>> GetReviews()
        {
            var review = await _reviewRepository.GetReviews();
            return _mapper.Map<List<ReviewDto>>(review);
        }

        public async Task<ReviewDto> Update(ReviewDto reviewDto)
        {
            var existingReview = await _reviewRepository.GetById(reviewDto.Id);

            if (existingReview == null)
            {
                return null;
            }

            _mapper.Map(reviewDto, existingReview);

            await _reviewRepository.Update(existingReview);

            return _mapper.Map<ReviewDto>(existingReview);
        }
    }
}
