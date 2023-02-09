using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : Controller
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;

        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult getReviews()
        {
            var reviewer = _reviewerRepository.GetReviewers();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(reviewer);
        }

            [HttpGet("{reviewerId}")]
            [ProducesResponseType(200, Type = typeof(Reviewer))]
            [ProducesResponseType(400)]
            public IActionResult GetPokemon(int reviewerId)
            {
                if (!_reviewerRepository.ReviewerExists(reviewerId))
                    return NotFound();

                var reviewer = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewer(reviewerId));

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(reviewer);
            }

            [HttpGet("{reviewerId}/reviews")]
            public IActionResult GetReviewsByAReviewer(int reviewerId)
            {
                if (!_reviewerRepository.ReviewerExists(reviewerId))
                    return NotFound();

                var reviews = _mapper.Map<List<ReviewDto>>(
                    _reviewerRepository.GetReviewsByReviewer(reviewerId));

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(reviews);
            }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReviewer([FromBody] ReviewerDto reviewerCreate)
        {
            if (reviewerCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewerMap = _mapper.Map<Reviewer>(reviewerCreate);

            if (!_reviewerRepository.CreateReviewer(reviewerMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
    }

