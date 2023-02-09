using System;
using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Review GetReview(int reviewId) => _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();

        public ICollection<Review> GetReviews() => _context.Reviews.ToList();

        public ICollection<Review> GetReviewsOfAPokemon(int pokeId) => _context.Reviews.Where(r => r.Pokemon.Id == pokeId).ToList();

        public bool ReviewExists(int reviewId) => _context.Reviews.Any(r => r.Id == reviewId);

        public bool CreateReview(Review review)
        {
            _context.Add(review);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public bool UpdateReview(Review review)
        {
            _context.Update(review);
            return Save();
        }
    }
}

