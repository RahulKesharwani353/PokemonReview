using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {

        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }
      

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _pokemonRepository.GetPokemons();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }
    }
    
}

