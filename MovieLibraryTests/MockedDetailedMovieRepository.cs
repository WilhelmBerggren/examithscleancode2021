using MovieLibrary.Services;
using MovieLibrary.Models;
using System.Collections.Generic;

namespace MovieLibraryTests.Mocks 
{
    public class MockedDetailedMovieRepository: IDetailedMovieRepository {
        private IEnumerable<DetailedMovie> _movies { get; set; }
        public MockedDetailedMovieRepository(IEnumerable<DetailedMovie> movies)
        {
            _movies = movies;
        }
        public IEnumerable<DetailedMovie> GetDetailedMovies()
        {
            return _movies;
        }
    }
}