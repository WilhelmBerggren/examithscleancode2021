using System.Collections.Generic;
using MovieLibrary.Models;

namespace MovieLibrary.Services {
    public interface IMovieRepository {
        IEnumerable<Movie> GetMovies();
    }
}