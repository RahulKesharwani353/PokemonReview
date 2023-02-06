using System;
namespace PokemonReviewApp.Models
{
	public class Pokemon
	{
		public int poke_id { get; set; }
		public string? name { get; set; }	
		public string? poke_type { get; set; }
		public ICollection<Review>? reviews { get; set; }
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }


    }
}

