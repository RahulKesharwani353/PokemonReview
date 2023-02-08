using System;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
	public interface IPokemonRepository
	{
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        Pokemon GetPokemonTrimToUpper(PokemonDto pokemonCreate);
        decimal GetPokemonRating(int pokeId);

    }
}

