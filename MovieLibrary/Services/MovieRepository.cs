using System.Collections.Generic;
using MovieLibrary.Controllers;
using MovieLibrary.Models;

namespace MovieLibrary.Services {
  public class MovieRepository: IMovieRepository {
    public IEnumerable<Movie> GetMovies()
    {
      throw new System.NotImplementedException();
    }
  }
}