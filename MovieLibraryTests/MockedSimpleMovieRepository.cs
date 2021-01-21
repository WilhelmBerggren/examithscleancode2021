using MovieLibrary.Services;
using MovieLibrary.Models;
using System.Collections.Generic;

namespace MovieLibraryTests.Mocks 
{
    public class MockedSimpleMovieRepository: ISimpleMovieRepository {
        private IEnumerable<Movie> _movies { get; set; }
        public MockedSimpleMovieRepository(IEnumerable<Movie> movies)
        {
            _movies = movies;
        }
        public IEnumerable<Movie> GetMovies()
        {
            return _movies;
        }
    }
}