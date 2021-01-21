using MovieLibrary.Services;
using MovieLibrary.Models;
using System.Collections.Generic;

namespace MovieLibraryTests.Mocks 
{
    public class MockedMovieRepository: IMovieRepository {
        public IEnumerable<Movie> GetMovies()
        {
            throw new System.NotImplementedException();
        }
    }
}