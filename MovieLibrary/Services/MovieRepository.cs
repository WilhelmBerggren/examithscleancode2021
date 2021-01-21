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
        private Movie SimplifyDetailedMovie(DetailedMovie detailedMovie) 
        {
            return new Movie {
                id = detailedMovie.id,
                rated = detailedMovie.imdbRating.ToString(),
                title = detailedMovie.title
            };
        }
        public IEnumerable<Movie> GetMovies()
        {
            var simplifiedMovies = _detailedMovieRepository
                .GetDetailedMovies()
                .Select(movie => SimplifyDetailedMovie(movie));
            
            var simpleMovies = _simpleMovieRepository.GetMovies();

            return simpleMovies.Union(simplifiedMovies);
        }
    }
}