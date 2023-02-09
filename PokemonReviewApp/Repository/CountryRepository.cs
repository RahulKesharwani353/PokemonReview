using System;
using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Properties
{
    public class CountryRepository : ICountryRepository
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public bool CountryExists(int id) => _context.Countries.Any(c => c.Id == id);

        public bool CreateCountry(Country country)
        {
            _context.Add(country);
            return Save();
        }

        public ICollection<Country> GetCountries() => _context.Countries.ToList();

        public Country GetCountry(int id) => _context.Countries.Where(c => c.Id == id).FirstOrDefault();

        public Country GetCountryByOwner(int ownerId) => _context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();

        public ICollection<Owner> GetOwnersFromCounty(int countryId) => _context.Owners.Where(c => c.Country.Id == countryId).ToList();

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}

