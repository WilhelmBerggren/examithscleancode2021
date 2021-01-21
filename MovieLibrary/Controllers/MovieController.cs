using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models;
using MovieLibrary.Services;
using Microsoft.AspNetCore.Http;

namespace MovieLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController: ControllerBase
    {
        static HttpClient client = new HttpClient();
        private IMovieRepository _movieRepository { get; set; }

        public MovieController(IMovieRepository movieRepository) 
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        [Route("/toplist")]
        public IEnumerable<string> Toplist(bool asc = true)
        {
            List<string> res = new List<string>();
            var movieList = _movieRepository.GetMovies();
            var orderedMovieList = asc 
                ? movieList.OrderBy(e => e.rated) 
                : movieList.OrderByDescending(e => e.rated);
            
            return orderedMovieList.Select(movie => movie.title);
        }
        
        [HttpGet]
        [Route("/movie")]
        public ActionResult<Movie> GetMovieById(string id) {
            var movie =_movieRepository
                .GetMovies()
                .Where(movie => movie.id == id)
                .FirstOrDefault();
            if (movie != null) {
                return Ok(movie);
            } else {
                return NotFound(movie);
            }
            
        }
    }
}