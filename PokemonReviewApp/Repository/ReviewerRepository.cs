using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Reviewer GetReviewer(int reviewerId) => _context.Reviewers.Where(r => r.Id == reviewerId).Include(e => e.Reviews).FirstOrDefault();

        public ICollection<Reviewer> GetReviewers() => _context.Reviewers.ToList();

        public ICollection<Review> GetReviewsByReviewer(int reviewerId) => _context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();

        public bool ReviewerExists(int reviewerId) => _context.Reviewers.Any(r => r.Id == reviewerId);

    }
}

