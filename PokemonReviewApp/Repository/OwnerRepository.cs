using System;
using PokemonReviewApp.Data;
using PokemonReviewApp.Models;
using PokemonReviewApp.Interface;
using System.Diagnostics.Metrics;


namespace PokemonReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context) => _context = context;

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        public Owner GetOwner(int ownerId) => _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeId) => _context.PokemonOwners.Where(p => p.Pokemon.Id == pokeId).Select(o => o.Owner).ToList();

        public ICollection<Owner> GetOwners() => _context.Owners.ToList();

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId) => _context.PokemonOwners.Where(p => p.Owner.Id == ownerId).Select(p => p.Pokemon).ToList();

        public bool OwnerExists(int ownerId) => _context.Owners.Any(o => o.Id == ownerId);

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdateOwner(Owner owner)
        {

            _context.Update(owner);
            return Save();
        }
    }
}

