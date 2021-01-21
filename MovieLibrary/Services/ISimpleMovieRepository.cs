using System.Collections.Generic;
using MovieLibrary.Models;

namespace MovieLibrary.Services 
{
    public interface ISimpleMovieRepository {
        IEnumerable<Movie> GetMovies();
    }
}