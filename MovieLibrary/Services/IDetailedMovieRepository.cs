using System.Collections.Generic;
using MovieLibrary.Models;

namespace MovieLibrary.Services 
{
    public interface IDetailedMovieRepository {
        IEnumerable<DetailedMovie> GetDetailedMovies();
    }
}