using System;
using System.Collections.Generic;
using System.Linq;
using MovieLibrary.Models;

namespace MovieLibrary.Services
{
    public class MovieRepository : IMovieRepository
    {
        ISimpleMovieRepository _simpleMovieRepository { get; set; }
        IDetailedMovieRepository _detailedMovieRepository { get; set; }
        public MovieRepository(ISimpleMovieRepository simpleMovieRepository, IDetailedMovieRepository detailedMovieRepository)
        {
            _simpleMovieRepository = simpleMovieRepository;
            _detailedMovieRepository = detailedMovieRepository;
        }
        public Movie SimplifyDetailedMovie(DetailedMovie detailedMovie) 
        {
            return new Movie {
                id = detailedMovie.id,
                rated = detailedMovie.imdbRating.ToString("0.0"),
                title = detailedMovie.title
            };
        }
        public IEnumerable<Movie> GetMovies()
        {
            var simplifiedMovies = _detailedMovieRepository
                .GetDetailedMovies()
                .Select(movie => SimplifyDetailedMovie(movie));
            
            var simpleMovies = _simpleMovieRepository.GetMovies();

            var combinedMovies = simpleMovies
                .Union(simplifiedMovies)
                .GroupBy(movie => movie.title)
                .Select(movies => movies.First());
            
            return combinedMovies;
        }
    }
}