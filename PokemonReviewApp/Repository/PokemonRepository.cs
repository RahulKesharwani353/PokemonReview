using System;
using PokemonReviewApp.Data;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public Pokemon GetPokemon(int id) => _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();

        public Pokemon GetPokemon(string name) => _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);

            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }


        public ICollection<Pokemon> GetPokemons() => _context.Pokemon.OrderBy(p => p.Id).ToList();

        public Pokemon GetPokemonTrimToUpper(PokemonDto pokemonCreate)
        {
            throw new NotImplementedException();

        }
    }
}

