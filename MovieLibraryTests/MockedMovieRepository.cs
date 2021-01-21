using MovieLibrary.Services;
using MovieLibrary.Models;
using System.Collections.Generic;

namespace MovieLibraryTests.Mocks 
{
    public class MockedMovieRepository: IMovieRepository {
        private IEnumerable<Movie> _movies { get; set; }
        public MockedMovieRepository(IEnumerable<Movie> movies)
        {
            _movies = movies;
        }
        public IEnumerable<Movie> GetMovies()
        {
            return _movies;
        }
    }
}