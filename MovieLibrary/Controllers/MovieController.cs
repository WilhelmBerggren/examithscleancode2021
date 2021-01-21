using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models;
using MovieLibrary.Services;

namespace MovieLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController
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
            var ml = _movieRepository.GetMovies();
            //Sort ml
            if (asc)
            {
                ml.OrderBy(e => e.rated);
            }
            else
            {
                ml.OrderByDescending(e => e.rated);
            }
            foreach (var m in ml) {
                res.Add(m.title);
            }
            //result.Add(new StreamReader(response.Content.ReadAsStream()).ReadToEnd());
            return res;
        }
        
        [HttpGet]
        [Route("/movie")]
        public Movie GetMovieById(string id) {
            var ml = _movieRepository.GetMovies();
            foreach (var m in ml) {
                if (m.id.Equals((id)))
                {
                    return m; //Found it!
                }
            }
            return null;
        }
    }
}