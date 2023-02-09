using System;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;
        public CategoryRepository(DataContext context) => _context = context;

        public bool CategoryExists(int id) =>
            _context
            .Categories
            .Any(c => c.Id == id);

        public bool CreateCategory(Category category)
        {
            //Change Traacker
            //adding, updating,modifing
            //connrcted and disconnected
            //EntityState.Added
            _context.Add(category);
            return Save();

        }

        public ICollection<Category> GetCategories() => _context
            .Categories
            .ToList();

        public Category GetCategory(int id) =>
            _context
            .Categories
            .Where(e => e.Id == id)
            .FirstOrDefault();

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId) =>
            _context
            .PokemonCategories
            .Where(e => e.CategoryId == categoryId)
            .Select(c => c.Pokemon)
            .ToList();

        public bool Save()
        {
            var save = _context.SaveChanges();

            return save > 0;
        }
    }
}

